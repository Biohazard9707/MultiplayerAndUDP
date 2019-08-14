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
    Thread receivedThread2;
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
        transform.Rotate(0.0f, receiveUDPObject.RotateY, 0.0f);
        transform.Translate(0.0f, 0.0f, receiveUDPObject.TranslateX);
        receiveUDPObject.RotateY = 0.0f;
        receiveUDPObject.TranslateX = 0.0f;
        transmitterUDPObject.WaitingToTransmitterData(2.5f, 5.5f);
    }

    public override void OnStartLocalPlayer()
    {
        //Change texture gameobject
        GameObject body = transform.GetChild(4).gameObject;
        body.GetComponent<MeshRenderer>().material.mainTexture = changeTexture;
        collisionRaceLineObject = startRaceLine.GetComponent<CollisionRaceLine>();
        port = startRaceLine.GetComponent<CollisionRaceLine>().AssignPortMethod();
        portTransmitter = startRaceLine.GetComponent<CollisionRaceLine>().AssignPortTransmitterMethod();
        if (port != 0)
        {
            receiveUDPObject = new ReceiveUDP(port);
            //StartReceivedThread();
        }
        //Code transmiter
        if (portTransmitter != 0)
        {
            transmitterUDPObject = new TransmitterUDP(portTransmitter);
            //StartTransmitterThread();
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
        //StopTransmitterThread();
    }

    public void StartReceivedThread()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        if (port == 11000)
        {
            receivedThread = new Thread(receiveUDPObject.WaitingToReceiveData);
            receivedThread.IsBackground = true;
            receivedThread.Start();
        }
        else
        {
            if(port == 11100)
            {
                receivedThread2 = new Thread(receiveUDPObject.WaitingToReceiveData);
                receivedThread2.IsBackground = true;
                receivedThread2.Start();
            }
        }
        
    }

    //Code tranmitter
    //public void StartTransmitterThread()
    //{
    //    if (!isLocalPlayer)
    //    {
    //        return;
    //    }
    //    transmitterThread = new Thread(transmitterUDPObject.WaitingToTransmitterData);
    //    transmitterThread.IsBackground = true;
    //    transmitterThread.Start();
    //}

    public void StopReceivedThread()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        if(port == 11000)
        {
            receiveUDPObject.StopReceivingClient();
            if (receivedThread.IsAlive)
            {
                receivedThread.Abort();
            }
        }
        else
        {
            if(port == 11100)
            {
                receiveUDPObject.StopReceivingClient();
                if(receivedThread2.IsAlive)
                {
                    receivedThread2.Abort();
                }
            }
        }
    }

    //Code transmitter
    //public void StopTransmitterThread()
    //{
    //    if (!isLocalPlayer)
    //    {
    //        return;
    //    }
    //    transmitterUDPObject.StopTransmitterClient();
    //    if(transmitterThread.IsAlive)
    //    {
    //        transmitterThread.Abort();
    //    }
    //}
}