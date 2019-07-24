using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Variable que le otorgara al jugador movilidad de rotación en el eje x con respecto
        // a las teclas de direccion derecha e izquierda
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //Variable que le otorgara al jugador movilidad de translación en el eje z con respecto
        // a las teclas de direccion arriba y abajo
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        //metodo que le pasa como parametro "x" en el eje x para rotar el objeto
        transform.Rotate(0, x, 0);
        //metodo que se le pasa como parametro "Z" en el eje z para trasladar el objeto 
        transform.Translate(0, 0, z);

	}
}
