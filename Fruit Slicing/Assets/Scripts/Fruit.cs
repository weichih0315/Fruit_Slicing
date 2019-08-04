using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    public GameObject fruitSlicedPrefab;
    public float startForce = 15f;    

    public static event System.Action OnSliced;

    private Rigidbody2D rb;

    private Vector3 startPosition, endPosition;

    private bool isCanSliced = false;
    private bool ishaveStartPoint = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    private void OnEnable()
    {
        Blade.OnSlicedHolder += OnBladeHolder;
        Blade.OnSlicedRelease += OnBladeRelease;
        GameManager.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        Blade.OnSlicedHolder -= OnBladeHolder;
        Blade.OnSlicedRelease -= OnBladeRelease;
        GameManager.OnGameOver -= GameOver;
    }

    private void OnBladeHolder()
    {
        isCanSliced = true;
    }

    private void OnBladeRelease()
    {
        isCanSliced = false;
    }

    private void GameOver()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Blade" && isCanSliced)
        {
            startPosition = collision.transform.position;
            ishaveStartPoint = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Blade" && isCanSliced && ishaveStartPoint)
        {
            ishaveStartPoint = false;
            AudioManager.instance.PlaySound2D("melonSliced");

            endPosition = collision.transform.position;

            Vector3 direction = (startPosition - endPosition).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);

            if (OnSliced != null)
            {
                OnSliced();
            }

            Destroy(slicedFruit, 3f);
            Destroy(gameObject);
        }
    }
}
