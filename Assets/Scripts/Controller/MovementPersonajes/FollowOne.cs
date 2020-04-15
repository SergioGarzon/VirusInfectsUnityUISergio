using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOne : MonoBehaviour
{

    //Aqui declaro la velocidad que le pongo por defecto
    public float speed;

    //Esto es una distancia de vision
    public float visionRadiosStop;


    //Aqui declaro el personaje al que estoy siguiendo
    public GameObject player;

    //Declaro el objeto del mago, ya que es mejor que lo inserte directamente
    public GameObject mago;


    //Aqui declaro la posición inicial del Mago
    private Vector3 initialPosition;


    private Vector3 target;


    void Start()
    {
        //Declaro la posición inicial del mago
        initialPosition = transform.position;

        //target mas distancia 
        target = initialPosition;

    }



    void Update()
    {

        //Acá trae la distancia entre el jugador y el mago
        float distance = Vector3.Distance(this.player.transform.position, this.mago.transform.position);


        //Si la distancia es mayor a 
        if (distance >= visionRadiosStop)
        {
            //Setea la posición del Mago
            target = player.transform.position;
        }


        //Acá lo que va haciendo es seteando la posición del Mago
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);


    }
}
