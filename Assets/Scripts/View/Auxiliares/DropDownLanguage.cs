using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownLanguage : MonoBehaviour
{
    public Text lblLabelLanguage, txtSound, lblActivateSound,
        txtVolumeSound, txtTextSoundAux, txtTextVolumeAux, txtTextActiveSoundAux, txtButtonText;
    public Dropdown ddLanguage;
    private int valor = 10;
 
    void Update()
    {
        this.valor = PlayerPrefs.GetInt("LenguajeGuardado", 0);

        if (this.ddLanguage.value == 0)        
            this.TextoIngles();        
        else
            this.TextoEspanol();

    }



    private void TextoEspanol()
    {
        this.lblLabelLanguage.text = "Lenguaje";
        this.txtSound.text = "Sonido";
        this.lblActivateSound.text = "Activar";
        this.txtVolumeSound.text = "Volumen Sonido";
        this.txtTextSoundAux.text = "Sonido Auxiliar";
        this.txtTextVolumeAux.text = "Volumen Auxiliar";
        this.txtTextActiveSoundAux.text = "Activar";
        this.txtButtonText.text = "VOLVER";

        PlayerPrefs.SetInt("LenguajeGuardado", 1);
        PlayerPrefs.Save();

    }

    private void TextoIngles()
    {
        this.lblLabelLanguage.text = "Languague";
        this.txtSound.text = "Sound";
        this.lblActivateSound.text = "Activate";
        this.txtVolumeSound.text = "Volume Sound";
        this.txtTextSoundAux.text = "Sound Aux";
        this.txtTextVolumeAux.text = "Volume Aux";
        this.txtTextActiveSoundAux.text = "Activate";
        this.txtButtonText.text = "BACK";

        PlayerPrefs.SetInt("LenguajeGuardado", 0);
        PlayerPrefs.Save();
    }




}
