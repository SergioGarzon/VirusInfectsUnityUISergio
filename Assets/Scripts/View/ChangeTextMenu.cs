using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ChangeText : MonoBehaviour
{
    public TMPro.TextMeshProUGUI txtTextMeshPro;
    public int value;

    // Start is called before the first frame update
    void Start()
    {
        string[] vecText = new string[] { "RESUME GAME", "BACK MENU INITIAL", "QUIT GAME", "CONTINUAR JUEGO", 
            "REGRESAR AL MENU", "QUITAR JUEGO"};

        int veracidad = PlayerPrefs.GetInt("Option", 0);

        this.txtTextMeshPro = GetComponent<TMPro.TextMeshProUGUI>();

        int valueLanguage = PlayerPrefs.GetInt("Language", 0);

        if(valueLanguage == 0)
        {
            switch(value)
            {
                case(0): this.txtTextMeshPro.text = vecText[0]; break;
                case(1): this.txtTextMeshPro.text = vecText[1]; break;
                case(2): this.txtTextMeshPro.text = vecText[2]; break;
            }
        }
        else
        {
            switch(value)
            {
                case (0): this.txtTextMeshPro.text = vecText[4]; break;
                case (1): this.txtTextMeshPro.text = vecText[5]; break;
                case (2): this.txtTextMeshPro.text = vecText[6]; break;
            }
        }
    }

}
