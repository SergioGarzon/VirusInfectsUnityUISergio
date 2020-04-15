using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActivateParticleSystem : MonoBehaviour
{
    public ParticleSystem particulasRayos;
    public ParticleSystem particulasLighting;
    public ParticleSystem particulasElectricidad;
    public ParticleSystem particulasPrefab;


    void Start()
    { 
    }


    void Update()
    {
        if (HabilitarBotones.particulasActivador == 1)
        {
            this.ActivarParticulas(1);
            HabilitarBotones.particulasActivador = 0;
        }                      
         
        if (HabilitarBotones.particulasActivador == 2)
        {            
            this.ActivarParticulas(2);
            HabilitarBotones.particulasActivador = 0;
        }         
                

        if (HabilitarBotones.particulasActivador == 3)
        {                                
            this.ActivarParticulas(3);
            HabilitarBotones.particulasActivador = 0;
        }
                

    }

    private void SetearDatos()
    {
        HabilitarBotones.particulasActivador = 0;
    }


    public void ActivarParticulas(int value)
    {
        switch(value)
        {
            case 1: this.particulasRayos.Play(); break;
            case 2: this.particulasLighting.Play(); break;
            case 3: this.particulasElectricidad.Play(); this.particulasPrefab.Play(); break;
        }
        
    }



}
