using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.InteropServices;


public class PsyanimJSInterface : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SayHello();

    [DllImport("__Internal")]
    private static extern void SendCustomEventMessage(string message);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SayHello();
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            SendCustomEventMessage("The current time is: " + Time.time);
        }
    }
}
