﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleUI : MonoBehaviour {

    public float speed = 15f;

	// Update is called once per frame
	void Update () {

        transform.Rotate(Vector3.back * Time.deltaTime * speed);
	}
}
