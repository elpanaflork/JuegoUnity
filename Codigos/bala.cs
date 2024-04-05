using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    [SerializeField] private float vel; //la velocidad de la bala

    private void Update()
    {
        transform.Translate(Vector2.up * vel * Time.deltaTime); //como se va moviendo la bala
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))//cuando la bala choca con el enemigo se destruye
        {
            Destroy(gameObject);//rompe la bala
        }
        if (collision.CompareTag("Borde"))//cuando la bala choca con el borde del mapa se destruye
        {
            Destroy(gameObject);//rompe la bala
        }
    }
}
