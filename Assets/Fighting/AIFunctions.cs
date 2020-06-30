using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFunctions : StateMachineBehaviour
{

    public static bool DodgeL,DodgeR,JabL,JabR,HookUL,HookUR,HookML,HookMR,UpperCutRL,UpperCutRR,UpperCutCL,UpperCutCR,HitUNL,HitUNR,HitUHL,HitUHR,HitML,HitMR=false;
    public static bool BlockUL,BlockUR,BlockML,BlockMR,Dodge,Block,IsActive=false;
    int Chance=0;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
/*         HitUNL=false;
        BlockUL=false;
        JabL=false;
        DodgeL=false;
        HookUL=false; */
    } 

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Debug.Log("Animator  "+animator.GetCurrentAnimatorStateInfo(0).IsName("LeftJabs"));
        if(IsActive)
        {
            //if(animator.GetCurrentAnimatorStateInfo(0).IsName("Movements"))
            //{
            //    Chance=Random.Range(0,10);
            //    if(Chance<3)
            //    {
            //         JabL=true;
            //    }
            //    if(Chance>3&&Chance<8)
            //    {
            //        UpperCutRR=true;
            //    }
            //    else
            //    {
            //        UpperCutCR=true;
            //    }
            //}

            if(animator.GetCurrentAnimatorStateInfo(0).IsName("LeftJabs")||animator.GetCurrentAnimatorStateInfo(0).IsName("LeftHook"))
            {
                Chance=Random.Range(0,10);
                if(Chance<=2)
                {
                    HitUNL=true;
                }
                else if (Chance>2&&Chance<5)
                {
                    BlockUL=true;
                    JabL=true;
                }
                else
                {
                    DodgeL=true;
                    HookUL=true;
                }

            }
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("RightJab")||animator.GetCurrentAnimatorStateInfo(0).IsName("RightHook"))
            {
                Chance=Random.Range(0,10);
                if(Chance<=2)
                {
                    HitUNR=true;
                }
                else if (Chance>2&&Chance<5)
                {
                    BlockUR=true;
                    JabR=true;
                }
                else
                {
                    DodgeR=true;
                    HookUR=true;
                } 
            }

            if(animator.GetCurrentAnimatorStateInfo(0).IsName("UpperCutLeft 0"))
            {
                Chance=Random.Range(0,10);
                if(Chance<3)
                {
                    HitUHL=true;
                }
                if(Chance>3&&Chance<8)
                {
                    Dodge=true;
                    UpperCutRL=true;
                }
                else
                {
                    Block=true;
                    UpperCutCL=true;
                }
            }
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("UpperCutRight 0"))
            {
                Chance=Random.Range(0,10);
                if(Chance<3)
                {
                    HitUHL=true;
                }
                if(Chance>3&&Chance<8)
                {
                    Dodge=true;
                    UpperCutRR=true;
                }
                else
                {
                    Block=true;
                    UpperCutCR=true;
                }
            }

            if(animator.GetCurrentAnimatorStateInfo(0).IsName("UpperCutRight"))
            {
                UpperCutRR=true;
/*                 Chance=Random.Range(0,10);
                if(Chance<3)
                {
                    HitMR=true;
                }
                if(Chance>3&&Chance<8)
                {
                    BlockMR=true;
                    UpperCutRR=true;
                    //JabR=true;
                }
                else
                {
                    BlockMR=true;
                    HookUR=true;
                } */
            }

            if(animator.GetCurrentAnimatorStateInfo(0).IsName("UpperCutLeft"))
            {
/*                  Chance=Random.Range(0,10);
                if(Chance<3)
                {
                    HitML=true;
                }
                if(Chance>3&&Chance<8)
                {
                    BlockML=true;
                    //JabR=true;
                }
                else
                {
                    BlockML=true;
                    //HookUL=true;
                }  */
            }
        }
        
        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
