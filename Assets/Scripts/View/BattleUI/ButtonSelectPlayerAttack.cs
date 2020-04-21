using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelectPlayerAttack : MonoBehaviour
{
    public GameObject objetoActivadorBotones;
    public HabilitarBotones botones;


    void Start()
    {
        this.botones = this.objetoActivadorBotones.GetComponent<HabilitarBotones>();
    }

    public void SelectHacker()
    {
        this.botones.ActivarCharlie();
    }

    public void SelectAtif()
    {
        this.botones.ActivarAtif();
    }

    /*
    public void SelectMago()
    {
        this.botones.ActivarAtif();
    }

    


    public void SelectAtackHacker(int valor)
    {
        this.botones.ActivarAtaqueHacker(valor);
    }

    public void SeleccionarVirus(int valor) {
        this.botones.ActivarAtaqueVirus(valor, 1);
    }

    public void SeleccionarVirus2(int valor)
    {
        this.botones.ActivarAtaqueVirus(valor, 2);
    }
    */
}