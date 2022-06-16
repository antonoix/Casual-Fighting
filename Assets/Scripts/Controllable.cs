using UnityEngine;

[RequireComponent(typeof(Hero))]
public class Controllable : MonoBehaviour
{
    private Hero _hero;
    private Attacker _attacker;
    private ISystemInput _input;

    public void Init(ISystemInput input)
    {
        _hero = GetComponent<Hero>();
        _attacker = GetComponent<Attacker>();
        _input = input;
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
}
