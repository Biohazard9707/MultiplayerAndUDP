using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CollisionRaceLine : NetworkBehaviour
{
    public GameObject[] spawns;
    private int[] ports = new int[] { 11000, 11100, 11200, 11300, 11400, 11500, 11600, 11700, 11800, 11900 };
    public int[] assignPort = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; 
    private int[] portsTransmitter = new int[] { 12100, 12200, 12300, 12400, 12500, 12600, 12700, 12800, 12900, 13000 };
    public int[] assignPortTransmitter = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    
//[SyncList]

void Start()
    {

        spawns = null;
        //assignPort = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        //assignPortTransmitter = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!isServer)
        {
            return;
        }
        GolRaceCart golRaceCartObj;

        if(spawns == null)
        {
            spawns = GameObject.FindGameObjectsWithTag("Respawn");
        }
        int count = 0;
        foreach (GameObject spawn in spawns)
        {
            count++;
            golRaceCartObj = spawn.GetComponent<GolRaceCart>();
            golRaceCartObj.WinnerRace(true, count);
        }
    }

    public int AssignPortMethod()
    {

        int newPort = 0;
        Debug.Log(newPort);
        for (int count = 0; count < assignPort.Length; count++)
        {
            Debug.Log(count);
            Debug.Log(assignPort[count]);
            if (assignPort[count] == 0)
            {
                assignPort[count] = 1;
                newPort = ports[count];
                break;
            }
        }
        return newPort;
    }

    public int AssignPortTransmitterMethod()
    {
        int newPortTransmiter = 0;
        for (int count = 0; count < assignPortTransmitter.Length; count++)
        {
            if (assignPortTransmitter[count] == 0)
            {
                assignPortTransmitter[count] = 1;
                newPortTransmiter = portsTransmitter[count];
                break;
            }
        }
        return newPortTransmiter;
    }
}