using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movPlayer : MonoBehaviour
{
    [SerializeField] private float vel;
    [SerializeField] private Vector2 direccion;
    private Rigidbody2D rb;
    [SerializeField] private ParticleSystem particulas; //las particulas

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //obtiene el rigibody
    }

    private void Update()
    {
        puntaje.Intance.SumarPuntos(Time.deltaTime);
        //se fija que toca el jugador para moverlo
        direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    //movimientos fisicos
    private void FixedUpdate()
    {
        if (direccion == new Vector2(-1 , 0)) //cuando va para la izquierda
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (direccion == new Vector2(1, 0)) //cuando va para la derecha
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (direccion == new Vector2(0, 1)) //cuando va para arriba
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direccion == new Vector2(0, -1)) //cuando va para abajo
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (direccion == new Vector2(0.7071068f, 0.7071068f)) //diagonal derecha arriba
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);
        }
        else if (direccion == new Vector2(0.7071068f, -0.7071068f)) //diagonal derecha abajo
        {
            transform.rotation = Quaternion.Euler(0, 0, -140);
        }
        else if (direccion == new Vector2(-0.7071068f, -0.7071068f)) //diagonal izquierda abajo
        {
            transform.rotation = Quaternion.Euler(0, 0, 140);
        }
        else if (direccion == new Vector2(-0.7071068f, 0.7071068f)) //diagonal izquierda arriba
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }

        rb.MovePosition(rb.position + direccion * vel * Time.fixedDeltaTime);
        
        if (direccion != new Vector2(0, 0))
        {
            particulas.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo")) //si choca con el enemigo
        {
            Destroy(gameObject);//mata al jugador 
            SceneManager.LoadScene(2);
        }
        if (collision.CompareTag("Borde")) //si choca con el borde del mapa
        {
            Destroy(gameObject);//mata al jugador
            SceneManager.LoadScene(2);
        }
    }
}