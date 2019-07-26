using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /*Se le pasa como parametro un objeto del tipo
     Collision*/
    void OnCollisionEnter(Collision collision)
    {
        /*Se genera un objeto del tipo game object que será el jugador*/
        GameObject hit = collision.gameObject;
        /*Generamos un objeto del tipo Health y le asignamos el valor
         del componente Health del jugador*/
        Health health = hit.GetComponent<Health>();

        /*Evaluamos si el jugador tiene asignado el componente */
        if(health != null)
        {
            /*De ser verdadero ejecuta el metodo que calcula el daño*/
            health.TakeDamage(10);
        }
        /*Destruye el objeto asignado
         cuando entra en colisión con otro objeto
         en este caso la bala es destruida*/
        Destroy(gameObject);    
    }
}
