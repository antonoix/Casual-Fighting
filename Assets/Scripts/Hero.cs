using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour, IAim
{
    public event Action<IAim> OnDied;
    public event Action<IAim> OnDestroyed;

    [SerializeField] protected GameObject _dieParticles;

    public float Multiplier { get; private set; } = 1;
    private Rigidbody _rb;
    private UI _UI;
    public float Speed { get; protected set; } = 5;
    private Animator _anim;
    public Animator GetAnimator => _anim;

    private float _attackTime;
    private int _killed;
    private bool _isRunning;
    private bool _isPlayer;
    private float _lastAttackTime;

    private bool _isEducation;
    public void SetEducation(bool isEducation) =>  _isEducation = isEducation;  

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _UI = GameObject.FindObjectOfType<UI>();
        _isPlayer = TryGetComponent<Controllable>(out var controllable);
        if (_isPlayer)
        {
            Multiplier += PlayerPrefs.GetFloat(PrefsConfig.SizeRatio);
            transform.localScale = new Vector3(1, 1, 1) * Multiplier;
            Speed += PlayerPrefs.GetFloat(PrefsConfig.SpeedRatio);
        }
    }

    void Update()
    {
        var run = _isRunning || Mathf.Abs(_rb.velocity.x) + Mathf.Abs(_rb.velocity.z) > 0.1f;
        _anim.SetBool("Run", run);
    }

    public void StartAttack(float attackDuration)
    {
        _attackTime = attackDuration;
        _anim.SetTrigger("Attack");
        _lastAttackTime = Time.time;
    }

    public void MakePlayerEffects()
    {
        if (_isPlayer)
            Sounds.Instance.PlayHit();
    }

    private void BecomeBigger(float multiplier)
    {
        Multiplier *= multiplier * 1.15f;
        transform.localScale = new Vector3(1, 1, 1) * Multiplier;

        if (_isEducation)
            return;
        int interval = 2;
        if (_isPlayer && ++_killed % interval == 0)
            _UI.CreatePraiseText(_killed / interval);
    }

    public virtual void Die(Hero killer)
    {
        killer.BecomeBigger(Multiplier);
        OnDied?.Invoke(this);
        var particles = Instantiate(_dieParticles);
        particles.transform.position = transform.position;
        Destroy(this.gameObject);
    }

    public void Move(Vector3 direction)
    {
        if (Time.time > _lastAttackTime + _attackTime)
        {
            var moveDirection = Vector3.forward * direction.y + Vector3.right * direction.x;
            _rb.velocity = moveDirection * Speed;

            transform.LookAt(transform.position + _rb.velocity);
        }
    }

    public void Move(IAim aim)
    {
        if (Time.time > _lastAttackTime + _attackTime)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, aim.transform.position, Speed * Time.deltaTime);
        }
    }

    public void SetRunningAnimation(bool isRunning)
    {
        _isRunning = isRunning;
    }

    public void IncreaseSpeed(float multiplier)
    {
        Speed *= multiplier;
    }
}
