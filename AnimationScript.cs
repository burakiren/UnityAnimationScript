using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationScript : MonoBehaviour
{
    private Image imgSelf;
    void Start()
    {
        imgSelf = GetComponent<Image>();
    }


    public void fade(bool fin, float sec)
    {
        // fades the image out when you click
        StartCoroutine(FadeImage(fin, sec));
    }

    public void fadeBlack(bool fin, float degree, float sec)
    {
        // fades the image out when you click
        StartCoroutine(FadeBlack(fin, degree, sec));
    }

    public void fadePanel(bool fin, float sec)
    {
        // fades the image out when you click
        StartCoroutine(FadePanel(fin, sec));
    }

    public void scale(float first, float last, float sec)
    {
        // fades the image out when you click
        StartCoroutine(ScaleTransform(first, last, sec));
    }

    public void translate(Vector3 diff, float sec)
    {
        // fades the image out when you click
        StartCoroutine(TranslateTransform(diff, sec));
    }

    IEnumerator FadeImage(bool fadeIn, float sec)
    {
        if (fadeIn)
        {            // loop over 1 second
            for (float i = 0; i <= sec; i += Time.deltaTime)
            {
                // set color with i as alpha
                imgSelf.color = new Color(1, 1, 1, i / sec);
                yield return null;
            }
        }
        else
        {
           // loop over 1 second backwards
            for (float i = sec; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                imgSelf.color = new Color(1, 1, 1, i / sec);
                yield return null;
            }
        }
    }

    IEnumerator ScaleTransform(float first, float last, float sec)
    {
        for (float i = 0; i <= sec; i += Time.deltaTime)
        {
            transform.localScale = new Vector3(first + i / sec * (last-first), first + i / sec * (last - first), first + i / sec * (last - first));
            yield return null;
        }
    }

    IEnumerator FadePanel(bool fadeIn, float sec)
    {
        CanvasGroup trans = transform.GetComponent<CanvasGroup>();

        if (fadeIn)
        {
            for (float i = 0; i <= sec; i += Time.deltaTime)
            {
                trans.alpha = i / sec;
                yield return null;
            }
        } else {
            for (float i = sec; i >= 0; i -= Time.deltaTime)
            {
            
                trans.alpha = i / sec;
                yield return null;
            }

            trans.alpha = 0;
        }
    }

    IEnumerator FadeBlack(bool fadeIn, float degree, float sec)
    {
        if (fadeIn)
        {            // loop over 1 second
            for (float i = 0; i <= sec; i += Time.deltaTime)
            {
                // set color with i as alpha
                imgSelf.color = new Color(0, 0, 0, i / sec * degree);
                yield return null;
            }
        }
        else
        {
            // loop over 1 second backwards
            for (float i = sec; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                imgSelf.color = new Color(0, 0, 0, i / sec * degree);
                yield return null;
            }
        }
    }

    IEnumerator TranslateTransform(Vector3 diff, float sec)
    {
        Vector3 first = transform.localPosition;

        for (float i = 0; i <= sec; i += Time.deltaTime)
        {
            transform.localPosition = first + i/sec * (diff);
            
            yield return null;
        }
    }

}
