using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Hacker : MonoBehaviour
{
    private States _states = new States();

    public ScoreData scoreData;

    private int copyLimit=3;
    
    [SerializeField] private KeyCode bugKey, copyKey, stealKey;


    void Update()
    {
        if (Player.IsHackerPlaying)
        {
            Debug.Log("Select a hacker action");
                    
            if (Input.GetKey(bugKey))
            { 
                _states.Bug();
               Debug.Log("OK");
               BattleMachine.IsPlayerChoosing=false;
               BattleMachine.OnPlayerTurn = false;
            }
            else if (Input.GetKey(copyKey)&&copyLimit>0)//añadir condicion de 1 sola copia
            {
                _states.Copy();
                Debug.Log("OK");
                BattleMachine.IsPlayerChoosing=false;
                BattleMachine.OnPlayerTurn = false;
                copyKey--;
            }
            else if ( Input.GetKey(stealKey)&&scoreData.gamePoints==100)//añadir condicion de scoreData
            {
                _states.Steal();
                Debug.Log("OK");
                BattleMachine.IsPlayerChoosing=false;
                BattleMachine.OnPlayerTurn = false;
            }
        }
    }

    
}
