using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Threading;
using UnityEngine.UI;

public class PlayerControllerr : NetworkBehaviour {

    public Texture changeTexture;

    Thread receivedThread;
    //Code Trasnmitter
    Thread transmitterThread;
    ReceiveUDP receiveUDPObject;
    //Code Transmitter
    TransmitterUDP transmitterUDPObject;
    GameObject texto;
    public GameObject startRaceLine;
    CollisionRaceLine collisionRaceLineObject;

    int port;

    //Code transmitter
    int portTransmitter;

    // Use this for initialization
    //void Start() {
    //    if (!isLocalPlayer)
    //    {
    //        return;
    //    }
    //    collisionRaceLineObject = startRaceLine.GetComponent<CollisionRaceLine>();
    //    port = collisionRaceLineObject.AssignPortMethod();
    //    if (port != 0)
    //    {
    //        receiveUDPObject = new ReceiveUDP(port);
    //        StartReceivedThread();
    //    }
    //    Debug.Log(port);
    //}
	
	// Update is called once per frame
	void Update () {

        if(!isLocalPlayer)
        {
            return;
        }
        transform.Rotate(0, receiveUDPObject.RotateY, 0);
        receiveUDPObject.RotateY = 0.0f;
    }

    public override void OnStartLocalPlayer()
    {
        //Change texture gameobject
        GameObject body = transform.GetChild(4).gameObject;
        body.GetComponent<MeshRenderer>().material.mainTexture = changeTexture;
        collisionRaceLineObject = startRaceLine.GetComponent<CollisionRaceLine>();
        port = collisionRaceLineObject.AssignPortMethod();
        portTransmitter = collisionRaceLineObject.AssignPortTransmitterMethod();
        if (port != 0)
        {
            receiveUDPObject = new ReceiveUDP(port);
            StartReceivedThread();
        }
        //Code transmiter
        if (portTransmitter != 0 )
        {
            transmitterUDPObject = new TransmitterUDP(portTransmitter);
            StartTransmitterThread();

        }
        Debug.Log(port);
        //Code Transmitter
        Debug.Log(portTransmitter);
    }

    public void OnApplicationQuit()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        StopReceivedThread();
        StopTransmitterThread();
    }

    public void StartReceivedThread()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        receivedThread = new Thread(receiveUDPObject.WaitingToReceiveData);
        receivedThread.IsBackground = true;
        receivedThread.Start();
    }

    //Code tranmitter
    public void StartTransmitterThread()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        transmitterThread = new Thread(transmitterUDPObject.WaitingToTransmitterData);
        transmitterThread.IsBackground = true;
        transmitterThread.Start();
    }

    public void StopReceivedThread()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        receiveUDPObject.StopReceivingClient();
        if (receivedThread.IsAlive)
        {
            receivedThread.Abort();
        }
    }

    //Code transmitter
    public void StopTransmitterThread()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        transmitterUDPObject.StopTransmitterClient();
        if(transmitterThread.IsAlive)
        {
            transmitterThread.Abort();
        }
    }
}