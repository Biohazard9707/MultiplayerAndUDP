using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerControllerr : NetworkBehaviour {

    private float x, z;
    public Texture changeTexture;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        if(!isLocalPlayer)
        {
            return;
        }

        x = Input.GetAxis("Horizontal") * Time.deltaTime * 100.0f;
        z = Input.GetAxis("Vertical") * Time.deltaTime * 2.5f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    public override void OnStartLocalPlayer()
    {
        GameObject body = transform.GetChild(4).gameObject;
        body.GetComponent<MeshRenderer>().material.mainTexture = changeTexture;
    }

}
