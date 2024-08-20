using System;
using UnityEngine;
using System.IO.Ports;
using System.Linq;

public class InuptManager : MonoBehaviour
{
    //变量
    Serial portManager;
    public UIControl Control;
    public string PresentCOM;
    private void Awake()
    {
        Screen.fullScreen = false;
        Control = UIControl.Instance();
        
        portManager = new Serial();
        string[] portArray = portManager.ScanPorts_TryFail();//使用试错函数，可以解决COM被占用问题
        portArray = Array.FindAll(portArray, i => i != "COM3" && i != "COM4").ToArray();
        if (portArray.Length != 0)
        {
            portManager.OpenSerialPort(portArray[0], 115200, Parity.None, 8, StopBits.One);
            Control.SetCom(portArray);
            PresentCOM = Control.GetCom();
        }
        
        
    }

    public void ClickAndSend(string idx)
    {
        portManager.SendData(idx);
        //Debug.Log("send "+idx);
    }

    public void OnDropChange()
    {
        portManager.CloseSerialPort();
        portManager.OpenSerialPort(Control.COM.options[Control.COM.value].text,115200,Parity.None,8,StopBits.One);
        //Debug.Log("change "+Control.COM.options[Control.COM.value].text);
    }
}
