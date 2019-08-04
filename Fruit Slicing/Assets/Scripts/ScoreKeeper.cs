using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public static int score { get; private set; }

    private void Start() {
        score = 0;
        Fruit.OnSliced += OnFruitSliced;
    }

    private void OnFruitSliced()
    {
        score += 200;
    }
    
    private void OnDisable()
    {
        Fruit.OnSliced -= OnFruitSliced;
    }
}
