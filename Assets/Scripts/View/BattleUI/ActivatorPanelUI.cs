using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivatorPanelUI : MonoBehaviour
{
    public GameObject panalAccesonNoAutorizado;
    public GameObject objetoValidadorAcceso;
    private AccessBattlePanal battleNewWorld;
    public GameObject panelActivateEnergy;

    //Esete es el panel de BATALLA UI
    public GameObject panalBattleUI;

    public RawImage imagen1;
    public RawImage imagen2;


    //Desactivamos el canvas de LAURA
    public Canvas canvasLaura;

    void Start()
    {
        this.battleNewWorld = this.objetoValidadorAcceso.GetComponent<AccessBattlePanal>();
    }

    void Update()
    {
        this.validarAccesoAutorizado();

        if (this.battleNewWorld.getIngresoPanal())
        {
            if(this.battleNewWorld.getChargeEnergy())
            {
                this.panelActivateEnergy.gameObject.SetActive(true);
            }
            else
            {
                this.panelActivateEnergy.gameObject.SetActive(false);
            }
            
            if(this.battleNewWorld.getIngresoPanal() && !this.battleNewWorld.getChargeEnergy() && this.battleNewWorld.getValorReturn() == 1)
            {
                this.panelActivateEnergy.gameObject.SetActive(false);
                this.canvasLaura.gameObject.SetActive(false);
                this.imagen1.gameObject.SetActive(false);
                this.imagen2.gameObject.SetActive(false);
                this.panalBattleUI.gameObject.SetActive(true);
            }
        }


    }

    private void validarAccesoAutorizado()
    {
        if (this.battleNewWorld.getAccesoAutorizadoNO())
            this.panalAccesonNoAutorizado.gameObject.SetActive(true);
        else
            this.panalAccesonNoAutorizado.gameObject.SetActive(false);

    }
}
