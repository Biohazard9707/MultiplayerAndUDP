using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter()
    {   
        /*Destruye el objeto asignado
         cuando entra en colisión con otro objeto*/
        Destroy(gameObject);    
    }
}
