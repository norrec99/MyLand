using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void ManageAnimations(Vector3 movement)
    {
        if (movement.magnitude > 0)
        {
            PlayRunAnim();
            //Turn player towards movement direction;
            animator.transform.forward = movement.normalized;
        }
        else
        {
            PlayIdleAnim();
        }
    }
    private void PlayRunAnim()
    {
        animator.Play("Run");
    }
    private void PlayIdleAnim()
    {
        animator.Play("Idle");
    }
}
