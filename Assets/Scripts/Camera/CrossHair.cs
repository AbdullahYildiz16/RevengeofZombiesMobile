﻿
using UnityEngine;


public class CrossHair : MonoBehaviour
{
    
    public Texture2D crosshair;
    
    void OnGUI()
    {

        GUI.Label(new Rect(Screen.width / 2 - 25, Screen.height / 2 - 25, 50, 50), crosshair);
    }
    
}
