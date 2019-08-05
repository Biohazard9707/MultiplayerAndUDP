using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;
using UnityEngine.UI;

public class CollisionRaceLine : MonoBehaviour
{
    //private NetworkStartPosition[] spawnPoints;
    //private GameObject[] respawns;
    public bool champion = false;
    public Text message = null;
    public GameObject[] spawns;

    void Start()
    {
        spawns = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Activo el trigger");
        message.text = "Activo el triger";
        GolRaceCart golRaceCartObj;

        if(spawns == null)
        {
            spawns = GameObject.FindGameObjectsWithTag("Respawn");
            Debug.Log("Estos son los spawns bastardo ...  olo" + spawns);
        }
        int count = 0;
        foreach (GameObject spawn in spawns)
        {
            count++;
            Debug.Log("A huevo ya estas en el ciclo perra");
            golRaceCartObj = spawn.GetComponent<GolRaceCart>();
            golRaceCartObj.WinnerRace(true, count);
        }
        //RespawnPlayers(); 
    }

    private void Update()
    {

    }

    //[Command]
    public void RespawnPlayers()
    {
        //Debug.Log("Entro la chingadera");
        //message.text = message.text + "Y ahora entro la chingadera...... t (°-° )t";
        //champion = true;
        //if (isServer)
        //{
        //int i;
        //Vector3 spawnPoint = Vector3.zero;
        //if (respawns == null)
        //{
        //    respawns = GameObject.FindGameObjectsWithTag("Respawn");
        //}
        //for (i = 0; i <= 1; i++)
        //{
        //    spawnPoint = spawnPoints[i].transform.position;
        //    respawns[i].transform.position = spawnPoint;
        //    Debug.Log("Estamos en el ciclo " + i);
        //}
        //}
    }
}
