using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimation : MonoBehaviour
{
    public Animator ballsAnimator;
    public Animator fadeAnimator;

    GeneralSounds gs;

    [ContextMenu("StartEndAnimation")]
    public void StartEndAnimation() {
        StartCoroutine(EndAnimationCorroutine());
    }

    public IEnumerator EndAnimationCorroutine() {
        ballsAnimator.gameObject.SetActive(true);
        ballsAnimator.SetTrigger("StartAnimation");
        yield return new WaitForSeconds(4f);
        fadeAnimator.SetTrigger("FadeBlack");
        yield return new WaitForSeconds(4f);
        fadeAnimator.SetTrigger("Fade0Alpha");
    }
}
