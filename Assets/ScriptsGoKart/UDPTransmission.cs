using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using UnityEngine.UI;
//using UnityEngine.Networking;

public class UDPTransmission : MonoBehaviour {

    Thread receivedThread;
    ReceiveUDP receiveUDPObject;

	// Use this for initialization
	void Start () {
        receiveUDPObject = new ReceiveUDP(11000);
        StartReceivedThread();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, receiveUDPObject.RotateY, 0);
        receiveUDPObject.RotateY = 0.0f;
    }

    public void OnApplicationQuit()
    {
        StopReceivedThread();
    }

    public void StartReceivedThread()
    {
        receivedThread = new Thread(receiveUDPObject.WaitingToReceiveData);
        receivedThread.IsBackground = true;
        receivedThread.Start();
    }

    public void StopReceivedThread()
    {
        receiveUDPObject.StopReceivingClient();
        if(receivedThread.IsAlive)
        {
            receivedThread.Abort();
        }
    }
}