using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus1 : MonoBehaviour
{
    private States _states = new States();
    public ScoreData scoreData;
    private int _damage;
​
   void Update()
    {
        if (Enemy.IsVirus1Playing)
        {
            RandomState.StateLimits = 3;
            RandomState.RandomStateMethod();
            Debug.Log("Virus is choosing");
            switch (RandomState.StateE)
            {
                case 1:
                    _damage = 10;
                    StartCoroutine(ChoosePlayerToAttack());
                    _states.Invisibility();
                    Debug.Log("2-Invisibility");
                    Enemy.IsVirus1Playing = false;
                    BattleMachine.IsEnemyChoosing = false;
                    BattleMachine.OnPlayerTurn = true;
                    break;
                case 2:
                    _damage = 15;
                    StartCoroutine(ChoosePlayerToAttack());
                    _states.Attack();
                    Debug.Log("2-Attack");
                    Enemy.IsVirus1Playing = false;
                    BattleMachine.IsEnemyChoosing = false;
                    BattleMachine.OnPlayerTurn = true;
                    break;
                case 3:
                    _damage = 10;
                    StartCoroutine(ChoosePlayerToAttack());
                    _states.Scanner();
                    Debug.Log("2-Scanner");
                    Enemy.IsVirus1Playing = false;
                    BattleMachine.IsEnemyChoosing = false;
                    BattleMachine.OnPlayerTurn = true;
                    break;
                default:
                    Debug.Log("el enemy no hace nada we");
                    _states.Iddle();
                    Enemy.IsVirus1Playing = false;
                    BattleMachine.IsEnemyChoosing = false;
                    BattleMachine.OnPlayerTurn = true;
                    break;
            }
        }
    }
    IEnumerator ChoosePlayerToAttack()
    {
        Debug.Log("Choose a player to attack");
        if (RandomState.StateE % 2 == 0)
        {
            Debug.Log("Attack to Mago");
            scoreData.mLife = scoreData.mLife - _damage;
        }
​
      else
        {
            Debug.Log("Attack to Hacker");
            scoreData.hLife = scoreData.hLife - _damage;
        }
        yield return new WaitForSeconds(1f);
    }
​

}
