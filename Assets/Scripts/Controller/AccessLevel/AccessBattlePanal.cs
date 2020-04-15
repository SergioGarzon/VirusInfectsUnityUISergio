using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AccessBattlePanal : MonoBehaviour
{
    [SerializeField] private Transform panelBattle; //Objeto de la posicion del player en batalla
    [SerializeField] private Transform magoBattlePosition; //Objeto de la posicion del mago en batalla
    [SerializeField] private Transform initialPosition;  //Objeto posicion inicial

    public GameObject objetoMago;
    private SimpleMovement movimientoSimple;
    private FollowOne seguirMagoAPlayer;
    private NavMeshAgent navMeshPlayer;

    private bool activatePanelUIBattle;
    private bool activatePanelAccessNoAutorized;

    void Start()
    {
        this.movimientoSimple = this.GetComponent<SimpleMovement>();
        this.seguirMagoAPlayer = this.objetoMago.GetComponent<FollowOne>();
        this.navMeshPlayer = this.gameObject.GetComponent<NavMeshAgent>();

        this.activatePanelUIBattle = false;
        this.activatePanelAccessNoAutorized = false;
    }

    void OnTriggerEnter(Collider other)
    {
        this.navMeshPlayer.enabled = false; //Deshabilito el NavMesh

        float actualAceleracion = this.navMeshPlayer.acceleration;

        if(other.gameObject.CompareTag("Teleport1"))
        {
            if(ValidadorTarjetaAcceso())
            {
                this.activatePanelUIBattle = true;
                this.activatePanelAccessNoAutorized = false;
                this.SetearDatos();
            } else
            {
                this.activatePanelUIBattle = false;
                this.activatePanelAccessNoAutorized = true;
            }
        }

        if(this.ValidadorTarjetaAcceso())
        {
            this.movimientoSimple.speed = 0;
            this.navMeshPlayer.acceleration = 0f;
            this.navMeshPlayer.enabled = true;

            this.movimientoSimple.speed = 15;
            this.navMeshPlayer.acceleration = actualAceleracion;
        }
        

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Teleport1"))
        {
            this.activatePanelAccessNoAutorized = false;
        }
    }

    private void SetearDatos()
    {
        //Acá lo que hago es setear las posiciones del player y mago
        this.transform.position = panelBattle.position;
        this.objetoMago.transform.position = this.magoBattlePosition.position;
        
        //Deshabilita el movimiento del player y el mago
        this.movimientoSimple.enabled = false;
        this.seguirMagoAPlayer.enabled = false;
    }

    public bool RetornarActivacionPanelUIBattle()
    {
        return this.activatePanelUIBattle;
    }


    public bool RetornarValorActivacionPanel()
    {
        return this.activatePanelAccessNoAutorized;
    }

    private bool ValidadorTarjetaAcceso()
    {
        int valor = PlayerPrefs.GetInt("ValorGuardadoTarjeta", 0);
        bool resultado = false;

        if (valor != 2) resultado = false;
        if (valor == 2) resultado = true;    

        return resultado;
    }

}
