using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void SelectButtonBool(string animatorParameter) {
        animator.SetBool(animatorParameter,true);
    }

    public void DeselectButtonBool(string animatorParameter) {
        animator.SetBool(animatorParameter,false);
    }
}
