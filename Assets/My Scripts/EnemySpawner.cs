using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Importamos la libreria networking
using UnityEngine.Networking;


public class EnemySpawner : NetworkBehaviour
{
    //Declaramos un objeto del tipo GameObject este sera el enemigo
    public GameObject enemyPrefab;
    //Declaramos la variable que almacenara el número de enemigos que deseamos generar
    public int numberOfEnemies;

    public override void OnStartServer()
    {
        for(int i = 0; i <= numberOfEnemies; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8.0f, 8.0f), 0.0f, Random.Range(-8.0f, 8.0f));
            Quaternion spawnRotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 180.0f), 0.0f);

            GameObject enemy = (GameObject)Instantiate(enemyPrefab, spawnPosition, spawnRotation);
            NetworkServer.Spawn(enemy);
        }
    }

}
