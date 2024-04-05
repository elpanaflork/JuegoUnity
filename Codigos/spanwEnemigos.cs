using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class spanwEnemigos : MonoBehaviour
{
    private float minX, maxX, minY, maxY; //los puntos que estan en cada esquina del mapa para genera a los enemigos de forma aleatoria
    [SerializeField] private Transform[] puntos; //aca hago una lista donde guardo esos puntos

    [SerializeField] private GameObject[] enemigosSprites; //los sprites de los ememigos para despues generarlos de forma aleatoria
    [SerializeField] private float tiemposEnemigos;
    private float tiempoSiguienteEnemigo; //el tiempo de espera en el que se genera el siguiente enemigo
    private int ene = 10; //esto es para subir la dificultad del juego, al principio esta en 10 para que te aparezcan los enemigos normlaes y despues cambia a 20 y a 30 haciendo que aparezcan los demas tipos de enemigos
    private float timeEne; //esta es la cantidad de puntos que necesitas para que se haga mas dificil el juego

    [SerializeField] private float poder; //poder es el tiempo en el que aparece el siguiente poder
    [SerializeField] private GameObject[] poderPrefab; //la lista con los prefab de los poderes
    private float poderSiguiente; //este es el tiempo que va para saber si aparece un nuevo poder

    private float distancia; //distancia sirve para saber la distancia entre los enemigos y el jugador para que no le aparezca al lado el enemigo

    public Transform Jugador; //el transform del jugador
    public Vector2 posJugador; //la posicion del jugador

    /* esto es para agregar las monedas
    [SerializeField] private float moneda;
    [SerializeField] private GameObject monedaPrefab;
    private float monedaSiguiente;*/

    void Awake()
    {
        //los puntos en que dicen en donde pueden aparecer los enemigo
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);
    }

    private void Update()
    {
        
        tiempoSiguienteEnemigo += Time.deltaTime;
        poderSiguiente += Time.deltaTime;
        //monedaSiguiente += Time.deltaTime;

        posJugador = new Vector2(Jugador.position.x, Jugador.position.y); //obtenemos la posicion del jugador

        timeEne = puntaje.Intance.puntos; //el puntaje para saber cuando le agregamos dificultad al juego

        if (timeEne >= 80 && timeEne <= 199)
        {
            ene = 20;
        }else if(timeEne >= 200 && timeEne <= 250)
        {
            ene = 30; // esto es para que empiecen a aparecer los enemigos chicos
        }else if (timeEne >= 300 && timeEne <= 400)
        {
            tiemposEnemigos = tiemposEnemigos / 2;
        }

        if (tiempoSiguienteEnemigo >= tiemposEnemigos)
        {
            tiempoSiguienteEnemigo = 0;
            CrearEnemigo(posJugador); //crea al enemigo
        }

        if (poderSiguiente >= poder)
        {
            poderSiguiente = 0; //reinicia el tiempo
            poder = poder + 5; //hace que el siguiente poder tarde mas en aparecer
            CrearPoder(); //crea el poder
        }
        

        /*
        string path = @"C:\Users\ET36\Desktop\moneda.txt";
        if (!File.Exists(path))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("Hello");
                sw.WriteLine("And");
                sw.WriteLine("Welcome");
            }	
        }

        // Open the file to read from.
        using (StreamReader sr = File.OpenText(path))
        {
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
        }
        */


        /*
        if (monedaSiguiente >= moneda)
        {
            monedaSiguiente = 0;
            CrearMoneda();
        }*/
    }

    private void CrearEnemigo(Vector2 jugador) //la funcion de crear enemigos
    {
        int numeroEnemigo = Random.Range(0, ene); //genera el numero aleatorio en la lista de enemigos para que aparezcan enemigos distintos
        Vector2 posAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)); //gener la posision aleatoria donde va a aparecer el enemigo

        distancia = Vector2.Distance(posAleatoria, jugador);//se fija la distancia entre el enemigo que va a aparecer y el jugador

        if (distancia >= 1f) //si la distancia es menor de 1 metro el enemigo aparece NO aparece
        {
            Instantiate(enemigosSprites[numeroEnemigo], posAleatoria, Quaternion.identity); //crea al enemigo
        }

        //Instantiate(enemigosSprites[numeroEnemigo], posAleatoria, Quaternion.identity);
    }

    private void CrearPoder()
    {
        Vector2 posAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        int numeroPoder = Random.Range(0, poderPrefab.Length);

        Instantiate(poderPrefab[numeroPoder], posAleatoria, Quaternion.identity);
    }

    /*
    private void CrearMoneda()
    {
        Vector2 posAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(monedaPrefab, posAleatoria, Quaternion.identity);
    }*/
}