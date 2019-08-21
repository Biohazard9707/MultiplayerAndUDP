using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//public struct Port
//{
//    public int[] assignPortSync;
//};

//public class SyncListPort : SyncListStruct<Port> { }

public class CollisionRaceLine : NetworkBehaviour
{
   
    //public SyncListPort syncListPortObject = new SyncListPort();

    public GameObject[] spawns;
    //private int[] ports = new int[] { 11000, 11100, 11200, 11300, 11400, 11500, 11600, 11700, 11800, 11900 };
    //private int[] portsTransmitter = new int[] { 12100, 12200, 12300, 12400, 12500, 12600, 12700, 12800, 12900, 13000 };

    //override void OnStartClient
    void Start()
    {
        
        //syncListPortObject.Callback += OnSyncListPortObjectChanged;

        //Port structPort = new Port
        //{
        //    assignPortSync = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //};

        //Port structPortTransmitter = new Port
        //{
        //    assignPortSync = new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        //};
        //syncListPortObject.Insert(0, structPort);
        //syncListPortObject.Insert(1, structPortTransmitter);
        spawns = null;
    }
    
    //private void OnSyncListPortObjectChanged(SyncListPort.Operation op, int index)
    //{
    //    Debug.Log("List changed " + op);
    //}

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

    //[Command]
    //public void CmdAssignPortMethod()
    //{
    //    Debug.Log(syncListPortObject.GetItem(0));
    //    Port assignPort = syncListPortObject.GetItem(0);
    //    Debug.Log(assignPort);
    //    Debug.Log(assignPort.assignPortSync.Length);
    //    int newPort = 0;
    //    for (int count = 0; count < assignPort.assignPortSync.Length; count++)
    //    {
    //        if (assignPort.assignPortSync[count] == 0)
    //        {
    //            assignPort.assignPortSync[count] = 1;
    //            newPort = ports[count];
    //            break;
    //        }
    //    }
    //    Debug.Log(newPort);
    //}

   

    //public int AssignPortTransmitterMethod()
    //{
    //    int newPortTransmiter = 0;
    //    for (int count = 0; count < assignPortTransmitter.Length; count++)
    //    {
    //        if (assignPortTransmitter[count] == 0)
    //        {
    //            assignPortTransmitter[count] = 1;
    //            newPortTransmiter = portsTransmitter[count];
    //            break;
    //        }
    //    }
    //    return newPortTransmiter;
    //}
}
//Port item = new Port
//{
//    assignPortList = 95,
//};
//Port loca = new Port
//{
//    assignPortList = 36,
//};
//syncListPortObject.Insert(0, item);
//syncListPortObject.Insert(1, loca);
//Debug.Log(syncListPortObject.IndexOf(item));
//Debug.Log(syncListPortObject.IndexOf(loca));
//Debug.Log(syncListPortObject.Contains(item));
//Debug.Log(syncListPortObject.GetItem(0));
//Port sample = syncListPortObject.GetItem(1);
//Debug.Log(sample.assignPortList);
//Port hugoBoss = new Port
//{
//    assignPortList = 7,
//};
//syncListPortObject.Insert(1, hugoBoss);
//syncListPortObject.GetItem(1); 
//sample = syncListPortObject.GetItem(1);
//Debug.Log(sample.assignPortList);
//Debug.Log(sample);

//Port[] purebaP = new Port[3];
//syncListPortObject.CopyTo(purebaP, 0);
//foreach(var i in purebaP)
//{
//    Debug.Log(i.assignPortList);
//}
////Debug.Log(syncListPortObject.GetEnumerator());
//syncListPortObject.Callback += OnSyncListPortObjectChanged;