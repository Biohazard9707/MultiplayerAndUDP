using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoalRace : NetworkBehaviour {

    //public GameObject[] respawns;
    private NetworkStartPosition[] spawnPoints;
    private GameObject[] respawns;

    // Use this for initialization
    void Start ()
    {
        if(isServer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
            //Debug.Log(spawnPoints);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(!isLocalPlayer)
        {
            return;
        }
        Debug.Log("Activo el trigger");
        RpcRespawnPlayers();

    }

    [ClientRpc]
    public void RpcRespawnPlayers()
    {
        //if (isLocalPlayer)
        //{
        //Vector3 spawnPoint = Vector3.zero;
        ////int i = 0;
        //Debug.Log("Estas aqui");
        //if (spawnPoints != null && spawnPoints.Length > 0)
        //{
        //    //Asignamos aleatoriamente la posición inicial del juagador en el mapa
        //    spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        //    Debug.Log(spawnPoint.z);
        //}
        //transform.position = spawnPoint;
        //Debug.Log(gameObject.name);
        //}

        if(isServer)
        {
            int i;
            Vector3 spawnPoint = Vector3.zero;
            if (respawns == null)
            {
                respawns = GameObject.FindGameObjectsWithTag("Respawn");
            }
            for (i = 0; i <= 1; i++)
            {
                spawnPoint = spawnPoints[i].transform.position;
                respawns[i].transform.position = spawnPoint;
                Debug.Log("Estamos en el ciclo " + i);
            }
        }

        //NetworkServer.Spawn(gameObject);

        /*
        if (respawns == null)
        {
            respawns = GameObject.FindGameObjectsWithTag("Respawn");
        }

        foreach(GameObject respawn in respawns)
        {
            if(spawnPoints != null && spawnPoints.Length > 0)
            {
                if(i <= spawnPoints.Length)
                {
                    for (int j = i; j <= i && j <= spawnPoints.Length; j++)
                    {
                        spawnPoint = spawnPoints[j].transform.position;
                        NetworkServer.Spawn(respawn);
                    }
                }
                else
                {
                    spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
                    NetworkServer.Spawn(respawn);
                }
                
            }
        }

        respawns = null;*/
    }
}
