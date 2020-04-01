using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ValidatorNamePlayer : MonoBehaviour
{
    public Button btnPlayGame;
    public GameObject panelValidator;
    public Text personajeElegido;
    public InputField txtNombreIngresado;
    
    void Start()
    {
    }

    public void ValidarNombreIngresado()
    {
        if(this.txtNombreIngresado.text.Equals(""))
        {
            this.panelValidator.SetActive(true);
            return;
        }


        SceneManager.LoadScene("Prototipo2_MundoAbierto");
            
    }

}
