using UnityEngine;
using System.Collections;

public class SampleGUISkin : MonoBehaviour 
{
    public GUISkin sampleSkin;
    
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 150, 40), "Label");
        
        GUI.skin = sampleSkin;
        GUI.Label(new Rect(10, 30, 150, 40), "Label Skin");
        GUI.skin = null;
        
        GUI.Label(new Rect(10, 70, 150, 40), "Label");
    }

}
