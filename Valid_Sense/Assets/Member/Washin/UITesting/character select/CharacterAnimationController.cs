using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum characterAnimationClips
{
    idle,
    attack,
    choice,
    hit,
    win
}


public class CharacterAnimationController : MonoBehaviour
{
    Animator animator;
    [SerializeField] Player player;
    [SerializeField] string attAnimation;
    [SerializeField] string choiceAnimation;
    [SerializeField] string hitAnimation;
    [SerializeField] string idleAnimation;
    [SerializeField] string winAnimation;

    public static CharacterAnimationController InstancePlayer1;
    public static CharacterAnimationController InstancePlayer2;

    private void Awake()
    {
        if (player == Player.Player1) { InstancePlayer1 = this; Debug.Log("Player1 instanceSet"); }
        if (player == Player.Player2) { InstancePlayer2 = this; Debug.Log("Player2 instanceSet"); }
    }

    void OnEnable()
    {
        if (player == Player.Player1) { InstancePlayer1 = this; Debug.Log("Player1 instanceSet"); }
        if (player == Player.Player2) { InstancePlayer2 = this; Debug.Log("Player2 instanceSet"); }
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimationOnCharacter(characterAnimationClips animationName)
    {
        switch (animationName)
        {
            case characterAnimationClips.idle:
                animator.Play(idleAnimation);
                break;
            case characterAnimationClips.attack:
                animator.Play(attAnimation);
                break;
            case characterAnimationClips.choice:
                animator.Play(choiceAnimation);
                break;
            case characterAnimationClips.hit:
                animator.Play(hitAnimation);
                break;
            case characterAnimationClips.win:
                animator.Play(winAnimation);
                break;
            default:
                Debug.Log("Animation Clip Does Not Exists");
                break;
        };
    }

    public void Testing()
    {
        Debug.Log("Test");
    }
}
