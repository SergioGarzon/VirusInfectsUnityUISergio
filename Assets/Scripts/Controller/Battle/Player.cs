using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


//Veamos la clase player
public class Player : MonoBehaviour
{
    //Tiene lo objetos Mago y Hacker
    public GameObject mago, hacker;

    //Aqui hace una variable estatica Hacker esta jugando en falso "es hacker jugando"
    public static bool IsHackerPlaying=false;

    //Aqui hace una variable estatica Mago esta jugando en falso "es mago jugando"
    public static bool IsMagoPlaying=false;

    
    //Método Update
    void Update()
    {
        //Aqui consulta si el método estatico, //El jugador esta eligiendo
        if (BattleMachine.IsPlayerChoosing)
        {
            Debug.Log("H for hacker and E for electrokinetic");
            

            //Si apretas la H
            if (Input.GetKey(KeyCode.H))
            {
                //Llama a la clase Hacker
                Hacker hackerController = hacker.GetComponent<Hacker>();

                //
                IsHackerPlaying = true;
                Debug.Log("You selected Hacker");
                BattleMachine.IsPlayerChoosing = false;
                return;
            }
                             
            //O si apretas la E
            else if (Input.GetKey(KeyCode.E))
            {
                //Llama a la clase Mago
                Mago magoController = mago.GetComponent<Mago>();

                //Aqui informa que elegiste al mago
                Debug.Log("You selected Mago");

                //Aqui setea el valor de Mago es elegido
                IsMagoPlaying = true;

                //Aqui setea el valor de Battle Machine donde informa que el jugado no elige
                BattleMachine.IsPlayerChoosing = false;

                //return corta el método
                return;
            }
        }
   
    }

    // Update is called once per frame
    
    
}
