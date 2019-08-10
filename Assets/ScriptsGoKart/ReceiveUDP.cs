using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class ReceiveUDP
{
    //private const int listenPort = 11000;
    private int listenPortPlayer;
    //private UdpClient receiver = new UdpClient(listenPortPlayer);
    private UdpClient receiver;
    //private IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, listenPortPlayer);
    private IPEndPoint ipEndPoint;
    private bool done = false;
    private string mess;
    private float rotateY;

    public ReceiveUDP(int port)
    {
        listenPortPlayer = port;
        receiver = new UdpClient(listenPortPlayer);
        ipEndPoint = new IPEndPoint(IPAddress.Any, listenPortPlayer);
    }

    public float RotateY
    {
        get
        {
            return rotateY;
        }

        set
        {
            rotateY = 0;
        }
    }

    public int ListenPortPlayer
    {
        set
        {
            listenPortPlayer = value;
        }
    }

    public void WaitingToReceiveData()
    {
        string receivedData;
        Byte[] receiveByteArray;
        try
        {
            while(!done)
            {
                Debug.Log("\n");
                receiveByteArray = receiver.Receive(ref ipEndPoint);
                if(receiveByteArray != null)
                {
                    receivedData = Encoding.ASCII.GetString(receiveByteArray, 0, receiveByteArray.Length);
                    rotateY = float.Parse(receivedData);
                    mess = receivedData;
                    Debug.Log(mess);
                } 
            }
        }
        catch(Exception e)
        {
            Debug.Log(e.ToString());
        }

    }

    public void StopReceivingClient()
    {
        receiver.Close();
    }
}
