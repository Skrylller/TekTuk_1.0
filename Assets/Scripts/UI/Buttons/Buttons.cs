using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buttons : MonoBehaviour
{
    private Animator _ButtonAnimator;

    public void Inicializate()
    {
        _ButtonAnimator = GetComponent<Animator>();
        SetAnimator(_ButtonAnimator);
        SetText();
    }

    public void OnButtonDown()
    {
        SetAnimation(true);
    }

    public void OnButtonUp()
    {
        SetAnimation(false);
    }

    public void OnButtonExit()
    {
        SetAnimation(false);
    }

    public void SetAnimation(bool value)
    {
        _ButtonAnimator.SetBool("isTouch", value);
    }

    private void SetAnimator(Animator animatior)
    {
        _ButtonAnimator = animatior;
    }

    public abstract void SetText();
}
