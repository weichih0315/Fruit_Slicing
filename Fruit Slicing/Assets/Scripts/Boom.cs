using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour {

    public GameObject boomEffectPrefab;
    public float startForce = 15f;

    public static event System.Action OnSliced;

    private Rigidbody2D rb;

    private bool isCanSliced = false;

    private bool ishaveStartPoint = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {        
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
            ishaveStartPoint = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Blade" && isCanSliced && ishaveStartPoint)
        {
            ishaveStartPoint = false;
            AudioManager.instance.PlaySound2D("melonSliced");

            GameObject boom = Instantiate(boomEffectPrefab, transform.position, Quaternion.identity);

            if (OnSliced != null)
            {
                OnSliced();
            }

            Destroy(boom, 3f);
            Destroy(gameObject);
        }
    }
}
