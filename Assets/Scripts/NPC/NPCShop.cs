using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCShop : MonoBehaviour
{
    //Aca lo que hace es traer el objeto panel NPC
    public GameObject dialogPanelNPC;

    //Acá lo que hace es traer el panel SHOP
    public GameObject shopPanel;

    //Aca lo que hace es traer el objeto Text
    private Text dialogText;


    //TEXTO EN EL TEXT DE ACUERDO AL NPC
    private string _textNpc;

    //CONTADOR
    private int _counter = 0;

    //MÉTODO START
    private void Start()
    {
        //Lo que hace es traer el objeto texto del PANEL
        dialogText = dialogPanelNPC.GetComponentInChildren<Text>();
    }


    //Evento de MOUSE, cuando lo pulsa, hace lo siguiente
    void OnMouseDown()
    {
        //Hasta aqui llega
        Debug.Log("It works!");

        //Pulso una vez aúmenta en 1 (uno),
        //Ahora aumenta en 2 (dos)
        _counter++;

        //Aqui va a escribir el texto
        ChooseText();

        //Corrutina de tiempo
        StartCoroutine(ShowDialogText());

        //Espera un tiempo
        StartCoroutine(Waiting());

        //Si la corrutina es mayor o igual 3, en la primer vuelta no hace nada
        if (_counter >= 3)
        {
            shopPanel.SetActive(true);
        }


        
        IEnumerator ShowDialogText()
        {
            //Activa el texto en el NPC
            dialogPanelNPC.SetActive(true);
            dialogText.text = _textNpc;
            yield return new WaitForSeconds(3f);
            //Luego desactiva el texto
            dialogPanelNPC.SetActive(false);
        }


        //Aqui cuenta
        void ChooseText()
        {
            //Si el valor es 1 (uno)
            if (_counter == 1)
            {
                //Da este texto con el valor 1 (uno)
                //No deberias estar aqui, es muy peligroso
                _textNpc = "You shouldn't be here, it's very dangerous...";
            }
            else if (_counter == 2)
            {
                //Si el valor es 2 (dos)
                //I do not know you, if I do not know you do not pass Long! You do not interest me.
                _textNpc = "I do not know you, if I do not know you do not pass Long! You do not interest me.";
            }
            else if (_counter == 3)
            {
                //Si el valor es 3 (tres)
                //¿Qué estas buscando?
                _textNpc = "What are you looking for?";
                //StartCoroutine(Waiting());
                //shopPanel.SetActive(true);
            }
            else if (_counter > 3)
            {
                //Otra vez tú
                _textNpc = "You again?";
                //StartCoroutine(Waiting());
                //shopPanel.SetActive(true);
            }
        }

        //Corrutina de tiempo
        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(5f);
        }
    }
}
