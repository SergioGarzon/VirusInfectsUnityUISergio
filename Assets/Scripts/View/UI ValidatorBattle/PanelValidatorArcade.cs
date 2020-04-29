using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelValidatorArcade : MonoBehaviour
{

    public GameObject panelInformationValidator;
    public GameObject objetoValidadorPanel;
    private ValidatorArcade validArcade;
    public Text textoArcade;

    void Start()
    {
        this.validArcade = this.objetoValidadorPanel.GetComponent<ValidatorArcade>();
    }

    void Update()
    {
        int lenguaje = PlayerPrefs.GetInt("LenguajeGuardado", 0);

        if (this.validArcade.getValidatorArcade())
        {
            Debug.Log("Ingresa a la colision al menos");



            int valorTarjeta = PlayerPrefs.GetInt("TarjetaAccesoArcade", 0);

            if (valorTarjeta == 4)
            {
                Debug.Log("No ingresa aqui");
                if (lenguaje == 0) //Ingles 
                {
                    this.textoArcade.text = "COMMING SOON";
                }
                else
                {
                    this.textoArcade.text = "PROXIMAMENTE";
                }



            }
            else
            {
                if (lenguaje == 0) //Ingles 
                {
                    this.textoArcade.text = "AUTHORIZED PERSONAL ONLY";
                }
                else
                {
                    this.textoArcade.text = "SOLO PERSONAL AUTORIZADO";
                }
            }

            this.panelInformationValidator.SetActive(true);


        }

        if (!this.validArcade.getValidatorArcade())
        {
            this.panelInformationValidator.SetActive(false);
        }
    }
}
