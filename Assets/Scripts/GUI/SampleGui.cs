using UnityEngine;
using System.Collections;
using System;

public class SampleGui : MonoBehaviour 
{
    public Texture texture;
    
    void OnGUI()
    {
        //Sample();
        
        //LabelAndBox();
        
        //ButtonAndRepeatButton();
        
        //TextFieldAndTextAreaAndPasswordField();
        
        //ToggleAndToolbarAndSelectionGrid();
        
        //SliderAndScrollbar();
        
        //Window();
        
        //Layout();
        
        //Layout2();
        
        //Layout3();
        
        //Layout4();
        
        //Layout5();
    }


    void Sample()
    {
        GUI.Label(new Rect(10, 10, 100, 40), "Label");
        
        if(GUI.Button(new Rect(10, 50, 100, 50), "Button"))
        {
            Debug.Log("Push Button");
        }
    }
    
    void LabelAndBox()
    {
        // Label
        GUI.Label(new Rect(10, 10, 50, 50), "Label");
        GUI.Label(new Rect(10, 70, 50, 50), texture);
        GUI.Label(new Rect(10, 130, 100, 50), new GUIContent("Label", texture));
        
        // Box    
        GUI.Box(new Rect(100, 10, 50, 50), "Box");
        GUI.Box(new Rect(100, 70, 50, 50), texture);
        GUI.Box(new Rect(100, 130, 100, 50), new GUIContent("Box", texture));
    }


    void ButtonAndRepeatButton()
    {
        // Button
        if(GUI.Button(new Rect(10, 10, 50, 50), "Button"))
        {
            Debug.Log("Push Button 1");
        }
    
        if(GUI.Button(new Rect(10, 70, 50, 50), texture))
        {
            Debug.Log("Push Button 2");
        }
        
        if(GUI.Button(new Rect(10, 130, 100, 50), new GUIContent("Button", texture)))
        {
            Debug.Log("Push Button 3");
        }
        
        // Repeat Button
        if(GUI.RepeatButton(new Rect(160, 10, 50, 50), "RepeatButton"))
        {
            Debug.Log("Push RepeatButton 1");
        }
    
        if(GUI.RepeatButton(new Rect(160, 70, 50, 50), texture))
        {
            Debug.Log("Push RepeatButton 2");
        }
        
        if(GUI.RepeatButton(new Rect(160, 130, 100, 50), new GUIContent("RepeatButton", texture)))
        {
            Debug.Log("Push RepeatButton 3");
        }
    }
    
    string textFieldText = "TextField";
    string textAreaText = "TextArea";
    string passwordFieldText = "PasswordField";
    char maskChar = '*';
    
    void TextFieldAndTextAreaAndPasswordField()
    {
        textFieldText = GUI.TextField(new Rect(10, 10, 100, 30), textFieldText);
        textAreaText = GUI.TextArea(new Rect(10, 50, 100, 80), textAreaText);
        passwordFieldText = GUI.PasswordField(new Rect(10, 140, 100, 30), passwordFieldText, maskChar);
    }
    
    bool toggleValue = true;
    
    int toolbarSelected = 0;
    string[] toolbarTexts = { "Toolbar1", "Toolbar2", "Toolbar3" };
    
    int gridSelected = 0;
    string[] gridTexts = { "Grid1", "Grid2", "Grid3", "Grid4", "Grid5" };
    int gridXCount = 3;
    
    void ToggleAndToolbarAndSelectionGrid()
    {
        toggleValue = GUI.Toggle(new Rect(10, 10, 100, 30), toggleValue, "Toggle");
        toolbarSelected = GUI.Toolbar(new Rect(10, 50, 200, 80), toolbarSelected, toolbarTexts);
        gridSelected = GUI.SelectionGrid(new Rect(10, 140, 200, 80),
        gridSelected, gridTexts, gridXCount );
    }
    
    float hSliderValue = 0f;
    float hScrollbarValue = 0f;
    float vSliderValue = 0f;
    float vScrollbarValue = 0f;
    float leftValue = 0f;
    float rightValue = 1f;
    float topValue = 0f;
    float bottomValue = 1f;
    float size = 0.1f;
    
