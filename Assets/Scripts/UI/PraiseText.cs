using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PraiseText : MonoBehaviour
{
    private TextMeshProUGUI _text;
    readonly string[] _texts = new string[2] { "GOOD", "PERFECT" };

    public void SetText(int count)
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = _texts[Mathf.Clamp(count - 2, 0, _texts.Length - 1)];

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
