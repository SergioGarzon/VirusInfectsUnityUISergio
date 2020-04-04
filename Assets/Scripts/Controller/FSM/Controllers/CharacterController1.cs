using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CharacterController1 : MonoBehaviour
{
    [SerializeField] private Transform _panalBattle;
    [SerializeField] private Transform _magoBattlePosition;

    [SerializeField] private Transform _initialPosition;

    public Text dialogText;
    
    public ScoreData scoreData;

    public GameObject mago;

    private SimpleMovement _simpleMovement;

    private FollowOne _followOne;

    public NavMeshAgent _navMeshAgent;

    public GameObject panelBattleUI;

    public GameObject camara1;
    public GameObject camara2;

    //public GameObject panelAutorizacion;

    



    // Start is called before the first frame update
    void Start()
    {
        _simpleMovement = GetComponent<SimpleMovement>();
        _followOne = mago.GetComponent<FollowOne>();
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //bool validar = false;

        _navMeshAgent.enabled = false;
        float currentaceleration=_navMeshAgent.acceleration;
        
        if (other.gameObject.CompareTag("Teleport1") )
        {
            //validar = this.validarAutorizacion();

            //if (!validar) return;

            //if(validar)
            //{
                Debug.Log("Hasta aqui llega excelente");
                transform.position = _panalBattle.position;
                mago.transform.position = _magoBattlePosition.position;
                _simpleMovement.enabled = false;
                _followOne.enabled = false;

                this.camara1.SetActive(false);
                this.camara2.SetActive(true);
                this.panelBattleUI.SetActive(true);
            //}
            



        }
        /*else if (other.gameObject.CompareTag("GoBack"))
        {
            Debug.Log("ola we");
            transform.position = _initialPosition.position;
            
        }*/

        //if(validar)
        //{
            _simpleMovement._speed = 0;
            _navMeshAgent.acceleration = 0f;
            _navMeshAgent.enabled = true;
            _simpleMovement._speed = 15;
            _navMeshAgent.acceleration = currentaceleration;
        //}
        
    }

    /*private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("LifeTree"))
        {
            dialogText.text = "Score ++";
            scoreData.score = scoreData.score++;
            Debug.Log("life tree");
        }
    }*/

    public void GoBackCity()
    {
        _navMeshAgent.enabled = false;
        float currentaceleration=_navMeshAgent.acceleration;
        transform.position = _initialPosition.position;
        mago.transform.position = _initialPosition.position;
        _simpleMovement.enabled = true;
        _followOne.enabled = true;
        
        _simpleMovement._speed=0;
        _navMeshAgent.acceleration = 0f;
        _navMeshAgent.enabled = true;
        _simpleMovement._speed=15;
        _navMeshAgent.acceleration = currentaceleration;
    }

    /*
    private bool validarAutorizacion()
    {
        int valor = PlayerPrefs.GetInt("ValorGuardadoTarjeta", 0);

        if (valor != 2)
        {
            this.panelAutorizacion.SetActive(true);
            return false;
        }

        return true;
    }*/
}
