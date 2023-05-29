using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private static readonly int Happy = Animator.StringToHash(name: "happy");
    private static readonly int Dance = Animator.StringToHash(name: "dance");
    private static readonly int Walk = Animator.StringToHash(name: "isWalking");

    public void PlayHappy()
    {
        animator.SetTrigger(Happy);
    }

    public void PlayDance()
    {
        animator.SetTrigger(Dance);
    }
    public void isWalking(bool condition)
    { 
        animator.SetBool(Walk, condition);
    }
}
