using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentMotionControll : MonoBehaviour, HitInterface  
{
    public static OpponentMotionControll instance;

    public GameObject target;
    public float FrameInterval;
    public float approchSpeed;
    public float minDistance;
    public bool correctionRequired;

    private float x, z;
    private int retrive_counter;
    private int retrive_counter_index;

    private Animator animator;
    private HitInterface enemyHitResponse;

    public static class Action
    {
        public enum BASICOPERATIONS
        {
            STOP,
            FORWARD,
            BACKWARD,
            LEFT,
            RIGHT,
            HOOK,
            JAB,
            UPPERCUT,
            BLOCK
        }
        public struct OPERATION
        {
            public BASICOPERATIONS code;
            public float x;
            public float z;
            public OPERATION(BASICOPERATIONS code, float x = 0.0f, float z = 0.0f)
            {
                this.code = code;
                this.x = x;
                this.z = z;
            }
        }
        static public class movement
        {
            static public OPERATION Vertical { get { return new OPERATION(BASICOPERATIONS.FORWARD, instance.x, instance.z); } }            
            static public OPERATION Horizontal { get { return new OPERATION(BASICOPERATIONS.RIGHT, instance.x, instance.z); } }            
            static public OPERATION Idle { get { return new OPERATION(BASICOPERATIONS.STOP, 0, 0); } }                        
        }
        public static readonly List<List<OPERATION>> defenses = new List<List<OPERATION>>() {
            new List<OPERATION>(){ 
                new OPERATION(BASICOPERATIONS.RIGHT, 0.7f, 0.0f),
                new OPERATION(BASICOPERATIONS.BLOCK)
            },

            new List<OPERATION>(){
                new OPERATION(BASICOPERATIONS.LEFT, -0.7f, 0.0f),
                new OPERATION(BASICOPERATIONS.BLOCK)
            }

        };
        public static readonly List<List<OPERATION>> offenses = new List<List<OPERATION>>() {
            new List<OPERATION>(){
                new OPERATION(BASICOPERATIONS.HOOK)
            },
            new List<OPERATION>(){
                new OPERATION(BASICOPERATIONS.JAB)
            },
            new List<OPERATION>(){
                new OPERATION(BASICOPERATIONS.UPPERCUT)
            },
            new List<OPERATION>(){
                new OPERATION(BASICOPERATIONS.UPPERCUT, 0.5f, 0.5f)
            },
             new List<OPERATION>(){
                new OPERATION(BASICOPERATIONS.UPPERCUT, -0.5f, 0.5f)
            },
              new List<OPERATION>(){
                new OPERATION(BASICOPERATIONS.JAB, 0.5f, 0.5f)
            },
             new List<OPERATION>(){
                new OPERATION(BASICOPERATIONS.JAB, -0.5f, 0.5f)
            }
        };

    }
    private IEnumerator _core_()
    {
        if (correctMotion())
        {
            var states = _random_offense_();
            foreach (var state in states)
            {
                enemyHitResponse.CurrentHit(state);
                _perform_(state);
            }

            //retrive section
            if (retrive_counter == retrive_counter_index)
            {
                retrive_counter_index = 0;
                retrive_counter = Random.Range(0, 3);
                _retrive_();
            }
            else
            {
                retrive_counter_index += 1;
            }
        }
        yield return new WaitForSeconds(FrameInterval);
        StartCoroutine(_core_());
    }
    
    private bool correctMotion()
    {
        if (!correctionRequired) return false;
        transform.LookAt(target.transform);
        if(Vector3.Distance(transform.position, target.transform.position) > minDistance)
        {
            x = Mathf.Lerp(transform.position.x, target.transform.position.x, approchSpeed);
            z = Mathf.Lerp(transform.position.z, target.transform.position.z, approchSpeed);            
            if (x >= 1) x = 1;
            else if (x <= -1) x = -1;
            if (z >= 1) z = 1;
            else if (z <= -1) z = -1;
            if (target.transform.position.z < 0 && z < 0)
                z *= -1;
            _perform_(Action.movement.Vertical);
            _perform_(Action.movement.Horizontal);
            return false;
        }
        else
        {
            _perform_(Action.movement.Idle);
            return true;
        }
    }
    private List<Action.OPERATION> _random_offense_()
    {
        return Action.offenses[Random.Range(0, Action.offenses.Count)];
    }
    private List<Action.OPERATION> _random_defense_()
    {
        return Action.defenses[Random.Range(0, Action.offenses.Count)];
    }
    private void _retrive_()
    {
        correctionRequired = false;
        StartCoroutine(_retriving_());
    }
    private IEnumerator _retriving_()
    {
        int distanceZ = 1;// Random.Range(1, 2);
        Vector3 curr = transform.position;
        z = -1;
        x = Random.Range(-1.0f, 2.0f);
        while (Vector3.Distance(curr, transform.position) < distanceZ)
        {
            _perform_(Action.movement.Vertical);
            _perform_(Action.movement.Horizontal);
            yield return new WaitForSeconds(FrameInterval);
        }

        _perform_(Action.movement.Idle);
        correctionRequired = true;
    }
    private void _perform_(Action.OPERATION opr)
    {
        switch (opr.code)
        {
            case Action.BASICOPERATIONS.STOP:
                animator.SetFloat("VerticalAnm", 0);
                animator.SetFloat("HorizonalAnm", 0);
                break;
            case Action.BASICOPERATIONS.FORWARD:
            case Action.BASICOPERATIONS.BACKWARD:
                animator.SetFloat("VerticalAnm", opr.z);
                StartCoroutine(stopMovment("VerticalAnm"));
                break;
            case Action.BASICOPERATIONS.LEFT:
            case Action.BASICOPERATIONS.RIGHT:
                animator.SetFloat("HorizonalAnm", opr.x);
                StartCoroutine(stopMovment("HorizonalAnm"));
                break;
            case Action.BASICOPERATIONS.HOOK:
                animator.SetBool("Hook", true);
                StartCoroutine(stopTrigger("Hook"));
                break;
            case Action.BASICOPERATIONS.JAB:
                animator.SetBool("Jab", true);
                StartCoroutine(stopTrigger("Jab"));
                break;
            case Action.BASICOPERATIONS.UPPERCUT:
                animator.SetBool("UpperCut", true);
                StartCoroutine(stopTrigger("UpperCut"));
                break;
            case Action.BASICOPERATIONS.BLOCK:
                animator.SetBool("Block", true);
                StartCoroutine(stopTrigger("Block"));
                break;
            default:
                break;
        }
        if (opr.x != 0)
        {
            animator.SetFloat("HorizonalAnm", opr.x);
        }
        if (opr.z != 0)
        {
            animator.SetFloat("VerticalAnm", opr.z);
        }
    }
    public IEnumerator stopTrigger(string which)
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetBool(which, false);
    }
    private IEnumerator stopMovment(string which)
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetFloat(which, Mathf.Lerp(animator.GetFloat(which), 0, 0.2f));
    }
    private void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
        enemyHitResponse = target.GetComponent<PlayerMotionControll>();
    }
    private void Start()
    {
        retrive_counter = Random.Range(0, 3);
        StartCoroutine(_core_());
    }

    public void CurrentHit(Action.OPERATION action)
    {
        print(action.code + ":" + action.x + ":" + action.z);
        switch (action.code)
        {
            case Action.BASICOPERATIONS.HOOK:
                if (action.x < -0.1f)
                {
                    animator.SetBool("UpperLeftHit", true);
                    StartCoroutine(stopTrigger("UpperLeftHit"));
                    print("success");
                }
                else// if (action.x > 0.1f)
                {
                    animator.SetBool("UpperRightHit", true);
                    StartCoroutine(stopTrigger("UpperRightHit"));
                    print("success");
                }

                break;
            case Action.BASICOPERATIONS.JAB:
                if (action.x < -0.1f)
                {
                    animator.SetBool("UpperLeftHit", true);
                    StartCoroutine(stopTrigger("UpperLeftHit"));
                    print("success");
                }
                else// if (action.x > 0.1f)
                {
                    animator.SetBool("UpperRightHit", true);
                    StartCoroutine(stopTrigger("UpperRightHit"));
                    print("success");
                }

                break;
            case Action.BASICOPERATIONS.UPPERCUT:
                if (action.x < -0.1f)
                {
                    animator.SetBool("UpperCutChinHit", true);
                    StartCoroutine(stopTrigger("UpperCutChinHit"));
                    print("success");
                }
                else// if (action.x > 0.1f)
                {
                    animator.SetBool("UpperRightRHit", false);
                    StartCoroutine(stopTrigger("UpperRightRHit"));
                    print("success");
                }

                break;
            default:
                break;
        }
    }
}
