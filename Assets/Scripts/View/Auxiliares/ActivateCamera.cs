using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCamera : MonoBehaviour
{
    public GameObject camara1;
    public GameObject camara2;
    public GameObject camara3;
    private int contador;
    
    void Awake()
    {
        this.contador = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.ActivarDesactivarCamara(true, false, false);
            this.contador = 1;
        }
            
        if (Input.GetMouseButtonDown(2))
        {
            this.ActivarDesactivarCamara(false, true, false);
            this.contador = 2;
        }
            
        if (Input.GetMouseButtonDown(1))
        {
            this.ActivarDesactivarCamara(false, false, true);
            this.contador = 0;
        }
            
    }

    private void ActivarDesactivarCamara(bool valor1, bool valor2, bool valor3)
    {
        this.camara1.SetActive(valor1);
        this.camara2.SetActive(valor2);
        this.camara3.SetActive(valor3);
    }


}
