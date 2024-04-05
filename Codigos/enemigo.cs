using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    public float velocidad; //la velocidad con la que se mueve el enemigo

    public GameObject objetoEncontrado; //busca al jugador
    public string cadena; //para buscar el tag

    [SerializeField] private float cantPuntos; // cantidad de puntos que suma matar a un enemigo

    private void Start()
    {
        buscar(cadena); //llama al metodo buscar para encontral al jugador y seguirlo
    }

    public void Update() 
    {
       transform.position = Vector2.MoveTowards(transform.position, objetoEncontrado.transform.position, velocidad * Time.deltaTime);// mueve al enemigo
    }

    private void OnTriggerEnter2D(Collider2D collision) //para detectar las coliciones
    {
        if (collision.CompareTag("bala"))
        {
            puntaje.Intance.SumarPuntos(cantPuntos);
            Destroy(gameObject);//mata al enemigo
        }

        if (collision.CompareTag("Escudo"))
        {
            Destroy(gameObject);
        }
    }

    private void buscar(string etiqueta) //busca al jugador
    {
        objetoEncontrado = GameObject.FindGameObjectWithTag(etiqueta);
    }
}