using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadButton : MonoBehaviour
{
    [SerializeField] private string _SceneName;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        StartCoroutine(LoadSceneAfterTime());
    }

    private IEnumerator LoadSceneAfterTime()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(_SceneName);
    }
}
