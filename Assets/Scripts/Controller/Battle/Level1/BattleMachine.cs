using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


//Aqui hace una clase Enum para poner el estado de la batalla
public enum BattleStates{
    Start, 
    PlayerTurn, 
    Enemyturn, 
    Won, 
    Lost 
}

//La clase Battle Machine, que es la maquina de batalla de los objetos
public class BattleMachine : MonoBehaviour
{

    //La referencia de los objetos
    public GameObject mago, hacker, virus1, virus2;

    //Objeto Player nunca se usa
    private Player _player;


    //Variable estatica donde te dice el turno del combate
    public static bool OnPlayerTurn = true;
    
    //caracteristicas y el nombre
    //Trae los datos de unit mago, hacker, virus1, virus2
    private Unit MagoUnit; 
    private Unit HackerUnit;
    private Unit Enemy1Unit;
    private Unit Enemy2Unit;


    //Estos son los estados
     public BattleStates states;
     
    //aqui pone el objeto booleano de batalla en verdadero
    private bool _battle = true;
    
    //Aqui trae el score data que es un scriptable object
    public ScoreData scoreData;

    //Trae la clase virus1
    private Virus1 _virus1System;

    //Trae la clase hacker
    private Hacker _hackerSystem;

    //Aca trea la clase Mago
    private Mago _magoSystem;
    
    //Aqui el texto en pantalla
    public Text dialogText; 

    //Aqui setea el valor de la vida de  cada virus
    public static int  lifeBattleVirus1 = 100;

    //Aqui setea el valor de la vida del virus 2
    public static int  lifeBattleVirus2 = 100;
    
    //Acá hace una variable estatica donde dice es player eligiendo
    public static bool IsPlayerChoosing=false;

    //Acá hace una variable estatica donde dice el enemigo elige
    public static bool IsEnemyChoosing=false;

    //Objeto collision Zona
    public GameObject collisionZone2;

    //Objeto StartLevel2
    private StartLevel2 _startLevel2;

    //
    private AccessBattlePanal accesoBattlePanal;

    //private CharacterController1 _characterController1;
    
    // Start is called before the first frame update
    void Start()
    {
        this.accesoBattlePanal = GetComponent<AccessBattlePanal>();
        states = BattleStates.Start; 
        
        _startLevel2 = collisionZone2.GetComponent<StartLevel2>();
       StartCoroutine(SetUpBattle());
    }

    void Update() 
    {
        
        if (OnPlayerTurn)
        {
            states = BattleStates.PlayerTurn;
            StartCoroutine(PlayerTurn());
        }
        else if (!OnPlayerTurn)
        {
            states = BattleStates.Enemyturn;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator SetUpBattle()
    {
        dialogText.text = "SetUp Battle";
        yield return new WaitForSeconds(1f);
            
        MagoUnit = mago.GetComponent<Unit>();
        HackerUnit = hacker.GetComponent<Unit>();
        Enemy1Unit = virus1.GetComponent<Unit>();
        Enemy1Unit = virus2.GetComponent<Unit>();
    
        dialogText.text = "Battle 1";
        yield return new WaitForSeconds(1f);

        OnPlayerTurn = true;
    }

    IEnumerator EnemyTurn()
    {
        dialogText.text = "Enemy Turn";
        
        //Choose State
        IsEnemyChoosing = true;
        
        if (scoreData.score==0) //el score es la vida de los players
        {
            states = BattleStates.Lost;
            EndBattle();
        }
        yield return new WaitForSeconds(2f);
    }

    IEnumerator PlayerTurn()
    {
        yield return new WaitForSeconds(2f);
        
        if (states != BattleStates.PlayerTurn)
        {
            yield break;
        }
        dialogText.text = "Choose a Player";
        
        //Choose a Player and Attack 
        
        IsPlayerChoosing = true;

        if (lifeBattleVirus1 == 0&& lifeBattleVirus2==0)
        {
            states = BattleStates.Won;
            EndBattle();
        }

        yield return new WaitForSeconds(2f);
    }
    
    void EndBattle()
    
    {
        if (states == BattleStates.Won)
        {
            dialogText.text = "You won the battle!";
            //activa el script que detecta la colision para entrar a la segunda zona de batalla(teletransportador)
            //_characterController1.GoBackCity();
            _startLevel2.enabled = true;
            
        }
        else if (states == BattleStates.Lost)
        {
            dialogText.text = "You loose";
        }
    }

    
}
