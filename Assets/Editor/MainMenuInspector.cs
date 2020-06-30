using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MainMenu))]
public class MainMenuInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MainMenu m = (MainMenu)target;
        if (GUILayout.Button(m.menuLayouts[(int)m.orientation]))
        {
            m.ChangeMenuOrientation();
        }

    }
}
