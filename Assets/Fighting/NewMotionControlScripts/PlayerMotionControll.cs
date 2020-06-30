using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotionControll : MonoBehaviour, HitInterface
{
	public static PlayerMotionControll instance;
	private ArrayList pressedKeys;
	public Animator animator;

	public float inpX, inpY;
	private HitInterface enemyHitResponse;

	public enum INPUT
	{
		//ACTIONS
		ACTION1 = KeyCode.U,
		ACTION2 = KeyCode.I,
		ACTION3 = KeyCode.J,
		ACTION4 = KeyCode.K
	}
	public static class Action
	{
		public enum ACTIONCODE
		{
			HOOK,
			JAB,
			UPPERCUT,
			BLOCK
		};

		public static readonly Dictionary<ACTIONCODE, INPUT[]> actions = new Dictionary<ACTIONCODE, INPUT[]>() {
			{ACTIONCODE.HOOK, new INPUT[] { INPUT.ACTION1 }},
			{ACTIONCODE.JAB, new INPUT[] { INPUT.ACTION2 }},
			{ACTIONCODE.UPPERCUT, new INPUT[] { INPUT.ACTION3 }},
			{ACTIONCODE.BLOCK, new INPUT[] { INPUT.ACTION4 }}
		};
    }
	private void resolve_action()
	{
		bool found;
		if (pressedKeys.Count > 0)
		{
			foreach (var action in Action.actions)
			{
				INPUT[] inp = action.Value;
				if (inp.Length > pressedKeys.Count)
					continue;
				ArrayList keys = pressedKeys.GetRange(0, inp.Length).Clone() as ArrayList;
				found = false;
				for (int i = 0; i < inp.Length; i++)
				{
					int ind = keys.IndexOf(inp[i]);
					if (ind != -1)
					{
						found = true;
						keys.RemoveAt(ind);
					}
					else { found = false; break; }
				}
				if (found == true)
				{
					pressedKeys.RemoveRange(0, inp.Length);
					print(action.Key);
					perform_action(action.Key);
				}
			}
		}
	}
	private void perform_action(Action.ACTIONCODE code)
	{
		switch (code)
		{
			case Action.ACTIONCODE.HOOK:
				enemyHitResponse.CurrentHit(new OpponentMotionControll.Action.OPERATION(
					OpponentMotionControll.Action.BASICOPERATIONS.HOOK, inpX, inpY));
				animator.SetBool("Hook", true);
				StartCoroutine(stopAction("Hook"));
				break;
			case Action.ACTIONCODE.JAB:
				enemyHitResponse.CurrentHit(new OpponentMotionControll.Action.OPERATION(
					OpponentMotionControll.Action.BASICOPERATIONS.JAB, inpX, inpY));
				animator.SetBool("Jab", true);
				StartCoroutine(stopAction("Jab"));
				break;
			case Action.ACTIONCODE.UPPERCUT:
				enemyHitResponse.CurrentHit(new OpponentMotionControll.Action.OPERATION(
					OpponentMotionControll.Action.BASICOPERATIONS.UPPERCUT, inpX, inpY));
				animator.SetBool("UpperCut", true);
				StartCoroutine(stopAction("UpperCut"));
				break;
			case Action.ACTIONCODE.BLOCK:
				animator.SetBool("Block", true);
				StartCoroutine(stopAction("Block"));
				break;
			default:
				break;
		}
	}
	private IEnumerator stopAction(string which)
	{
		yield return new WaitForSeconds(0.3f);
		animator.SetBool(which, false);
	}

	
	private void Awake()
	{
		animator = GetComponent<Animator>();
		pressedKeys = new ArrayList();
		instance = this;
	}
	private void Start()
	{
		enemyHitResponse = OpponentMotionControll.instance;
	}
	private void Update()
	{
		inpX = Input.GetAxis("Horizontal");
		inpY = Input.GetAxis("Vertical");
		foreach (var input in System.Enum.GetValues(typeof(INPUT)))
			if (Input.GetKey((KeyCode)input))
				pressedKeys.Add(input);

	}
	private void FixedUpdate()
	{
		//MOVEMENTS
		animator.SetFloat("HorizonalAnm", inpX);
		animator.SetFloat("VerticalAnm", inpY);

		//ACTIONS
		resolve_action();
	}

	public void CurrentHit(OpponentMotionControll.Action.OPERATION action)
	{
		switch (action.code)
		{
			case OpponentMotionControll.Action.BASICOPERATIONS.HOOK:
				if(action.x < -0.1f)
				{
					animator.SetBool("UpperLeftHit", true);
					StartCoroutine(stopAction("UpperLeftHit"));
				}
				else// if (action.x > 0.1f)
				{
					animator.SetBool("UpperRightHit", true);
					StartCoroutine(stopAction("UpperRightHit"));
				}
				break;
			case OpponentMotionControll.Action.BASICOPERATIONS.JAB:
				if (action.x < -0.1f)
				{
					animator.SetBool("UpperLeftHit", true);
					StartCoroutine(stopAction("UpperLeftHit"));
				}
				else// if (action.x > 0.1f)
				{
					animator.SetBool("UpperRightHit", true);
					StartCoroutine(stopAction("UpperRightHit"));
				}
				break;
			case OpponentMotionControll.Action.BASICOPERATIONS.UPPERCUT:
				if (action.x < -0.1f)
				{
					animator.SetBool("UpperCutChinHit", true);
					StartCoroutine(stopAction("UpperCutChinHit"));
				}
				else// if (action.x > 0.1f)
				{
					animator.SetBool("UpperRightRHit", false);
					StartCoroutine(stopAction("UpperRightRHit"));
				}
				break;			
			default:
				break;
		}
	}
}
