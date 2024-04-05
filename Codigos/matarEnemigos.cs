using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matarEnemigos : MonoBehaviour
{
    public GameObject[] objetosEncontrados;
    public string etiqueta;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            MatarEnemigos();
        }
    }

    private void MatarEnemigos()
    {
        objetosEncontrados = GameObject.FindGameObjectsWithTag(etiqueta);
        for (int i = 0; i < objetosEncontrados.Length; i++)
        {
            Destroy(objetosEncontrados[i]);
            puntaje.Intance.SumarPuntos(1);
        }
    }
}
