using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public GameObject mago, hacker;
    public static bool IsHackerPlaying=false;
    public static bool IsMagoPlaying=false;

    
    void Update()
    {
        if (BattleMachine.IsPlayerChoosing)
        {
            Debug.Log("H for hacker and E for electrokinetic");
            
            if (Input.GetKey(KeyCode.H))
            {
                Hacker hackerController = hacker.GetComponent<Hacker>();
                IsHackerPlaying = true;
                Debug.Log("You selected Hacker");
                BattleMachine.IsPlayerChoosing = false;
                return;
            }
                                                            
            else if (Input.GetKey(KeyCode.E))
            {
                Mago magoController = mago.GetComponent<Mago>();
                Debug.Log("You selected Mago");
                IsMagoPlaying = true;
                BattleMachine.IsPlayerChoosing = false;
                return;
            }
        }
   
    }

    // Update is called once per frame
    
    
}
