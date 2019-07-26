using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Importamos libreria necesaria para trabajar con Interfa za de Usuario
using UnityEngine.UI;
//Importamos la libreria networking
using UnityEngine.Networking;

/*Aplicamos herencia de Network sobre la clase Health */
public class Health : NetworkBehaviour
{

    /*propiedad constante que asigna la vida maxima de un jugador*/
    public const int maxHealth = 100;
    /*propiedad que almacenara la salud actual del jugador
     se inicializa con el valor de maxHealth*/
    /*Anteponemos el prefijo [SyncVar], que es una variable de sincronización, lo que 
     * hará esta variable, es que se sincronizara con el servidor, en cuanto el valor de la variable,}
     cambie en el servidor, este se lo informara a los demás clientes.*/
     /*Lo que hace hook es que funciona como un gancho que permite sincronizar esta variable
      salud actual del jugador en los demás clientes lo que permite, asi que cuando existe algun cambio en la salud
      de un jugador se ejecuta el metodo "OnChangeHealth" y le pasa el valor a todos los clientes.*/
    [SyncVar (hook = "OnChangeHealth")]public int currentHealth = maxHealth;
    /*Declaramos un objeto del tipo RectTransform*/
    public RectTransform healthBar;

    /*Método designado para evaluar 
     el daño ocasionado sobre el jugador
     recibe como parametro la cantidad de daño 
     que recibira el jugador.*/
    public void TakeDamage(int amount)
    {

        /*Antes de ejecutar las instrucciones verifica que no las ejecuten los clientes
         sino el servidor asi el servidor se encaraga de este metodo y de sincronizar la salud actual de todos 
         los jugadores dentro del juego.*/
        if(!isServer)
        {
            //Simplemente sale del método
            return;
        }

        /*decrementamos el valor de la variable
         deacuerdo a la cantidad de daño recibido*/
        currentHealth -= amount;
        /*Si el valor de la salud actual del jugador es 
         menor o igual a 0, asignarle como nuevo valor 0*/
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            //Mensaje en consola "Muerto"
            Debug.Log("Dead");
        }

        /*Cambiaremos el tamaño de la barra de vida
         se multiplica por 2 la salud actual del jugador esto
         debido a que la salud total es de 100 y la barra tiene un tamaño asignado de 200
         posteriormente cambiamos el tamaño de la barra en "x" y "y" lo dejamos tal cual*/
        //healthBar.sizeDelta = new Vector2(currentHealth * 2, healthBar.sizeDelta.y);
    }
    
    /*Este método se encargara de sincronizar la barra de salud actual en todo momento
     no solo en el servidor si no en los demas clientesy recibe como parametro la salud actual del jugador*/
    void OnChangeHealth(int health)
    {
        healthBar.sizeDelta = new Vector2(health * 2, healthBar.sizeDelta.y);
    }

}
