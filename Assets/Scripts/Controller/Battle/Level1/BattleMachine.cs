using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;



public enum BattleStates { 
    Start, 
    PlayerSelection, 
    SkillSelection, 
    EnemySelection, 
    Enemyturn, 
    EnemySelect, 
    EnemySelectPlayer, 
    Won, 
    Lost 
}


//start=comienza la batalla
//player selection= para elegir con cual atacar
//skillselection= para elegir ataque 
//enemyselection= para elegir virus a atacar 
//enemy tur= virus elije ccn cual atacar 
//enemy select= Virus elije ataque 
//enemy select player = elije a que jugador atacar 
public class BattleMachine : MonoBehaviour
{
    public GameObject mago, hacker, virus1, virus2;

    private Player _player;
    public static BattleMachine Instance;

    public static bool OnPlayerTurn = true;

    public BattleStates states;

    private bool _battle = true;

    public ScoreData scoreData;

    private Virus1 _virus1System;
    private Hacker _hackerSystem;
    private Mago _magoSystem;

    public Text dialogText;

    private int _scoreBattleEnemy = 100;
    private int _damage;

    public static bool IsPlayerChoosing = false;
    public static bool IsEnemyChoosing = false;

    public GameObject collisionZone2;
    private StartLevel2 _startLevel2;

    private CharacterController1 _characterController1;
    public int lifeBattleVirus1 = 100;
    public int lifeBattleVirus2 = 100;

    public bool isEnemySelected;
    public bool virus1Choosed = false;
    public bool virus2Choosed = false;
    private int c = 2;

    private bool lostGame;

    private int activateButtonState;
    private int botonPresionado;


    [SerializeField] private KeyCode bugKey, copyKey, stealKey;
    [SerializeField] private KeyCode _electricityKey, _pixelKey, _LightingKey;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _characterController1 = GetComponent<CharacterController1>();
        states = BattleStates.Start;
        _startLevel2 = collisionZone2.GetComponent<StartLevel2>();
        StartCoroutine(SetUpBattle());


