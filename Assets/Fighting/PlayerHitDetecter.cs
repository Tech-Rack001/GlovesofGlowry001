using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitDetecter : StateMachineBehaviour
{
    public static bool UpperLeftHit,UpperRightHit,UpperCutChinHit,UpperRightRHit=false;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("LeftJabs")||animator.GetCurrentAnimatorStateInfo(0).IsName("LeftHook"))
        {
            UpperLeftHit=true;
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("RightJabs")||animator.GetCurrentAnimatorStateInfo(0).IsName("RightHook"))
        {
            UpperRightHit=true;
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("UpperCutLeft 0")||animator.GetCurrentAnimatorStateInfo(0).IsName("UpperCutRight 0"))
        {
            UpperCutChinHit=true;
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("UpperCutRight"))
        {
            UpperRightRHit=true;
        }

        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
