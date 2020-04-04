using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyCard : MonoBehaviour
{
    [SerializeField] [Range(1, 4)]public int valorTarjeta; //Este es un valor que se asigna al crear la tarjeta
    public GameObject panel;
    public Texture texturaEspanol;
    public Texture texturaIngles;
    public RawImage imagen;


    void Start()
    {
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Debug.Log("hasta aca llega");
            
            if(this.VerificarLenguaje() == 0) {
                this.imagen.texture = this.texturaIngles;
            }
            else
            {
                this.imagen.texture = this.texturaEspanol;
            }

            panel.SetActive(true);
            Destroy(this.gameObject);

            PlayerPrefs.SetInt("ValorGuardadoTarjeta", valorTarjeta);

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