        this.lostGame = false;
        this.activateButtonState = 0;
        this.botonPresionado = 0;
    }

    void Update()
    {
        switch (states)
        {
            case BattleStates.Start:
                this.setActivateButtonStatePlayerEnemy(1);
                break;


            case BattleStates.PlayerSelection:

                

                this.dialogText.text = "Select Hacker H o E ,  Life energy Hacker: " + this.scoreData.hLife + ", Mago: " + this.scoreData.mLife +
                    "\n Vida del enemigo 1 " + lifeBattleVirus1 + " Vida del enemigo 2: " + lifeBattleVirus2;

                

                if (Input.GetKeyDown(KeyCode.H) || this.botonPresionado == 1)
                {
                    Player.IsHackerPlaying = true;
                    dialogText.text = "You selected hacker";
                    states = BattleStates.EnemySelection;
                    

                }
                else if (Input.GetKeyDown(KeyCode.E) || this.botonPresionado == 2)
                {
                    dialogText.text = "You selected mago";
                    Player.IsMagoPlaying = true;
                    states = BattleStates.EnemySelection;
                }

                break;

            case BattleStates.SkillSelection:

                this.dialogText.text = "Select an action  \n\n ScoreData ShootPoint: " + scoreData.shootingPoints;

                if (Player.IsMagoPlaying)
                {
                    if (Input.GetKey(KeyCode.H))
                    {
                        _damage = 5;
                        // _states.Pixeling();
                        Debug.Log("pixel");
                        Player.IsMagoPlaying = false;
                        RestScore();
                        states = BattleStates.Enemyturn;
                    }
                    else if (Input.GetKey(KeyCode.K) && Mago.Instance._electricityLimit > 0)
                    {
                        _damage = 10;
                        //_states.Electricity();
                        Debug.Log("Electricity");
                        Player.IsMagoPlaying = false;
                        Mago.Instance._electricityLimit--;
                        RestScore();
                        states = BattleStates.Enemyturn;
                    }
                    else if (Input.GetKey(KeyCode.L) && scoreData.shootingPoints == 100)
                    {
                        //_states.Light();
                        Debug.Log("Light");
                        _damage = 15;
                        Player.IsMagoPlaying = false;
                        RestScore();
                        states = BattleStates.Enemyturn;
                        scoreData.shootingPoints = 0;
                    }
                    if (lifeBattleVirus1 <= 0 & lifeBattleVirus2 <= 0)
                    {
                        states = BattleStates.Won;
                    }
                }
                else if (Player.IsHackerPlaying)
                {
                    if (Input.GetKey(KeyCode.H))
                    {
                        _damage = 5;
                        Debug.Log("1");
                        states = BattleStates.Enemyturn;

                    }
                    else if (Input.GetKey(KeyCode.K))
                    {
                        _damage = 10;
                        Debug.Log("2");
                        Hacker.Instance._damage = 10;
                        states = BattleStates.Enemyturn;
                    }
                    else if (Input.GetKey(KeyCode.L))//añadir condicion 
                    {
                        _damage = 15;
                        Debug.Log("3");
                        states = BattleStates.Enemyturn;
                    }
                }
                break;
            case BattleStates.EnemySelection:

                this.dialogText.text = "Select an anemy to attack";

                this.setActivateButtonStatePlayerEnemy(2);

                if (Input.GetKey(KeyCode.V))
                {
                    this.dialogText.text = ("Attack to Virus 1");
                    virus1Choosed = true;
                    states = BattleStates.SkillSelection;
                }

                else if (Input.GetKey(KeyCode.B))
                {
                    this.dialogText.text = ("Attack to Virus 2");
                    virus2Choosed = true;
                    states = BattleStates.SkillSelection;
                }
                if (lifeBattleVirus1 <= 0 & lifeBattleVirus2 <= 0)
                {
                    states = BattleStates.Won;
                    EndBattle();
                }
                break;

            case BattleStates.Enemyturn:

                dialogText.text = "Enemy Turn";

                if (c % 2 == 0)
                {
                    this.dialogText.text = ("Enemy 1 Selected");

                    Virus1 virus1Controller = virus1.GetComponent<Virus1>();
                    Enemy.IsVirus1Playing = true;
                    dialogText.text = "Virus 1 Attacking! \n\n" + virus1Controller.ToString();
                    states = BattleStates.EnemySelect;
                    //states = BattleStates.Enemyturn;
                }
                else
                {
                    this.dialogText.text = ("Enemy 2 Selected");
                    Virus1 virus2Controller = virus2.GetComponent<Virus1>();
                    Enemy.IsVirus1Playing = true;
                    this.dialogText.text = "" + virus2Controller.ToString();
                    dialogText.text = "Virus 2 Attacking! " + virus2Controller.ToString();
                    states = BattleStates.EnemySelect;
                    //states = BattleStates.Enemyturn;
                }
                c = 2;
                //c++;

                break;
            case BattleStates.EnemySelect:

                RandomState.StateLimits = 3;
                RandomState.RandomStateMethod();
                this.dialogText.text = ("Virus is choosing");
                switch (RandomState.StateE)
                {
                    case 1:
                        //_states.Attack();
                        _damage = 5;
                        this.dialogText.text = ("2-Invisibility");
                        Enemy.IsVirus1Playing = false;
                        states = BattleStates.EnemySelectPlayer;
                        break;
                    case 2:
                        //_states.Attack();
                        _damage = 10;
                        this.dialogText.text = ("2-Attack");
                        Enemy.IsVirus1Playing = false;
                        states = BattleStates.EnemySelectPlayer;
                        break;
                    case 3:
                        //_states.Scanner();
                        _damage = 15;
                        this.dialogText.text = ("2-Scanner");
                        Enemy.IsVirus1Playing = false;
                        states = BattleStates.EnemySelectPlayer;
                        break;
                    default:
                        this.dialogText.text = ("No anda el virus");
                        Enemy.IsVirus1Playing = false;
                        break;
                }

                //states = BattleStates.EnemySelect;  //Esto lo puse yo para probar
                break;


            case BattleStates.EnemySelectPlayer:


                if (RandomState.StateE % 2 == 0)
                {
                    this.dialogText.text = ("Attack to Hacker");
                    scoreData.hLife = scoreData.hLife - _damage;
                    //states = BattleStates.PlayerSelection;
                }
                else
                {
                    this.dialogText.text = ("Attack to Mago");
                    scoreData.mLife = scoreData.mLife - Virus1.Instance._damage;
                    //states = BattleStates.PlayerSelection;
                }


                //Le ponemos un OR exclusivo
                if (scoreData.hLife <= 0 || scoreData.mLife <= 0) //el score es la vida de los players
                {
                    states = BattleStates.Lost;
                    EndBattle();
                }

                //this.dialogText.text = "Vida del personaje " + scoreData.mLife + ", hacker: " + scoreData.hLife;


                //Esto lo puse yo para probar
                states = BattleStates.PlayerSelection;

                break;

            default: break;
        }
        /*  if (OnPlayerTurn)
          {
              states = BattleStates.PlayerTurn;
              StartCoroutine(PlayerTurn());
          }
          else if (!OnPlayerTurn)
          {
              states = BattleStates.Enemyturn;
              StartCoroutine(EnemyTurn());
          }*/
    }

    IEnumerator SetUpBattle()
    {
        dialogText.text = "SetUp Battle";
        yield return new WaitForSeconds(1f);

        dialogText.text = "Battle 1";
        yield return new WaitForSeconds(1f);

        states = BattleStates.PlayerSelection;
    }


    void EndBattle()

    {
        if (states == BattleStates.Won)
        {
            dialogText.text = "You won the battle!";
            _characterController1.GoBackCity();
            _startLevel2.enabled = true;

        }
        else if (states == BattleStates.Lost)
        {
            dialogText.text = "You loose";
            this.lostGame = true;
        }
    }

    void RestScore()
    {

        if (virus1Choosed)
        {
            lifeBattleVirus1 = lifeBattleVirus1 - _damage;
            virus1Choosed = false;
        }
        else if (virus2Choosed)
        {
            lifeBattleVirus2 = lifeBattleVirus2 - _damage;
            virus2Choosed = false;
        }
    }

    public float[] getValueBattle()
    {
        float[] vector = new float[4];

        vector[0] = this.scoreData.hLife;
        vector[1] = this.scoreData.mLife;
        vector[2] = this.lifeBattleVirus1;
        vector[3] = this.lifeBattleVirus2;

        return vector;
    }

    public bool getLostGame()
    {
        return lostGame;
    }


    public void setActivateButtonStatePlayerEnemy(int valor)
    {
        this.activateButtonState = valor;
    }


    public int getActivateButtonStatePlayerEnemy()
    {
        return this.activateButtonState;
    }

    public void setBotonPresionado(int valor)
    {
        this.botonPresionado = valor;
    }



}
