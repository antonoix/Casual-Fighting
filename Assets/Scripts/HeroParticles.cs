using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class HeroParticles : MonoBehaviour
{
    private ParticleSystem _dust;
    private Rigidbody _rb;

    void Start()
    {
        _dust = GetComponent<ParticleSystem>();
        _rb = transform.GetComponentInParent<Rigidbody>();
    }

    void Update()
    {
        if (Mathf.Abs(_rb.velocity.x) + Mathf.Abs(_rb.velocity.z) > 0.3f && !_dust.isPlaying)
        {
            _dust.Play();
        } 
        else if (_dust.isPlaying)
        {
            _dust.Stop();
        }
    }
}
