using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class GolRaceCart : NetworkBehaviour {
    
    [SyncVar]public bool goalRace = false;
    private NetworkStartPosition[] spawnPoints;

    void Start ()
    {
        //triggerDetection = raceLine.GetComponent<CollisionRaceLine>().
        if (isLocalPlayer)
        {
            //De serlo  localizamos los puntos de inicio con FindObjectsOfType<>
            // Y los alamacenamos de spawnpoints
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
    }

    public void WinnerRace(bool goal, int count)
    {
        if(!isServer)
        {
            return;
        }

        goalRace = goal;
        if(goalRace)
        {
            RpcRespawn(count);
        }
    }

    [ClientRpc]
    public void RpcRespawn(int count)
    {
        if (isLocalPlayer)
        {
            
            //Genera un objeto del tipo Vector3 y le asigna
            //Una posición cero como valor inicial
            Vector3 spawnPoint = Vector3.zero;

            /*Verificamos que las posiciones iniciales no esten vacias y que sean mayor a 0*/
            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                //Asignamos aleatoriamente la posición inicial del juagador en el mapa
                spawnPoint = spawnPoints[count - 1].transform.position;
            }

            //Iniciamos el jugador en el punto inicial
            transform.position = spawnPoint;
            
        }
    }


}