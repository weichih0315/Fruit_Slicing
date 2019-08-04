using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AudioManager.instance.PlaySound2D("boom");
    }
}
