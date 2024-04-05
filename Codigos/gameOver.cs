using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
    public Text textElement;

    private void Start()
    {
        textElement.text = puntaje.Intance.puntos.ToString("0");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //y si apreta el space dispara
        {
            Reiniciar("juego");
        }
    }

    public void Reiniciar(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void MenuInicial(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void Salir(string nombre)
    {
        Application.Quit();
    }
}
