using UnityEngine;
using System.Collections;

public class SampleGUIStyle : MonoBehaviour 
{
    public GUIStyle labelStyle;
    
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 50, 20), "Label");
        GUI.Label(new Rect(10, 40, 50, 20), "Label", labelStyle);
    }
}
