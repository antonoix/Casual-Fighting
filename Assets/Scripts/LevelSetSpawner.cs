using UnityEngine;

public class LevelSetSpawner : MonoBehaviour
{
    [SerializeField] private LevelSet[] _sets;
    
    void Start()
    {
        Debug.Log("LVlPawn");
        LevelSet set = _sets[Random.Range(0, _sets.Length)];
        foreach (var e in set.HeroSet)
        {
            Instantiate(e, transform);
        }
        Instantiate(set.LocationSet);
    }
}
