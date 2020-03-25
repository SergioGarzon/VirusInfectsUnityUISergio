using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Windows.Input;

public class SaveDataSelectPlayer : MonoBehaviour
{
    public GameObject panelActivate;
    public InputField inputValueName;
    public GameObject panelInformationError;
    public Button botonHacker;
    public Button botonAlquimista;

    // Start is called before the first frame update
    void Start()
    {
        this.panelActivate.SetActive(false);
        this.panelInformationError.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivatePanelValidationName()
    {
        if(inputValueName.text.Equals(""))
        {
            this.panelInformationError.SetActive(true);
            this.panelActivate.SetActive(false);
        }
        else
        {            
            this.panelActivate.SetActive(true);
            this.panelInformationError.SetActive(false);
            this.botonAlquimista.enabled = false;
            this.botonHacker.enabled = false;
            this.inputValueName.enabled = false;
        }
    }
}
