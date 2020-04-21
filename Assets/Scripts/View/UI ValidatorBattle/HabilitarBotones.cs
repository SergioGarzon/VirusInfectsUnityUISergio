using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HabilitarBotones : MonoBehaviour
{
    public Button BtnEscapeBack, BtnCharlie, BtnAtif, BtnBack, BtnBug, BtnSteal, BtnPixel,
        BtnShock, BtnLighning, BtnElectricity, BtnVirusOne, BtnVirusTwo;

    public static int particulasActivador;
    public static bool activarParticulaVirus;

    private int valorParaActivar;
    public static int valorVirusAtacado;

    public GameObject objetoVirus1;
    public GameObject objetoVirus2;

    private int valorRetornarActivarTexto;

    public GameObject objetoBattleMachine;
    public BattleMachine battleMachine;

    public GameObject playerObject;
    public Player clasePlayer;
    public GameObject objetoPlayer;
    public Hacker hackerDatos;
    public GameObject objetoMago;
    public Mago magoDatos;


    void Start()
    {
        HabilitarBotones.particulasActivador = 0;
        HabilitarBotones.activarParticulaVirus = false;
        this.valorRetornarActivarTexto = 0;

        this.battleMachine = this.objetoBattleMachine.GetComponent<BattleMachine>();
        this.clasePlayer = this.playerObject.GetComponent<Player>();
        this.hackerDatos = this.objetoPlayer.GetComponent<Hacker>();
        this.magoDatos = this.objetoMago.GetComponent<Mago>();
    }


    void Update()
    {
        /*
        if (this.battleMachine.isActiveAndEnabled && this.battleMachine.ActivateButtonStatePlayerEnemy() == 1)
        {
            
        }*/
        if (this.battleMachine.getActivateButtonStatePlayerEnemy() == 1)
        {
            BotonesIniciales();
        }


        if(this.battleMachine.getActivateButtonStatePlayerEnemy() == 2)
        {
            this.PanelesVeracidadActivacion(false, false, false, true, false, false, false, false, false, false, true, true);          
        }
    }



    public void BotonesIniciales()
    {
        if (this.objetoVirus1.activeSelf && this.objetoVirus2.activeSelf)
        {
            this.PanelesVeracidadActivacion(true, true, true, false, false, false, false, false, false, false, false, false);
        }
        else
        {
            this.PanelesVeracidadActivacion(false, false, false, false, false, false, false, false, false, false, false, false);
        }
        
    }


    public void ActivarCharlie()
    {
        ActivarBotonesVirus(1);
    }

    public void ActivarAtif()
    {
        ActivarBotonesVirus(2);
    }

    private void ActivarBotonesVirus(int valor)
    {
        if (this.objetoVirus1.activeSelf || this.objetoVirus2.activeSelf)
        {
            Debug.Log("Hasta aqui ingresa!");
            this.battleMachine.setBotonPresionado(valor);
        }        
    }




    public void PanelesVeracidadActivacion(bool pnlEsc, bool pnlCharlie, bool pnlAtif, bool pnlBack, bool pnlBug,
        bool pnlSteal, bool pnlPixel, bool pnlShock, bool pnlLight, bool pnlElect, bool pnlVirus1, bool pnlVirus2)
    {
        this.BtnEscapeBack.gameObject.SetActive(pnlEsc);
        this.BtnCharlie.gameObject.SetActive(pnlCharlie);
        this.BtnAtif.gameObject.SetActive(pnlAtif);
        this.BtnBack.gameObject.SetActive(pnlBack);
        this.BtnBug.gameObject.SetActive(pnlBug);
        this.BtnSteal.gameObject.SetActive(pnlSteal);
        this.BtnPixel.gameObject.SetActive(pnlPixel);
        this.BtnShock.gameObject.SetActive(pnlShock);
        this.BtnLighning.gameObject.SetActive(pnlLight);
        this.BtnElectricity.gameObject.SetActive(pnlElect);
        this.BtnVirusOne.gameObject.SetActive(pnlVirus1);
        this.BtnVirusTwo.gameObject.SetActive(pnlVirus2);
    }

}


            
        /*

        if(this.battleMachine.habilitarComandoPlayer == 0)
        {
            if (!this.objetoVirus1.activeSelf && !this.objetoVirus2.activeSelf)
            {               
                this.PanelesVeracidadActivacion(false, false, false, false, false, false, false, false, false, false, false, false);
                Debug.Log("Deshabilita los botones");
            }
                
        }*/
       
  

