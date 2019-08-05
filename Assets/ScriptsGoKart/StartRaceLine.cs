using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StartRaceLine : NetworkBehaviour {

    public GameObject raceLine;

    public override void OnStartServer()
    {
            Vector3 spawnPosition = new Vector3(0.0f, 0.1f, -7.5f);
            Quaternion spawnRotation = Quaternion.Euler(90.0f, 0.0f, 90.0f);

            GameObject startRaceLine = (GameObject)Instantiate(raceLine, spawnPosition, spawnRotation);
            NetworkServer.Spawn(startRaceLine);
        }
    }

