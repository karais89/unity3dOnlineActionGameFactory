using UnityEngine;
using System.Collections;
using System;

public class PlayerCtrl : MonoBehaviour 
{
    const float RaycastMaxDistance = 100.0f;
    InputManager inputManager;
   
	// Use this for initialization
	void Start () 
    {
        inputManager = FindObjectOfType<InputManager>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    Walking();
	}

    void Walking()
    {
        if(inputManager.Clicked())
        {
            Vector2 clickPos = inputManager.GetCursorPosition();
            // Raycast로 대상물을 조사한다.
            Ray ray = Camera.main.ScreenPointToRay(clickPos);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo, RaycastMaxDistance, 1 << LayerMask.NameToLayer("Ground")))
            {
                SendMessage("SetDestination", hitInfo.point);
            }
        }
    }
}
