using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlicedFruitToPlay : MonoBehaviour {

	void Start () {
        Invoke("Play", 2F);
	}

    private void Play()
    {
        SceneManager.LoadScene("Game");
    }
}
