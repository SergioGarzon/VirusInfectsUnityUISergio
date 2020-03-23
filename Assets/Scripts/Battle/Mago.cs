using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Xml.Schema;
using UnityEngine;
using Object = UnityEngine.Object;

public class Mago : MonoBehaviour
{
    [SerializeField] private KeyCode _electricityKey, _pixelKey, _LightingKey;
    private int  _electricityLimit;

    public ScoreData scoreData;
    
    private States _states = new States();

    void Update()
    {
        if (Player.IsMagoPlaying)
        {
            Debug.Log("Choose an Action to Mago");
            
            if (Input.GetKeyDown(_pixelKey))
            {
                _states.Pixeling();
                Debug.Log("pixel");
                BattleMachine.IsPlayerChoosing=false;
                Player.IsMagoPlaying = false;
                BattleMachine.OnPlayerTurn = false;
            }
            else if (Input.GetKeyDown(_electricityKey) && _electricityLimit > 0)
            {
                _states.Electricity();
                Debug.Log("Electricity");
                BattleMachine.IsPlayerChoosing=false;
                Player.IsMagoPlaying = false;
                BattleMachine.OnPlayerTurn = false;
                _electricityLimit--;
            }
            else if (Input.GetKeyDown(_LightingKey)&&scoreData.shootingPoints==100)
            {
                _states.Light();
                Debug.Log("Light");
                BattleMachine.IsPlayerChoosing=false;
                Player.IsMagoPlaying = false;
                BattleMachine.OnPlayerTurn = false;
                scoreData.shootingPoints = 0;
            }
        }
    }

   



}
