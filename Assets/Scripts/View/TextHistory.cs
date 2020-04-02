using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class TextHistory : MonoBehaviour
{
    public UnityEngine.UI.Text textScene;
    private string texto;
    public UnityEngine.UI.Slider sldProgressBarChargeScene;
    

    private void Start() {
        int x = PlayerPrefs.GetInt("LenguajeGuardado", 0);
        bool veracidad = false;
        string filePath = "";

        if(x == 0) {
            veracidad = this.verificarExistencia("DatosIngles");
            

            if (veracidad)
            { 
                filePath = Application.persistentDataPath + "/DatosIngles";
                CargarDatosArchivos(filePath);
            }
                
            else
                this.texto = "No hay datos";

            //this.texto = "An CyberPunk City was attack for daemond virus was destroy the system all";
        }
        else {

            veracidad = this.verificarExistencia("DatosEspanol");

            

            if (veracidad)
            {
                filePath = Application.persistentDataPath + "/DatosEspanol.txt";
                CargarDatosArchivos(filePath);
            }                
            else
                this.texto = "No hay datos";
            
            /*this.texto = "Una ciudad CyberPunk fue atacada por un virus maligno que daño todo el sistema " +
                         "solo queda un punto para dañar y es posible que el virus pueda llegar, " + 
                         "nuestra misión será evitar que llegue y dañe todo asi no se pierda por completo el " +
                         "objetivo del juego";*/
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


    public void CargarDatosArchivos(string nameFile)
    {
        StreamReader sr = new StreamReader(nameFile);


        while(!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            this.texto += line;
        }


        sr.Close();

    }


    private bool verificarExistencia(string existe)
    {
        Debug.Log(existe);


        return File.Exists(Application.persistentDataPath + "/" + existe);
    } 


}

