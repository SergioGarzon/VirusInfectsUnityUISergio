using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenMenuPanelCard : MonoBehaviour
{
    public GameObject objetoPanel;

    void Start()
    {  
    }

    public void OcultarPanel()
    {
        this.objetoPanel.SetActive(false);
    }

}
