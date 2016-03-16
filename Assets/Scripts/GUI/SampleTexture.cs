using UnityEngine;
using System.Collections;

public class SampleTexture : MonoBehaviour 
{
    public Texture texture;
    
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(10, 10, 64, 64), texture);
        Color gui_color = GUI.color;
        GUI.color = Color.red;
        GUI.DrawTexture(new Rect(80, 10, 64, 64), texture);
        GUI.color = Color.green;
        GUI.DrawTexture(new Rect(150, 10, 64, 64), texture);
    }
}
