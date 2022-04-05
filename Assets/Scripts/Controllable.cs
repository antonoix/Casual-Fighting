using UnityEngine;

[RequireComponent(typeof(Hero))]
public class Controllable : MonoBehaviour
{
    private Hero _hero;
    private Attacker _attacker;
    private MobileInput _input;

    private void Awake()
    {
        _hero = GetComponent<Hero>();
        _attacker = GetComponent<Attacker>();
        _input = new MobileInput();
    }

    private void Start()
    {
        _input.OnTouchEnded += _attacker.Attack;
        _input.OnDirectionChanged += _hero.Move;
    }

    void Update()
    {
        _input.CheckTouch();
    }

    private void OnDestroy()
    {
        GameState.Instance.MakeFailed();
    }
}
