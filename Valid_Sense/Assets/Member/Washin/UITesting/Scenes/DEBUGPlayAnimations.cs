using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUGPlayAnimations : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string attAnimation;
    [SerializeField] string choiceAnimation;
    [SerializeField] string hitAnimation;
    [SerializeField] string idleAnimation;
    [SerializeField] string winAnimation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) PlayAnimation(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) PlayAnimation(2);
        if (Input.GetKeyDown(KeyCode.Alpha3)) PlayAnimation(3);
        if (Input.GetKeyDown(KeyCode.Alpha4)) PlayAnimation(4);
    }

    private void PlayAnimation(int animationNumber)
    {
        switch (animationNumber)
        {
            case 0:
                animator.Play(idleAnimation);
                break;
            case 1:
                animator.Play(attAnimation);
                break;
            case 2:
                animator.Play(choiceAnimation);
                break;
            case 3:
                animator.Play(hitAnimation);
                break;
            case 4:
                animator.Play(winAnimation);
                break;
            default:
                Debug.Log("Animation Clip Does Not Exists");
                break;
        };
    }

}
