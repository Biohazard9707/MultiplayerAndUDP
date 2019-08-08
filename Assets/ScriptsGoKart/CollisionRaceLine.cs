using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;
using UnityEngine.UI;

public class CollisionRaceLine : MonoBehaviour
{
    public GameObject[] spawns;

    void Start()
    {
        spawns = null;
    }

    private void OnTriggerEnter(Collider other)
    {
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
}
