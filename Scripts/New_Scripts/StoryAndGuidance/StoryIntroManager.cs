using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StoryIntroManager : SurMonoBehaviour
{
    public float delayBetweenObjects = 3f;
    public float delayBetweenIntros = 3f;
    [SerializeField] protected bool isObjFinished = true;

    protected override void Reset()
    {
        base.Reset();

        // Deactivate all children first
        foreach (Transform intro in this.transform)
        {
            intro.gameObject.SetActive(false);
            foreach (Transform child in intro)
            {
                child.gameObject.SetActive(false);

            }
        }
    }
    protected override void Start()
    {
        StartCoroutine(PlayIntroSequence());
    }

    protected virtual IEnumerator PlayIntroSequence()
    {
        foreach (Transform intro in this.transform)
        {
            intro.gameObject.SetActive(true);

            foreach (Transform child in intro)
            {
                child.gameObject.SetActive(true);

                Image img = child.GetComponent<Image>();

                if (img != null)
                {
                    yield return StartCoroutine(FadeInImage(img, 1f)); // fade in trong 1 giây
                    yield return new WaitForSeconds(delayBetweenObjects);

                    continue;
                }

            }

            yield return new WaitForSeconds(this.delayBetweenIntros);
            intro.gameObject.SetActive(false);
        }

        if (this.isObjFinished) IntroduceStoryController.Instance.FinishedIntroduceStory();
    }

    protected IEnumerator FadeInImage(Image image, float duration)
    {
        Color color = image.color;
        color.a = 0f;
        image.color = color;

        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Clamp01(timer / duration);
            image.color = color;
            yield return null;
        }

        color.a = 1f;
        image.color = color;

    }
}



/*
 *  public float delayBetweenObjects = 2f;
    public float delayBetweenIntros = 3f;

    protected override void Reset()
    {
        base.Reset();

        // Deactivate all children first
        foreach (Transform intro in this.transform)
        {
            intro.gameObject.SetActive(false);
            foreach (Transform child in intro)
            {
                child.gameObject.SetActive(false);

            }
        }
    }
    protected override void Start()
    {
        StartCoroutine(PlayIntroSequence());
    }

    protected virtual IEnumerator PlayIntroSequence()
    {
        // Duyệt tất cả các Intro (Intro_01, Intro_02, ...)
        foreach (Transform intro in this.transform)
        {
            intro.gameObject.SetActive(true);
            // Hiển thị từng object con của Intro này
            foreach (Transform child in intro)
            {
                child.gameObject.SetActive(true);

                yield return new WaitForSeconds(delayBetweenObjects);
            }
            // Đợi trước khi chuyển sang Intro kế tiếp
            yield return new WaitForSeconds(delayBetweenIntros);
            intro.gameObject.SetActive(false);
        }
    }
*/