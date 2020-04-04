using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HabilitarBotones : MonoBehaviour
{
    public Button BtnEscapeBack, BtnCharlie, BtnAtif, BtnBack, BtnBug, BtnSteal, BtnPixel,
        BtnShock, BtnLighning, BtnElectricity, BtnVirusOne, BtnVirusTwo;

    public void BotonesIniciales()
    {
        this.BtnEscapeBack.gameObject.SetActive(true);
        this.BtnCharlie.gameObject.SetActive(true);
        this.BtnAtif.gameObject.SetActive(true);
        this.BtnBack.gameObject.SetActive(false);
        this.BtnBug.gameObject.SetActive(false);
        this.BtnSteal.gameObject.SetActive(false);
        this.BtnPixel.gameObject.SetActive(false);
        this.BtnShock.gameObject.SetActive(false);
        this.BtnLighning.gameObject.SetActive(false);
        this.BtnElectricity.gameObject.SetActive(false);
        this.BtnVirusOne.gameObject.SetActive(false);
        this.BtnVirusTwo.gameObject.SetActive(false);
    }

    public void ActivarCharlie()
    {
        this.BtnEscapeBack.gameObject.SetActive(false);
        this.BtnCharlie.gameObject.SetActive(false);
        this.BtnAtif.gameObject.SetActive(false);
        this.BtnBack.gameObject.SetActive(true);
        this.BtnBug.gameObject.SetActive(true);
        this.BtnSteal.gameObject.SetActive(true);
        this.BtnPixel.gameObject.SetActive(true);
        this.BtnShock.gameObject.SetActive(false);
        this.BtnLighning.gameObject.SetActive(false);
        this.BtnElectricity.gameObject.SetActive(false);
        this.BtnVirusOne.gameObject.SetActive(false);
        this.BtnVirusTwo.gameObject.SetActive(false);

    }

    public void ActivarAtif()
    {
        this.BtnEscapeBack.gameObject.SetActive(false);
        this.BtnCharlie.gameObject.SetActive(false);
        this.BtnAtif.gameObject.SetActive(false);
        this.BtnBack.gameObject.SetActive(true);
        this.BtnBug.gameObject.SetActive(false);
        this.BtnSteal.gameObject.SetActive(false);
        this.BtnPixel.gameObject.SetActive(false);
        this.BtnShock.gameObject.SetActive(true);
        this.BtnLighning.gameObject.SetActive(true);
        this.BtnElectricity.gameObject.SetActive(true);
        this.BtnVirusOne.gameObject.SetActive(false);
        this.BtnVirusTwo.gameObject.SetActive(false);
    }

    public void ActivarBtnVirus()
    {
        this.BtnEscapeBack.gameObject.SetActive(false);
        this.BtnCharlie.gameObject.SetActive(false);
        this.BtnAtif.gameObject.SetActive(false);
        this.BtnBack.gameObject.SetActive(true);
        this.BtnBug.gameObject.SetActive(false);
        this.BtnSteal.gameObject.SetActive(false);
        this.BtnPixel.gameObject.SetActive(false);
        this.BtnShock.gameObject.SetActive(false);
        this.BtnLighning.gameObject.SetActive(false);
        this.BtnElectricity.gameObject.SetActive(false);
        this.BtnVirusOne.gameObject.SetActive(true);
        this.BtnVirusTwo.gameObject.SetActive(true);
    }


    public void ActivarParticulasRayo()
    {

    }



}
