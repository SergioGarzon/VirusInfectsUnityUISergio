using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLanguageMenu : MonoBehaviour
{
    public UnityEngine.UI.Text txtBtnPlayGame, txtBtnOptions, txtBtnScores, txtBtnCredits, txtBtnQuitGame, txtBtnBack;
    private string[] texto;
    private Text[] textoBotonesVector;

    void Start()
    {
        texto = new string[] {"P L A Y  G A M E", "O P T I O N S", "S C O R E S", "C R E D I T S", "Q U I T  G A M E",
            "I N I C I A R  J U E G O", "O P C I O N E S", "C R E D I T O S", "S A L I R"};


        if (!PlayerPrefs.HasKey("Language"))
        {
            PlayerPrefs.SetInt("Language", 0);
        }

        CargarDatosBotones();
    }


    private void CargarDatosBotones()
    {
        int value = PlayerPrefs.GetInt("Language", 0);

        if (this.txtBtnBack == null)
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
        if (valorInglesEspanol == 0)
            this.txtBtnBack.text = "B A C K";
        else
            this.txtBtnBack.text = "V O L V E R";






    }

}

