using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pruebas : MonoBehaviour {

    public Texture changeTexture;
	// Use this for initialization
	void Start () {
        GameObject body = transform.GetChild(4).gameObject;
        Debug.Log(body);
        body.GetComponent<MeshRenderer>().material.mainTexture = changeTexture;
        //GetComponent<MeshRenderer>().material.mainTexture = changeTexture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
