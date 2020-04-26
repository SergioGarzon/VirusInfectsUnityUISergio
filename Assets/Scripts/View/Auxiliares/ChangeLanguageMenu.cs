using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLanguageMenu : MonoBehaviour
{
    public UnityEngine.UI.Text txtBtnPlayGame, txtBtnOptions, txtBtnScores, txtBtnCredits, txtBtnQuitGame, txtBtnBack, txtBtnContinue;
    private string[] texto;
    private Text[] textoBotonesVector;
    private int value;

    void Start()
    {
        texto = new string[] {"PLAY GAME", "OPTIONS", "LOAD GAME", "CREDITS", "QUIT GAME",
            "INICIAR JUEGO", "OPCIONES", "CARGAR JUEGO", "CREDITOS","SALIR"};


        value = PlayerPrefs.GetInt("LenguajeGuardado", 0);
        /*
        if (!PlayerPrefs.HasKey("LenguajeGuardado"))
        {
            //No entra acá ya que si existe
            PlayerPrefs.SetInt("LenguajeGuardado", 0);
            PlayerPrefs.Save();
        }*/

        CargarDatosBotones();
    }


    private void CargarDatosBotones()
    {
        
        Debug.Log(value);

        if (this.txtBtnBack == null && this.txtBtnContinue == null)
        {
            this.textoBotonesVector = new Text[] { this.txtBtnPlayGame, this.txtBtnOptions, this.txtBtnScores, this.txtBtnCredits, this.txtBtnQuitGame };


            if (value == 0)
                this.TextButtonMethodEnglish();

            if (value == 1)
                this.TextButtonMethodSpanish();
        }
        else
            this.TextBackEnglishSpanish(value);

    }

    private void TextButtonMethodEnglish()
    {
        int j = 0;

        for (int i = 0; i < this.textoBotonesVector.Length; i++)
        {
            if (j < 5)
                this.textoBotonesVector[i].text = this.texto[j];

            j++;
        }
    }

    private void TextButtonMethodSpanish()
    {
        int j = 5;

        for (int i = 0; i < this.textoBotonesVector.Length; i++)
        {
            if (j < 10)
                this.textoBotonesVector[i].text = this.texto[j];

            j++;
        }
    }

    private void TextBackEnglishSpanish(int valorInglesEspanol)
    {

        if (this.txtBtnBack != null)
        {

            if (valorInglesEspanol == 0)
            {
                this.txtBtnBack.text = "BACK";
            }
            else
                this.txtBtnBack.text = "VOLVER";                

        }

        if (this.txtBtnContinue != null)
        {
            if(valorInglesEspanol == 0)
            {
                this.txtBtnContinue.text = "CONTINUE";
            }
            else
            {
                this.txtBtnContinue.text = "CONTINUAR";
            }
        }
        


    }

}

