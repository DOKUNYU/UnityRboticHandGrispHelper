using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public TMP_Dropdown COM;
    
    //单例
    private static UIControl _instance;
        
    public static UIControl Instance()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<UIControl>();
        }
        return _instance;
    }
    private void Awake()
    {
        //COM.ClearOptions();
    }
    
    public void SetCom(string[] portArray)
    {
        if(COM.options!=null)COM.ClearOptions();
        List<string> port = new List<string>(portArray);
        if (port != null)
        {
            COM.AddOptions(port);
            //Debug.Log(port[0]);
        }
        //Debug.Log(COM.options[0].text);
        // Debug.Log(COM.name);
        // Debug.Log(COM.options.Count);
    }
 
    public string GetCom()
    {
        return COM.captionText.text;
    }
}
