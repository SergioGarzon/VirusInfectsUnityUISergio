using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLanguageMenu : MonoBehaviour
{
    public UnityEngine.UI.Text txtBtnPlayGame, txtBtnOptions, txtBtnScores, txtBtnCredits, txtBtnQuitGame, txtBtnBack, txtBtnContinue;
    private string[] texto;
    private Text[] textoBotonesVector;

    void Start()
    {
        texto = new string[] {"PLAY GAME", "OPTIONS", "SCORES", "CREDITS", "QUIT GAME",
            "INICIAR JUEGO", "OPCIONES", "CREDITOS", "SALIR"};


        if (!PlayerPrefs.HasKey("Language"))
        {
            PlayerPrefs.SetInt("Language", 0);
        }

        CargarDatosBotones();
    }


    private void CargarDatosBotones()
    {
        int value = PlayerPrefs.GetInt("Language", 0);

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
        int j = 6;

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
                this.txtBtnBack.text = "B A C K";
            }
            else
                this.txtBtnBack.text = "V O L V E R";


            if (this.txtBtnContinue != null)
            {
                this.txtBtnContinue.text = "C O N T I N U E";
            }
            else
            {
                this.txtBtnContinue.text = "C O N T I N U A R";
            }

        }


    }

}

