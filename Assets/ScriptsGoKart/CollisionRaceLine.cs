using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;
using UnityEngine.UI;

public class CollisionRaceLine : MonoBehaviour
{
    public GameObject[] spawns;
    private int[] ports = new int[] { 11000, 11100, 11200, 11300, 11400, 11500, 11600, 11700, 11800, 11900, 12000};
    private int[] assignPort = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

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

    public int AssignPortMethod()
    {
        int newPort = 0;
        for (int count = 0; count < assignPort.Length; count++)
        {
            if (assignPort[count] == 0)
            {
                assignPort[count] = 1;
                newPort = ports[count];
                break;
            }
        }
        return newPort;
    }
}
