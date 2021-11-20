using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAnimationController : MonoBehaviour
{
    [SerializeField] KeyCode idle;
    [SerializeField] KeyCode attack;
    [SerializeField] KeyCode hit;
    [SerializeField] KeyCode select;
    [SerializeField] KeyCode win;
    [SerializeField] List<Animator> modelAnimatorList;

    public void CheckForInput()
    {
        if (Input.GetKeyDown(idle))
        {
            PlayAnimations("idle");
        }
        if (Input.GetKeyDown(attack))
        {
            PlayAnimations("idle");
        }
        if (Input.GetKeyDown(hit))
        {
            PlayAnimations("idle");
        }
        if (Input.GetKeyDown(select))
        {
            PlayAnimations("idle");
        }
        if (Input.GetKeyDown(win))
        {
            PlayAnimations("idle");
        }
    }

    void PlayAnimations(string animationName)
    {
        foreach (Animator animator in modelAnimatorList)
        {
            animator.Play(animationName);
        }
    }
}
