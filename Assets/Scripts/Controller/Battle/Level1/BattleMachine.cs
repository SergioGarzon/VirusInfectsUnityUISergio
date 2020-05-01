using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


//Estos son los estados
public enum BattleStates
{
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


//Esta es la clase Battle Machine
public class BattleMachine : MonoBehaviour
{

    public GameObject mago, hacker, virus1;
    private Player _player;

    public static BattleMachine Instance;

    public static bool OnPlayerTurn = true;

    public BattleStates states;


    public ScoreData scoreData;


    private Hacker _hackerSystem;
    private Mago _magoSystem;
    private Virus1 _virus1System;

    public Text dialogText;

    private int _damage;

    public static bool IsPlayerChoosing = false;
    public static bool IsEnemyChoosing = false;

    private int lifeBattleVirus1 = 100;
    public bool isEnemySelected;
    public bool virus1Choosed = false;
    public bool virus2Choosed = false;
    private int contador = 2;

    private int botonesActivados;
    private int veracidad;



    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        states = BattleStates.Start;
        StartCoroutine(SetUpBattle());

        this.botonesActivados = 0;
        this.veracidad = 0;


    }

    void Update()
    {
        switch (states)
        {
            case BattleStates.Start:
                this.veracidad = 0;
                break;

            case BattleStates.PlayerSelection:                
                PlayerSelection();
                break;

            case BattleStates.EnemySelection:
                EnemySelection();
                break;

            case BattleStates.EnemySelect:
                SeleccionarEnemigo();
                break;


            case BattleStates.EnemySelectPlayer:
                EnemySelectPlayer();
                break;



            case BattleStates.SkillSelection:
                //Acá va a ir Skill Selection
                SkillSelection();
                break;


            case BattleStates.Enemyturn:
                EnemyTurnMethod();
                break;

            default: break;
        }
    }


    private void PlayerSelection()
    {
        //BattleStates.PlayerSelection:
        this.dialogText.text = "Vida del Hacker: " + scoreData.hLife + ", Vida del Mago: " + scoreData.mLife + "\n" +
        "Vida del Virus 1: " + this.lifeBattleVirus1 + "\n\n" +
        "Seleccione o Player (G) o Mago (H)";


        if (this.botonesActivados == 1)
        {
            Player.IsHackerPlaying = true;
            Player.IsMagoPlaying = false;
            dialogText.text = "You selected hacker";
            states = BattleStates.EnemySelection;
        }

        if (this.botonesActivados == 2)
        {
            dialogText.text = "You selected mago";
            Player.IsHackerPlaying = false;
            Player.IsMagoPlaying = true;
            states = BattleStates.EnemySelection;
        }
    }


    private void SeleccionarEnemigo()
    {
        RandomState.StateLimits = 3;
        RandomState.RandomStateMethod();
        this.dialogText.text = "Virus is choosing";

        switch (RandomState.StateE)
        {
            case 1:
                _damage = 5;
                Debug.Log("2-Invisibility");
                Enemy.IsVirus1Playing = false;
                states = BattleStates.EnemySelectPlayer;
                break;
            case 2:
                _damage = 10;
                Debug.Log("2-Attack");
                Enemy.IsVirus1Playing = false;
                states = BattleStates.EnemySelectPlayer;
                break;
            case 3:
                _damage = 15;
                Debug.Log("2-Scanner");
                Enemy.IsVirus1Playing = false;
                states = BattleStates.EnemySelectPlayer;
                break;

            default:
                Debug.Log("No anda el virus");
                Enemy.IsVirus1Playing = false;
                break;
        }
    }

    private void EnemySelection()
    {
        this.dialogText.text = ("Attack to Virus 1");
        states = BattleStates.SkillSelection;


        if (lifeBattleVirus1 <= 0)
        {
            states = BattleStates.Won;
            EndBattle();
        }
    }

    private void EnemySelectPlayer()
    {
        int valor = UnityEngine.Random.Range(1, 10);

        if (valor % 2 == 0)
        {
            scoreData.hLife = scoreData.hLife - _damage;
            states = BattleStates.PlayerSelection;
        }
        else
        {
            scoreData.mLife = scoreData.mLife - _damage;
            states = BattleStates.PlayerSelection;
        }

        this.veracidad = 0;

        if (scoreData.hLife <= 0 & scoreData.mLife <= 0) //el score es la vida de los players
        {
            states = BattleStates.Lost;
            EndBattle();
        }
    }

    private void SkillSelection()
    {
        //Skill Selection
        this.dialogText.text = ("Select an action Player(B,N,M) - Mago(J,K,L)");

        this.veracidad = 1;

        if (Player.IsMagoPlaying)
        {
            this.dialogText.text = "YOU SELECT MAGO (B,N,M)";

            if (this.botonesActivados == 6)
            {
                // _states.Pixeling();
                _damage = 5;
                this.dialogText.text = ("pixel");
                Player.IsMagoPlaying = false;
                RestScore();
                states = BattleStates.Enemyturn;
            }
            else if (this.botonesActivados == 7 && Mago.Instance._electricityLimit > 0)
            {
                _damage = 10;
                //_states.Electricity();
                this.dialogText.text = ("Electricity");
                Player.IsMagoPlaying = false;
                Mago.Instance._electricityLimit--;
                RestScore();
                states = BattleStates.Enemyturn;
            }
            else if (this.botonesActivados == 8 && scoreData.shootingPoints == 100)
            {
                _damage = 15;
                //_states.Light();
                this.dialogText.text = ("Light");
                Player.IsMagoPlaying = false;
                RestScore();
                states = BattleStates.Enemyturn;
                scoreData.shootingPoints = 0;
            }
            if (lifeBattleVirus1 <= 0)
            {
                states = BattleStates.Won;
            }
        }


        if (Player.IsHackerPlaying)
        {
            this.dialogText.text = "YOU SELECT PLAYER (J,K,L)";

            if (this.botonesActivados == 3)
            {
                _damage = 5;
                this.dialogText.text = ("1");
                states = BattleStates.Enemyturn;
                Player.IsHackerPlaying = false;
            }

            if (this.botonesActivados == 4)
            {
                _damage = 10;
                this.dialogText.text = ("2");
                Hacker.Instance._damage = 10;
                states = BattleStates.Enemyturn;
                Player.IsHackerPlaying = false;
            }

            if (this.botonesActivados == 5)//añadir condicion 
            {
                _damage = 15;
                this.dialogText.text = ("3");
                states = BattleStates.Enemyturn;
                Player.IsHackerPlaying = false;
            }
        }
    }


    private void EnemyTurnMethod()
    {
        dialogText.text = "Enemy Turn";

        

        if (contador % 2 == 0)
        {
            this.dialogText.text = ("Enemy 1 Selected");
            dialogText.text = "Virus 1 Attacking!";
            Virus1 virus1Controller = virus1.GetComponent<Virus1>();
            Enemy.IsVirus1Playing = true;
            states = BattleStates.EnemySelect;
        }

        contador++;
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

        }
        else if (states == BattleStates.Lost)
        {
            dialogText.text = "You loose";
        }
    }

    void RestScore()
    {

        lifeBattleVirus1 = lifeBattleVirus1 - _damage;
        virus1Choosed = false;
    }

    public int getRetornarVidaEnemigo()
    {
        return lifeBattleVirus1;
    }


    public void setBotonesHabilitados(int valor)
    {
        this.botonesActivados = valor;
    }


    public int getReturnVeracidad()
    {
        return this.veracidad;
    }
}

