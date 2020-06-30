using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerMotionControll))]
public class layerOpponentMotionControll : Editor
{
    PlayerMotionControll obj;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        obj = (PlayerMotionControll)target;
        if (GUILayout.Button("Get Hit Anim"))
        {
            obj.animator.SetBool("UpperLeftHit", true);
            obj.StartCoroutine(stopTrigger("UpperLeftHit"));            
        }

    }

    private IEnumerator stopTrigger(string which)
    {
        yield return new WaitForSeconds(0.2f);
        obj.animator.SetBool(which, false);
    }
}
