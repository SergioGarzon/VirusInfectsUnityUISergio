using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Hacker : MonoBehaviour
{
    private States _states = new States();

    public ScoreData scoreData;

    private int copyLimit = 3;

    [SerializeField] private KeyCode bugKey, copyKey, stealKey;
    private int _damage;


    private Animator animator;

    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Player.IsHackerPlaying)
        {
            Debug.Log("Select a hacker action");

            if (Input.GetKey(bugKey))
            {
                _damage = 10;
                StartCoroutine(ChooseVirus());
                this.animator.SetTrigger("CharlieAtaca");
                _states.Bug();
                Debug.Log("OK");
                BattleMachine.IsPlayerChoosing = false;
                scoreData.shootingPoints = +25;
                BattleMachine.OnPlayerTurn = false;
            }
            else if (Input.GetKey(copyKey) && copyLimit > 0)//añadir condicion de 1 sola copia
            {
                _damage = 15;
                StartCoroutine(ChooseVirus());
                this.animator.SetTrigger("CharlieAtaca");
                _states.Copy();
                Debug.Log("OK");
                BattleMachine.IsPlayerChoosing = false;
                scoreData.shootingPoints = +25;
                BattleMachine.OnPlayerTurn = false;
                copyKey--;
            }
            else if (Input.GetKey(stealKey))//añadir condicion de scoreData
            {
                _damage = 20;
                StartCoroutine(ChooseVirus());
                this.animator.SetTrigger("CharlieAtaca");
                _states.Steal();
                Debug.Log("OK");
                BattleMachine.IsPlayerChoosing = false;
                scoreData.shootingPoints = +25;
                BattleMachine.OnPlayerTurn = false;
            }
        }

        if (scoreData.hLife <= 0)
        {
            this.animator.SetTrigger("CharlieMuere");
            _states.Die();
        }
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
        yield return new WaitForSeconds(1);
    }


}
