using System.Collections;
using TMPro;
using UnityEngine;

public class FadeText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private string lastText;
    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        lastText = text.GetParsedText();
        color = text.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastText != text.GetParsedText())
        {
            color.a = 1f;
            text.color = color;
            lastText = text.GetParsedText();
            StartCoroutine("Fade");
        }
    }

    IEnumerator Fade()
    {
        while(color.a > 0)
        {
            if (lastText != text.GetParsedText()) StopCoroutine("Fade");

            color.a -= Time.deltaTime;
            color.a = Mathf.Clamp(color.a, 0f, 1f);
            text.color = color;
            yield return null;
        }

        lastText = "";
        text.SetText("");

        yield return null;
    }
}
