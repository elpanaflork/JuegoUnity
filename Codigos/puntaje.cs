using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class puntaje : MonoBehaviour
{
    public float puntos;
    private TextMeshProUGUI textMesh;

    public static puntaje Intance { get; private set; } //b

    private void Awake() //b
    {
        if (Intance == null)
        {
            Intance = this;
        }
        else
        {
            Debug.Log("a");
        }
    }

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMesh.text = puntaje.Intance.puntos.ToString("0");
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
    }
}