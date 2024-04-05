using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo; //la posicion de donde sale la bala
    [SerializeField] private GameObject bala; //el prefab de la bala
    [SerializeField] private float tiempoBala; //una variable de tiempo que va sumando
    public float siguienteBala; //el tiempo para el siguiente disparo

    private void Start()
    {
        tiempoBala = siguienteBala; //hago esto para que ni bien empiece pueda disparar
    }

    void Update()
    {
        tiempoBala += Time.deltaTime;//para que vaya sumando el tiempo

        if (tiempoBala >= siguienteBala) //se fija si paso el tiempo para disparar
        {
            if (Input.GetKeyDown(KeyCode.Space)) //y si apreta el space dispara
            {
                Disparar(); //la funcion del disparo
                tiempoBala = 0; // y reiniciamos el tiempo
            }
        }
    }

    private void Disparar()
    {
        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation); 
        //intancai la bala y le da el prefab, la posicion y la rotacion con la que sale la bala
    }
}
