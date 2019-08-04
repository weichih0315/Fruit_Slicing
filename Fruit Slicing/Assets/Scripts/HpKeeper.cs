using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpKeeper : MonoBehaviour {

    public static int hp { get; private set; }

    void Start () {
        hp = 3;
        Boom.OnSliced += OnBoomSliced;
    }

    private void OnDisable()
    {
        Boom.OnSliced -= OnBoomSliced;
    }

    private void OnBoomSliced()
    {
        hp--;
    }
}
