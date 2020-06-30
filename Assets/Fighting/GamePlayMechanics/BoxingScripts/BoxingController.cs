using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingController : MonoBehaviour
{
    public float HorizontalMove,VerticalMove;
    public bool Jab,Hook,UpperCut,Block;
    public Animator animator;
    public float offTime=0.25f;
    public Transform target;
    public GameObject HitParticles;
 
    void Update()
    {
        Vector3 direction=target.position-transform.position;
        Quaternion rotation=Quaternion.LookRotation(direction);
        transform.rotation=rotation;
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
        if(Input.GetKeyDown(KeyCode.U))
        {
            Jab=true;
        }
        if(Input.GetKey(KeyCode.I))
        {
            Hook=true;
        }
        if(Input.GetKey(KeyCode.J))
        {
            UpperCut=true;
        }
        if(Input.GetKey(KeyCode.K))
        {
            Block=true;
        }
        if(PlayerHitDetecter.UpperLeftHit)
        {
            animator.SetBool("UpperLeftHit",true);
            HitParticles.SetActive(true);
            Invoke("StopHit",offTime);
        }
        if(!PlayerHitDetecter.UpperLeftHit)
        {
            animator.SetBool("UpperLeftHit",false);
        }
         if(PlayerHitDetecter.UpperRightHit)
        {
            animator.SetBool("UpperRightHit",true);
            HitParticles.SetActive(true);
            Invoke("StopHit",offTime);
        }
        if(!PlayerHitDetecter.UpperRightHit)
        {
            animator.SetBool("UpperRightHit",false);
        }
        if(PlayerHitDetecter.UpperCutChinHit)
        {
            animator.SetBool("UpperCutChinHit",true);
            HitParticles.SetActive(true);
            Invoke("StopHit",offTime);
        }
        if(!PlayerHitDetecter.UpperCutChinHit)
        {
            animator.SetBool("UpperCutChinHit",false);
        }
                if(PlayerHitDetecter.UpperRightRHit)
        {
            animator.SetBool("UpperRightRHit",true);
            HitParticles.SetActive(true);
            Invoke("StopHit",offTime);
        }
        if(!PlayerHitDetecter.UpperRightRHit)
        {
            animator.SetBool("UpperRightRHit",false);
        }
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
        if(Jab)
        {
            animator.SetBool("Jab",true);
            Invoke("StopJab",offTime);
        }
        if(!Jab)
        {
            animator.SetBool("Jab",false);
        }

        if(Hook)
        {
            animator.SetBool("Hook",true);
            Invoke("StopHook",offTime);
        }
        if(!Hook)
        {
            animator.SetBool("Hook",false);
        }

        if(UpperCut)
        {
            animator.SetBool("UpperCut",true);
            Invoke("StopUpperCut",offTime);
        }
        if(!UpperCut)
        {
            animator.SetBool("UpperCut",false);
        }
        if(Block)
        {
            animator.SetBool("Block",true);
            Invoke("StopBlock",offTime);
        }
        if(!Block)
        {
            animator.SetBool("Block",false);
        }
    }

    void StopJab()
    {

        //animator.SetBool("UpperLeftHit",false);
        //animator.SetBool("UpperRightHit",false);
        Jab=false;
    }
    void StopHook()
    {
        Hook=false;
    }
    void StopUpperCut()
    {
        UpperCut=false;
    }
    void StopBlock()
    {
        Block=false;
    }
    void StopHit()
    {
        if(HitParticles)
        {
            HitParticles.SetActive(false);
        }
        PlayerHitDetecter.UpperLeftHit=false;
        PlayerHitDetecter.UpperRightHit=false;
        PlayerHitDetecter.UpperCutChinHit=false;
        PlayerHitDetecter.UpperRightRHit=false;
    }

}
