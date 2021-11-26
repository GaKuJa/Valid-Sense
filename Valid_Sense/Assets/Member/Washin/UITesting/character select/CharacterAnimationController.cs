using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    Animator animator;
    [SerializeField] Player player;
    public static CharacterAnimationController InstancePlayer1;
    public static CharacterAnimationController InstancePlayer2;

    private void Awake()
    {
        if (player == Player.Player1) { InstancePlayer1 = this; Debug.Log("Player1 instanceSet"); }
        if (player == Player.Player2) { InstancePlayer2 = this; Debug.Log("Player2 instanceSet"); }
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimationOnCharacter(string animationName)
    {
        animator.Play(animationName);
    }

    public void Testing()
    {
        Debug.Log("Test");
    }
}
