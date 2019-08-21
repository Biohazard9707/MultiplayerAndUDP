using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AssignPortClass : NetworkBehaviour {

    public SyncListInt syncListPortObjectReceiver = new SyncListInt();
    public SyncListInt syncListPortObjectTransmitter = new SyncListInt();

    private int[] portsReceiver = new int[] { 11000, 11100, 11200, 11300, 11400, 11500, 11600, 11700, 11800, 11900 };
    private int[] portsTransmitter = new int[] { 12100, 12200, 12300, 12400, 12500, 12600, 12700, 12800, 12900, 13000 };

    void Start ()
    {
        syncListPortObjectReceiver.Callback += OnSyncListPortObjectReceiverChanged;
        syncListPortObjectTransmitter.Callback += OnSyncListPortObjectTransmitterChanged;
        StartPorts();
    }

    private void OnSyncListPortObjectReceiverChanged(SyncListInt.Operation op, int index)
    {
        Debug.Log("List changed " + op);
    }

    private void OnSyncListPortObjectTransmitterChanged(SyncListInt.Operation op, int index)
    {
        Debug.Log("List Changed " + op);
    }

    public int AssignPortMethod()
    {
        int newPortReceiver = 0;
        for(int count = 0; count < syncListPortObjectReceiver.Count; count++)
        {
            if(syncListPortObjectReceiver[count] == 0)
            {
                syncListPortObjectReceiver[count] = 1;
                newPortReceiver = portsReceiver[count];
                break;
            }
        }
        for(int i = 0; i < syncListPortObjectReceiver.Count; i++)
        {
            Debug.Log("Lista \t SyncListPortObjectReceiver[" + i + "] \t = \t " + syncListPortObjectReceiver[i] + "\n");
        }
        return newPortReceiver;

        //-----------------------------------------------------------------//
        //int[] arrayPorts = new int[10];
        //syncListPortObject.CopyTo(arrayPorts, 0);
        //int newPort = 0;
        //for(int count = 0; count < arrayPorts.Length; count ++)
        //{
        //    if(arrayPorts[count] == 0)
        //    {
        //        arrayPorts[count] = 1;
        //        newPort = ports[count];
        //        break;
        //    }
        //}
        //syncListPortObject.Clear();
        //for(int count = 0; count < arrayPorts.Length; count++)
        //{
        //    syncListPortObject.Insert(count, arrayPorts[count]);
        //}
        //foreach (var i in syncListPortObject)
        //    Debug.Log("Quiubo " + i);
        //return newPort;
        //-----------------------------------------------------------------//
    }

    public int AssignPortTransmitterMethod()
    {
        int newPortTransmiter = 0;
        for(int count = 0; count < syncListPortObjectTransmitter.Count; count++)
        {
            if(syncListPortObjectTransmitter[count] == 0)
            {
                syncListPortObjectTransmitter[count] = 1;
                newPortTransmiter = portsTransmitter[count];
                break;
            }
        }
        Debug.Log("Puertos asignados de el transmisor\n");
        for(int i = 0; i < syncListPortObjectTransmitter.Count; i++)
        {
            Debug.Log("Lista \t SyncListPortObjectTransmitter[" + i + "] \t = \t" + syncListPortObjectTransmitter[i] + "\n");
        }
        return newPortTransmiter;
    }
    
    public void StartPorts()
    {
        for(int count = 0; count < 10; count++)
        {
            syncListPortObjectReceiver.Insert(count, 0);
            syncListPortObjectTransmitter.Insert(count, 0);
        }
    }
}
