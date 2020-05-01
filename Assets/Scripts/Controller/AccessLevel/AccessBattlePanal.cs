using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AccessBattlePanal : MonoBehaviour
{
    [SerializeField] private Transform objectBattleOnePlayer; //Objeto de la posicion del player en batalla (Arriba del panal)
    [SerializeField] private Transform objectBattleTwoPlayer; //Objeto de la posicion del mago en batalla (Arriba del panal)
    [SerializeField] private Transform initialPosition;  //Objeto posicion inicial

    //Objetos personajes
    public GameObject objetoActivarBattleMachine; //Objeto que activa la batalla arriba del Panal
    public GameObject objetoPlayerOne;
    public GameObject objetoPlayerTwo;

    private bool accesoAutorizadoNO;
    private bool ingresarPanal;


    void Start()
    {
        this.accesoAutorizadoNO = false;
        this.ingresarPanal = false;
    }


    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            validarTarjetaAcceso();

            if (this.ingresarPanal)
            {                
                this.objetoPlayerOne.SetActive(false);
                this.objetoPlayerTwo.SetActive(false);
                //this.objetoPlayerOne.transform.position = this.objetoPlayerOne.transform.position;
                //this.objectBattleTwoPlayer.transform.position = this.objetoPlayerTwo.transform.position;
            }
        }
    }

    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.accesoAutorizadoNO = false;
        }
    }

    public bool getAccesoAutorizadoNO()
    {
        return this.accesoAutorizadoNO;
    }

    public bool getIngresoPanal()
    {
        return this.ingresarPanal;
    }

    private void validarTarjetaAcceso()
    {
        int tarjetaAccesoPanal = PlayerPrefs.GetInt("TarjetaAccesoPanal", 0);

        if (tarjetaAccesoPanal != 5)
            this.accesoAutorizadoNO = true;
        else
        {
            this.ingresarPanal = true;
            this.accesoAutorizadoNO = false;
        }


    }


    
}
