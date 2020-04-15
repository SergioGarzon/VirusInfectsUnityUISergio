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

    void Start()
    {
        HabilitarBotones.particulasActivador = 0;
        HabilitarBotones.activarParticulaVirus = false;
    }

    public void BotonesIniciales()
    {
        this.PanelesVeracidadActivacion(true, true, true, false, false, false, false, false, false, false, false, false);
    }

    public void ActivarCharlie()
    {
        this.PanelesVeracidadActivacion(false, false, false, true, true, true, true, false, false, false, false, false);
    }

    public void ActivarAtif()
    {
        this.PanelesVeracidadActivacion(false, false, false, true, false, false, false, true, true, true, false, false);
    }

    public void ActivarBtnVirus()
    {
        this.PanelesVeracidadActivacion(false, false, false, true, false, false, false, false, false, false, true, true);
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

    public void ActivarParticulasRayo(int valor)
    {
        HabilitarBotones.particulasActivador = valor;
    }



}
