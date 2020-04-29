using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyCard : MonoBehaviour
{
    [SerializeField] [Range(1, 5)] public int valorTarjeta; //Este es un valor que se asigna al crear la tarjeta
    public GameObject panel;
    public Texture texturaEspanol;
    public Texture texturaIngles;
    public RawImage imagen;
    public InventoryItem Card;
    private InventoryScript _inventoryScript;

    private void Start()
    {
        _inventoryScript = new InventoryScript();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("AQUI ENTRA");

            if (this.VerificarLenguaje() == 0)
            {
                this.imagen.texture = this.texturaIngles;
            }
            else
            {
                this.imagen.texture = this.texturaEspanol;
            }

            this.gameObject.SetActive(true);
            panel.gameObject.SetActive(true);

            if (this.valorTarjeta == 8)
                Card.amount += 10;
            if (this.valorTarjeta == 7)
                Card.amount += 8;

            Destroy(this.gameObject);


            if (this.valorTarjeta == 2)
                PlayerPrefs.SetInt("ValorGuardadoTarjeta", valorTarjeta);

            if (this.valorTarjeta == 4)
                PlayerPrefs.SetInt("TarjetaAccesoArcade", valorTarjeta);
        }
    }
    private int VerificarLenguaje()
    {
        int valor = 0;

        if (PlayerPrefs.HasKey("LenguajeGuardado"))
            valor = PlayerPrefs.GetInt("LenguajeGuardado", 0);

        return valor;
    }
}