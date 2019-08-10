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
	}
	
	// Update is called once per frame
	void Update ()
    {
		
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
    }
}
