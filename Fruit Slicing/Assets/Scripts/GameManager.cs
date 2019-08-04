using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static event System.Action OnGameOver;

    private void Update()
    {
        int hp = HpKeeper.hp;

        if (hp == 0)
        {
            if (OnGameOver != null)
            {
                OnGameOver();
                Destroy(gameObject);
            }
        }
    }
}
