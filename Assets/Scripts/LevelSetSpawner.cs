using UnityEngine;
using System.Collections;

public class LevelSetSpawner : MonoBehaviour
{
    [SerializeField] private LevelSet[] _sets;

    private LevelSet _currentSet;
    
    void Start()
    {
        _currentSet = _sets[Random.Range(0, _sets.Length)];
        StartCoroutine(SpawnWeapon());
        StartCoroutine(SpawnShoes());
        if (_currentSet.LocationSet != null)
            Instantiate(_currentSet.LocationSet);
    }

    private IEnumerator SpawnWeapon()
    {
        int secondsInterval = 7;
        foreach (var weapon in _currentSet.Weapons)
        {
            yield return new WaitForSeconds(secondsInterval);
            var newWeapon = Instantiate(weapon, transform);
            newWeapon.Init(secondsInterval);
            newWeapon.transform.position = new Vector3(Random.Range(-14, 15), 1.3f, Random.Range(-14, 15));
        }
    }

    private IEnumerator SpawnShoes()
    {
        while(Time.timeSinceLevelLoad < 40)
        {
            var newShoes = Instantiate(_currentSet.Shoes[0], transform);
            newShoes.Init(8);
            newShoes.transform.position = new Vector3(Random.Range(-14, 15), 1.3f, Random.Range(-14, 15));
            yield return new WaitForSeconds(10);
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
