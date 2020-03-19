using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLanguageMenu : MonoBehaviour
{
    public UnityEngine.UI.Text txtBtnPlayGame, txtBtnOptions, txtBtnCredits, txtBtnQuitGame;
    private string[] texto;

    void Start()
    {
        texto = new string[] {"P L A Y  G A M E", "O P T I O N S", "C R E D I T S", "Q U I T  G A M E", 
            "I N I C I A R  J U E G O", "O P C I O N E S", "C R E D I T O S", "S A L I R" };

        if (PlayerPrefs.HasKey("Language"))
        {
            int value = PlayerPrefs.GetInt("Language", 0);

            if (value == 0)
            {
                this.TextButtonMethodEnglish();
            }
            
            
            if(value == 1)
            {
                this.TextButtonMethodSpanish();
            }
        }
    }


    private void TextButtonMethodEnglish()
    {
        this.txtBtnPlayGame.text = texto[0];
        this.txtBtnOptions.text = texto[1];
        this.txtBtnCredits.text = texto[2];
        this.txtBtnQuitGame.text = texto[3];
    }

    private void TextButtonMethodSpanish()
    {
        this.txtBtnPlayGame.text = texto[4];
        this.txtBtnOptions.text = texto[5];
        this.txtBtnCredits.text = texto[6];
        this.txtBtnQuitGame.text = texto[7];
    }

}

