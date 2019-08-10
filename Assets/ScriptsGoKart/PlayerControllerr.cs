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
    ReceiveUDP receiveUDPObject;
    GameObject texto;
    public GameObject startRaceLine;
    CollisionRaceLine collisionRaceLineObject;
    int port;

    // Use this for initialization
    void Start() {
        if (!isLocalPlayer)
        {
            return;
        }
        collisionRaceLineObject = startRaceLine.GetComponent<CollisionRaceLine>();
        port = collisionRaceLineObject.AssignPortMethod();
        if (port != 0)
        {
            receiveUDPObject = new ReceiveUDP(port);
            StartReceivedThread();
        }
        Debug.Log(port);
    }
	
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

        GameObject body = transform.GetChild(4).gameObject;
        body.GetComponent<MeshRenderer>().material.mainTexture = changeTexture;
       
    }

   

    public void OnApplicationQuit()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        StopReceivedThread();
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

    //void AssignNewPort()
    //{
    //    collisionRaceLineObject = startRaceLine.GetComponent<CollisionRaceLine>();
    //    port = collisionRaceLineObject.AssignPortServer();
    //}
}