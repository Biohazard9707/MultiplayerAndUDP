﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float x, z;

    public void MovePlayer(GameObject player)
    {
        x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}
