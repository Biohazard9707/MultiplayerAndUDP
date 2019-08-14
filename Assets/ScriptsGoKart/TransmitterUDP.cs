using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;

public class TransmitterUDP
{
    //private bool done = false;
    private bool exception_throw = false;
    private int talkerPortPlayer;
    private Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    private static IPAddress send_to_address = IPAddress.Parse("192.168.100.235");
    private IPEndPoint sending_end_point;


    public TransmitterUDP(int port)
    {
        talkerPortPlayer = port;
        sending_end_point = new IPEndPoint(send_to_address, talkerPortPlayer);
    }
    
    //public bool Done
    //{
    //    set
    //    {
    //        done = true;
    //    }
    //}

    public void WaitingToTransmitterData(float rotationX, float rotationZ)
    {
        //System.Random rdn = new System.Random();
        //int minNumber = 1;
        //int maxNumber = 200;
        //int b;
        //string result;
        double[] rotationCar = new double[] { rotationX, rotationZ };
        byte[] send_buffer = rotationCar.Select(x => (byte)x).ToArray();
        //while (!done)
        //{
            //b = rdn.Next(minNumber, maxNumber);
            //result = b.ToString();

            //byte[] send_buffer = Encoding.ASCII.GetBytes(result);

        Debug.Log("Sending to address " + sending_end_point.Address + "puerto" + sending_end_point.Port);

        try
        {
            sending_socket.SendTo(send_buffer, sending_end_point);
        }
        catch(Exception send_exception)
        {
            exception_throw = true;
            Debug.Log("Exception " + send_exception.Message);
        }
            
        if (exception_throw == false)
        {
            Debug.Log("El mensaje ha sido enviado a la direccion de transmisión.");

        }
        else
        {
            exception_throw = false;
            Debug.Log("La excepción indica que el mensaje no fue enviado.");
        }
        //}
    }

    //public void StopTransmitterClient()
    //{
    //    done = true;
    //    //sending_socket.Close();
    //}
}