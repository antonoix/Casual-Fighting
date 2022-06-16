using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PraiseText : MonoBehaviour
{
    private TextMeshProUGUI _text;

    public void SetText(int count, string[] texts)
    {
        _text = GetComponent<TextMeshProUGUI>();
        int indx = (count - 1) % texts.Length;
        _text.text = texts[indx];

        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(1.2f);
        GetComponent<Animator>().SetTrigger("Click");
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
