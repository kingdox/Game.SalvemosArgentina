using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimation : MonoBehaviour
{
    public Animator ballsAnimator;
    public Animator fadeAnimator;
    public Animator maradona;
    public PlayerIntroEntity playerEntity;
    public GameObject lastDialogue;

    private void Start() {
        lastDialogue.SetActive(false);
    }

    [ContextMenu("StartEndAnimation")]
    public void StartEndAnimation() {
        StartCoroutine(EndAnimationCorroutine());
    }

    public IEnumerator EndAnimationCorroutine() {
        playerEntity.enabledControls = false;
        ballsAnimator.gameObject.SetActive(true);
        ballsAnimator.SetTrigger("StartAnimation");
        yield return new WaitForSeconds(4f);
        fadeAnimator.SetTrigger("FadeBlack");
        yield return new WaitForSeconds(2f);
        AudioSystem.PlaySound(GeneralSounds.MARADON_2);
        yield return new WaitForSeconds(2f);
        fadeAnimator.SetTrigger("Fade0Alpha");
        maradona.SetTrigger("StartVibrating");
        yield return new WaitForSeconds(4f);
        AudioSystem.PlaySound(GeneralSounds.ANGELS);
        yield return new WaitForSeconds(4f);
        playerEntity.enabledControls = true;
        lastDialogue.SetActive(true);
    }
}
