using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateHiddenMenu : MonoBehaviour
{
    public GameObject panelMenuHelp, panelController, panelHideenMenu, panelUIBattle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F1))
            this.ActivatePaneles(true, false, false, false);
        if (Input.GetKey(KeyCode.F2))
            this.ActivatePaneles(false, true, false, false);
        if (Input.GetKey(KeyCode.F5))
            this.ActivatePaneles(false, false, false, false);
        if (Input.GetKey(KeyCode.F12))
            this.ActivatePaneles(false, false, true, false);
        if (Input.GetKey(KeyCode.F8))
            this.ActivatePaneles(false, false, false, true);
    }


    public void ActivatePaneles(bool pn1, bool pn2, bool pn3, bool pn4)
    {
        this.panelMenuHelp.SetActive(pn1);
        this.panelController.SetActive(pn2);
        this.panelHideenMenu.SetActive(pn3);
        this.panelUIBattle.SetActive(pn4);

    }
}
