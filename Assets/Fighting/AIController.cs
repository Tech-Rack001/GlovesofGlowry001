using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
   
    public float HorizontalMove,VerticalMove;
    public bool Jab,Hook,UpperCut,Block,Hit,ActiveControlls;
    public Animator animator;
    public float offTime=0.25f;
    public Transform target;
    public GameObject HitParticles;
    public int Health=5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("Helatsssss"+Health);
        Vector3 direction=target.position-transform.position;
        Quaternion rotation=Quaternion.LookRotation(direction);
        transform.rotation=rotation;
        //Movements


        if(ActiveControlls)
        {
            AIFunctions.IsActive=ActiveControlls;
/////////////////////Movements
            if(Input.GetAxis("Horizontal")>0)
            {
                HorizontalMove=Input.GetAxis("Horizontal");
            }
            if(Input.GetAxis("Horizontal")<0)
            {
            HorizontalMove=Input.GetAxis("Horizontal");
            }
            if(Input.GetAxis("Vertical")>0)
            {
                VerticalMove=Input.GetAxis("Vertical");
            }
            if(Input.GetAxis("Vertical")<0)
            {
                VerticalMove=Input.GetAxis("Vertical");
            }
/* 

            if(Input.GetKey(KeyCode.I))
            {
                Hook=true;
            }
            if(Input.GetKey(KeyCode.J))
            {
                UpperCut=true;
            } */

////////////LeftSideAnimationControls
             if(AIFunctions.DodgeL)
            {
                animator.SetBool("DuckL",true);
                Invoke("StopBlock",offTime);
            }
            if(!AIFunctions.DodgeL)
            {
                animator.SetBool("DuckL",false);
            }
            if(AIFunctions.BlockUL)
            {
                animator.SetBool("BlockUL",true);
                Invoke("StopBlock",offTime);
            }
            if(!AIFunctions.BlockUL)
            {
                animator.SetBool("BlockUL",false);
            }
            if(AIFunctions.HitUNL)
            {    
                Health=Health-1;
                if(Health<=0)
                {
                    animator.SetBool("KOLeftUp",true);
                }
                else
                {
                                animator.SetBool("HitUNL",true);
                HitParticles.SetActive(true);
                Invoke("StopBlock",offTime);
                }

            }
            if(!AIFunctions.HitUNL)
            {
                animator.SetBool("HitUNL",false);
            } 
            if(AIFunctions.HitUHL)
            {
                animator.SetBool("HitUHL",true);
                HitParticles.SetActive(true);
                Invoke("StopBlock",offTime);
            }
            if(!AIFunctions.HitUHL)
            {
                animator.SetBool("HitUHL",false);
            } 

            
            if(AIFunctions.HitML)
            {
                animator.SetBool("HitML",true);
                HitParticles.SetActive(true);
                Invoke("StopBlock",offTime);
            }
            if(!AIFunctions.HitML)
            {
                animator.SetBool("HitML",false);
            }

            if(AIFunctions.BlockML)
            {
                animator.SetBool("BlockML",true);
                //HitParticles.SetActive(true);
                Invoke("StopBlock",offTime);
            }
            if(!AIFunctions.BlockML)
            {
                animator.SetBool("BlockML",false);
            }

//////////////////RightSideAnimationsControls

             if(AIFunctions.DodgeR)
            {
                animator.SetBool("DuckR",true);
                Invoke("StopBlock",offTime);
            }
            if(!AIFunctions.DodgeR)
            {
                animator.SetBool("DuckR",false);
            }
            if(AIFunctions.BlockUR)
            {
                animator.SetBool("BlockUR",true);
                Invoke("StopBlock",offTime);
            }
            if(!AIFunctions.BlockUR)
            {
                animator.SetBool("BlockUR",false);
            }
            if(AIFunctions.HitUNR)
            {
                animator.SetBool("HitUNR",true);
                HitParticles.SetActive(true);
                Invoke("StopBlock",offTime);
            }
            if(!AIFunctions.HitUNR)
            {
                animator.SetBool("HitUNR",false);
            }

            if(AIFunctions.HitMR)
            {
                animator.SetBool("HitMR",true);
                HitParticles.SetActive(true);
                Invoke("StopBlock",offTime);
            }
            if(!AIFunctions.HitMR)
            {
                animator.SetBool("HitMR",false);
            }

            
            if(AIFunctions.BlockMR)
            {
                animator.SetBool("BlockMR",true);
                //HitParticles.SetActive(true);
                Invoke("StopBlock",offTime);
            }
            if(!AIFunctions.BlockMR)
            {
                animator.SetBool("BlockMR",false);
            }

/////////////////////CenterAnimationsControls


            if(AIFunctions.Dodge)
            {
                animator.SetBool("Duck",true);
                Invoke("StopBlock",offTime);
            }
            if(!AIFunctions.Dodge)
            {
                animator.SetBool("Duck",false);
            }
            if(AIFunctions.Block)
            {
                animator.SetBool("Block",true);
                Invoke("StopBlock",offTime);
            }
            if(!AIFunctions.Block)
            {
                animator.SetBool("Block",false);
            }

//////////////////Punches
            if(AIFunctions.HookUL)//&&!AIFunctions.DodgeL)
            {
                animator.SetBool("HookUL",true);
                Invoke("StopHook",offTime);
            }
            if(!AIFunctions.HookUL)
            {
                animator.SetBool("HookUL",false);
            }
            if(AIFunctions.UpperCutCL)//&&!AIFunctions.DodgeL)
            {
                animator.SetBool("UpperCutCL",true);
                Invoke("StopHook",offTime);
            }
            if(!AIFunctions.UpperCutCL)
            {
                animator.SetBool("UpperCutCL",false);
            }
                        if(AIFunctions.UpperCutCR)//&&!AIFunctions.DodgeL)
            {
                animator.SetBool("UpperCutCR",true);
                Invoke("StopHook",offTime);
            }
            if(!AIFunctions.UpperCutCR)
            {
                animator.SetBool("UpperCutCR",false);
            }
            if(AIFunctions.HookUR)//&&!AIFunctions.DodgeL)
            {
                animator.SetBool("HookUR",true);
                Invoke("StopHook",offTime);
            }
            if(!AIFunctions.HookUR)
            {
                animator.SetBool("HookUR",false);
            }

            if(AIFunctions.JabL)//&&!AIFunctions.DodgeL)
            { 
                animator.SetBool("JabL",true);
                Invoke("StopHook",offTime);
            }
            if(!AIFunctions.JabL)
            {
                animator.SetBool("JabL",false);
            }
            if(AIFunctions.JabR)//&&!AIFunctions.DodgeL)
            {
                animator.SetBool("JabR",true);
                Invoke("StopHook",offTime);
            }
            if(!AIFunctions.JabR)
            {
                animator.SetBool("JabR",false);
            }

                if(AIFunctions.UpperCutRR)//&&!AIFunctions.DodgeL)
            {
                animator.SetBool("UpperCutRR",true);
                Invoke("StopHook",offTime);
            }
            if(!AIFunctions.UpperCutRR)
            {
                animator.SetBool("UpperCutRR",false);
            }

        } 

        if(!ActiveControlls)
        {

            AIFunctions.IsActive=ActiveControlls;
            if(Input.GetAxis("Horizontal")>0)
            {
                HorizontalMove=Input.GetAxis("Horizontal");
            }
            if(Input.GetAxis("Horizontal")<0)
            {
                HorizontalMove=Input.GetAxis("Horizontal");
            }
            if(Input.GetAxis("Vertical")>0)
            {
                VerticalMove=Input.GetAxis("Vertical");
            }
            if(Input.GetAxis("Vertical")<0)
            {
                VerticalMove=Input.GetAxis("Vertical")*-1;
            }

        }

    }

    private void LateUpdate() {
        

    }

    private void FixedUpdate()
    {
        if(VerticalMove<0)
        {
            animator.SetFloat("VerticalAnm",VerticalMove);
        }
        if(VerticalMove>0)
        {
            animator.SetFloat("VerticalAnm",VerticalMove);
        }
        if(HorizontalMove<0)
        {
            animator.SetFloat("HorizonalAnm",HorizontalMove);
        }
        if(HorizontalMove>0)
        {
            animator.SetFloat("HorizonalAnm",HorizontalMove);
        }

    }


    void StopJab()
    {
        Jab=false;
    }
    void StopHook()
    {
        if(HitParticles)
        {
            HitParticles.SetActive(false);
        }
        Hook=false;

        AIFunctions.UpperCutCL=false;
        AIFunctions.UpperCutCR=false;
        AIFunctions.HookUL=false;
        AIFunctions.HookUR=false;
        AIFunctions.JabL=false;
        AIFunctions.JabR=false;   
        AIFunctions.UpperCutRR=false;
        
    }
    void StopUpperCut()
    {
        UpperCut=false;
    }
    void StopBlock()
    {
        if(HitParticles)
        {
            HitParticles.SetActive(false);
        }
        AIFunctions.Dodge=false;
        AIFunctions.DodgeL=false;
        AIFunctions.DodgeR=false;
        AIFunctions.Block=false;
        AIFunctions.BlockUL=false;
        AIFunctions.BlockUR=false;
        AIFunctions.HitUNL=false;
        AIFunctions.HitUNR=false;
        AIFunctions.HitUHL=false;
        AIFunctions.HitUHR=false;
        AIFunctions.HitML=false;
        AIFunctions.HitMR=false;
        AIFunctions.BlockMR=false;
        AIFunctions.BlockML=false;
    }
    void StopHit()
    {

    }

     void OnTriggerEnter(Collider other) 
    {
        if(other.tag=="Player")
        {
            ActiveControlls=true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag=="Player")
        {
            ActiveControlls=false;
        }
    }
}