/*
    public void ActivarCharlie()
    {
        if (this.objetoVirus1.activeSelf || this.objetoVirus2.activeSelf)
        {
            Debug.Log("Activa a Charlie");
            this.PanelesVeracidadActivacion(false, false, false, true, true, true, true, false, false, false, false, false);
            this.clasePlayer.setActivadoresMagoHacker(1);
            
        }
            
    }

    public void ActivarAtif()
    {
        if (this.objetoVirus1.activeSelf || this.objetoVirus2.activeSelf)
        {
            Debug.Log("Activar a Atif");
            this.PanelesVeracidadActivacion(false, false, false, true, false, false, false, true, true, true, false, false);
            this.clasePlayer.setActivadoresMagoHacker(2);
        }
    }

    public void ActivarAtaqueHacker(int ataqueValor)
    {

        if (this.objetoVirus1.activeSelf || this.objetoVirus2.activeSelf)
        {

            Debug.Log("Hasta aqui llega, y da el valor: " + ataqueValor);

            switch (ataqueValor)
            {
                case 1: this.hackerDatos.setAttackHacker(ataqueValor);                        
                        break;  //Bug
                case 2: this.hackerDatos.setAttackHacker(ataqueValor);
                        break;  //Bugbreak;  //Steal
                case 3: this.hackerDatos.setAttackHacker(ataqueValor); 
                        break;  //Bugbreak;  //Pixel
            }

            this.PanelesVeracidadActivacion(false, false, false, true, false, false, false, false, false, false, true, true);
        }
        
        
    }


    public void ActivarAtaqueVirus(int valor, int personajeSeleccionado)
    {
        
        Debug.Log("Valor: " + valor);
        Debug.Log("Personaje Seleccionado: " + personajeSeleccionado);


        if(personajeSeleccionado == 1)
        {
            //Ataque del hacker
            this.hackerDatos.setVirusAttack(valor);
        }
        
        if(personajeSeleccionado == 2)
        {
            
            //Aqui falta traer la clase mago
        }

        BotonesIniciales();
    }



    /*

    public void BotonesInicialesVirus1()
    {
        if (this.objetoVirus1.activeSelf) {
            this.BotonesIniciales();
        }

    }

    public void BotonesInicialesVirus2()
    {
        if (this.objetoVirus2.activeSelf)
        {
            this.BotonesIniciales();
        }

    }

    
    public void ActivarBtnVirus()
    {
        if (this.objetoVirus1.activeSelf || this.objetoVirus2.activeSelf)
            this.PanelesVeracidadActivacion(false, false, false, true, false, false, false, false, false, false, true, true);
        if (!this.objetoVirus1.activeSelf && !this.objetoVirus2.activeSelf)
            this.PanelesVeracidadActivacion(false, false, false, false, false, false, false, false, false, false, false, false);

    }

    public void ActivarParticulasRayo(int valor)
    {
        HabilitarBotones.particulasActivador = valor;
    }

    public void virusAtacado(int virusAtacado)
    {
        if (virusAtacado == 1 && this.objetoVirus1.activeSelf)
        {
            HabilitarBotones.valorVirusAtacado = virusAtacado;
            virusAtacado = 0;
            this.SetearValorVirusNoExiste(0);
        }


        if (virusAtacado == 2 && this.objetoVirus2.activeSelf)
        {

            HabilitarBotones.valorVirusAtacado = virusAtacado;
            virusAtacado = 0;
            this.SetearValorVirusNoExiste(0);
        }


        if (!this.objetoVirus1.activeSelf)
            this.SetearValorVirusNoExiste(1);

        if (!this.objetoVirus2.activeSelf)
            this.SetearValorVirusNoExiste(2);


        if (!this.objetoVirus1.activeSelf && !this.objetoVirus2.activeSelf)
            this.SetearValorVirusNoExiste(3);

    }

    public void SetearValorVirusNoExiste(int valorVirusNoEsta)
    {
        this.valorRetornarActivarTexto = valorVirusNoEsta;
    }

    public int getRetornarValorVirusNoExiste()
    {
        return this.valorRetornarActivarTexto;
    }

    */

   