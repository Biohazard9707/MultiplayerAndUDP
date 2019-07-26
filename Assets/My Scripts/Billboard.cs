using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {   
        //Permite que el healthbar canvas siempre apunte a la camara principal
        transform.LookAt(Camera.main.transform);
	}
}
