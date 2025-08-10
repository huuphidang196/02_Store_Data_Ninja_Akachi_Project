using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StoryIntroManager : SurMonoBehaviour
{
    public float delayBetweenObjects = 3f;
    public float delayBetweenIntros = 3f;
    public float delayTimeFadeIn = 1f;
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
                    yield return StartCoroutine(FadeInImage(img, this.delayTimeFadeIn)); // fade in trong 1 giây
                    yield return new WaitForSeconds(delayBetweenObjects);
                    this.ProcessAfterElementsFadeIn();
                    continue;
                }

            }

            yield return new WaitForSeconds(this.delayBetweenIntros);
            intro.gameObject.SetActive(false);
        }

        if (this.isObjFinished) this.FinishStory(); 
    }

    protected virtual void ProcessAfterElementsFadeIn()
    {
      
    }

    protected virtual void FinishStory()
    {
        IntroduceStoryController.Instance.FinishedIntroduceStory();
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