    void SliderAndScrollbar()
    {
        hSliderValue = GUI.HorizontalSlider(new Rect(10, 10, 100, 30), 
            hSliderValue, leftValue, rightValue);
        
        hScrollbarValue = GUI.HorizontalScrollbar(new Rect(10, 50, 100, 30), 
            hScrollbarValue, size, leftValue, rightValue);
        
        vSliderValue = GUI.VerticalSlider(new Rect(120, 10, 30, 100), 
            vSliderValue, topValue, bottomValue);
        
        vScrollbarValue = GUI.VerticalScrollbar(new Rect(160, 10, 30, 100), 
            vScrollbarValue, size, topValue, bottomValue);
    }
    
    int windowId = 0;
    Rect windowRect = new Rect(10, 10, 300, 100);
    
    void Window()
    {
        windowRect = GUI.Window(windowId, windowRect, WindowFunction, "Window");
    }
    
    void WindowFunction(int window_id)
    {
        GUI.DragWindow();
        GUI.Label(new Rect(10, 30, 150, 20), "Hello Window");
    }
    
    
    void Layout()
    {
        GUILayout.Label("Label");
        
        if(GUILayout.Button("Button"))
        {
            Debug.Log("Push Button");
        }
    }
    
    void Layout2()
    {
        GUILayout.Label("Label");
        GUILayout.BeginHorizontal();
        GUILayout.Box("Box1");
        GUILayout.Box("Box2", GUILayout.Width(100));
        GUILayout.Box("Box3");
        GUILayout.EndHorizontal();
        
        if(GUILayout.Button("Button"))
        {
            Debug.Log("Push Button");
        }
        
        textAreaText = GUILayout.TextArea(textAreaText, 
            GUILayout.Width(100), GUILayout.Height(200));
    }
    
    void Layout3()
    {
        // GUI
        GUI.BeginGroup(new Rect(170, 10, 150, 150));
        GUI.Box(new Rect(10, 10, 130, 25), "GUI BeginGroup");
        textAreaText = GUI.TextArea(new Rect(10, 40, 200, 200), textAreaText);
        GUI.EndGroup();
        
        // GUILayout
        GUILayout.BeginArea(new Rect(10, 150, 150, 150));
        GUILayout.Box("GUILayout BeginArea");
        textAreaText = GUILayout.TextArea(textAreaText, GUILayout.Width(200), GUILayout.Height(200));
        GUILayout.EndArea();
    }
    
    Vector2 guiScrollPosition = Vector2.zero;
    Vector2 guilayoutScrollPosition = Vector2.zero;
    Rect viewRect = new Rect(0, 0, 200, 200);
   
    void Layout4()
    {
        guiScrollPosition = GUI.BeginScrollView(new Rect(170, 10, 150, 150),
                                guiScrollPosition, viewRect);
        GUI.Box(new Rect(10, 10, 130, 25), "GUI BeginGroup");
        textAreaText = GUI.TextArea(new Rect(10, 40, 200, 200), textAreaText);
        GUI.EndScrollView();
        
        GUILayout.BeginArea(new Rect(10, 150, 150, 150));
        guilayoutScrollPosition = GUILayout.BeginScrollView(guilayoutScrollPosition,
                                    GUILayout.Width(150), GUILayout.Height(150));
        GUILayout.Box("GUILayout BeginArea");
        textAreaText = GUILayout.TextArea(textAreaText, GUILayout.Width(200), GUILayout.Height(200));
        GUILayout.EndScrollView();
        GUILayout.EndArea();
    }
    
    void Layout5()
    {
        GUI.matrix = Matrix4x4.TRS(
            Vector3.zero,
            Quaternion.identity,
            new Vector3(Screen.width / 480.0f, Screen.height / 360.0f, 1f)
        );
        
        guiScrollPosition = GUI.BeginScrollView(new Rect(170, 10, 150, 150),
                                guiScrollPosition, viewRect);
        GUI.Box(new Rect(10, 10, 130, 25), "GUI BeginGroup");
        textAreaText = GUI.TextArea(new Rect(10, 40, 200, 200), textAreaText);
        GUI.EndScrollView();
        
        GUILayout.BeginArea(new Rect(10, 150, 150, 150));
        guilayoutScrollPosition = GUILayout.BeginScrollView(guilayoutScrollPosition,
                                    GUILayout.Width(150), GUILayout.Height(150));
        GUILayout.Box("GUILayout BeginArea");
        textAreaText = GUILayout.TextArea(textAreaText, GUILayout.Width(200), GUILayout.Height(200));
        GUILayout.EndScrollView();
        GUILayout.EndArea();
    }
}
