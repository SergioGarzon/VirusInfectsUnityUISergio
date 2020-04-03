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
    private int _electricityLimit;

    public ScoreData scoreData;

    private States _states = new States();

    private int _damage;

    private Animator animationMago;

    private void Start()
    {
        this.animationMago = GetComponent<Animator>();
    }

    void Update()
    {
        if (Player.IsMagoPlaying)
        {
            Debug.Log("Choose an Action to Mago");

            if (Input.GetKeyDown(_pixelKey))
            {
                _damage = 10;
                StartCoroutine(ChooseVirus());
                _states.Pixeling();
                Debug.Log("pixel");
                BattleMachine.IsPlayerChoosing = false;
                Player.IsMagoPlaying = false;
                scoreData.shootingPoints = +25;
                BattleMachine.OnPlayerTurn = false;

                animationMago.SetTrigger("MagoEfectoRayos");
            }
            else if (Input.GetKeyDown(_electricityKey) && _electricityLimit > 0)
            {
                _damage = 15;
                StartCoroutine(ChooseVirus());
                _states.Electricity();
                Debug.Log("Electricity");
                BattleMachine.IsPlayerChoosing = false;
                Player.IsMagoPlaying = false;
                BattleMachine.OnPlayerTurn = false;
                scoreData.shootingPoints = +25;
                _electricityLimit--;

                animationMago.SetTrigger("MagoEfectoRayos");
            }
            else if (Input.GetKeyDown(_LightingKey) && scoreData.shootingPoints == 100)
            {
                _damage = 20;
                StartCoroutine(ChooseVirus());
                _states.Light();
                Debug.Log("Light");
                BattleMachine.IsPlayerChoosing = false;
                Player.IsMagoPlaying = false;
                BattleMachine.OnPlayerTurn = false;
                scoreData.shootingPoints = 0;

                animationMago.SetTrigger("MagoEfectoRayos");
            }
        }

        if(scoreData.mLife <= 0)
        {
            _states.Die();
        }

        IEnumerator ChooseVirus()
        {
            Debug.Log("Choose a virus to attack");
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                Debug.Log("Attack to Virus 1");
                BattleMachine.lifeBattleVirus1 = BattleMachine.lifeBattleVirus1 - _damage;
            }

            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                Debug.Log("Attack to Virus 2");
                BattleMachine.lifeBattleVirus1 = BattleMachine.lifeBattleVirus2 - _damage;
            }
            yield return new WaitForSeconds(1f);
        }
    }

}