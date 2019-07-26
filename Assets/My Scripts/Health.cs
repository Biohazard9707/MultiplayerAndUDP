using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Importamos libreria necesaria para trabajar con Interfa za de Usuario
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    /*propiedad constante que asigna la vida maxima de un jugador*/
    public const int maxHealth = 100;
    /*propiedad que almacenara la salud actual del jugador
     se inicializa con el valor de maxHealth*/
    public int currentHealth = maxHealth;
    /*Declaramos un objeto del tipo RectTransform*/
    public RectTransform healthBar;

    /*Método designado para evaluar 
     el daño ocasionado sobre el jugador
     recibe como parametro la cantidad de daño 
     que recibira el jugador.*/
    public void TakeDamage(int amount)
    {
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
        healthBar.sizeDelta = new Vector2(currentHealth * 2, healthBar.sizeDelta.y);
    }

}
