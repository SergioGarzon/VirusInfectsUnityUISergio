using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHistory : MonoBehaviour
{
    public UnityEngine.UI.Text textScene;
    private string texto;
    public UnityEngine.UI.Slider sldProgressBarChargeScene;
    

    private void Start() {
        int x = PlayerPrefs.GetInt("Language", 0);

        if(x == 1) {
            this.texto = "An CyberPunk City was attack for daemond virus was destroy the system all";
        }
        else {
            this.texto = "Una ciudad CyberPunk fue atacada por un virus maligno que daño todo el sistema " +
                         "solo queda un punto para dañar y es posible que el virus pueda llegar, " + 
                         "nuestra misión será evitar que llegue y dañe todo asi no se pierda por completo el " +
                         "objetivo del juego";
        }

        StartCoroutine(FraseTexto(this.texto));

    }


    void Update() {
        this.sldProgressBarChargeScene.value += 100;//0.05f;        
    }

    IEnumerator FraseTexto(string frase) {
        int letra = 0;
        this.textScene.text = "";
        
        while(letra < frase.Length) {
            this.textScene.text += frase[letra];
            letra += 1;
            yield return new WaitForSeconds(0.1f);
        }
    }



}

