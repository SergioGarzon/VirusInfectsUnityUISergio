using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCShop : MonoBehaviour
{
    public GameObject dialogPanelNPC;
    public GameObject shopPanel;
    private Text dialogText;
    private string _textNpc;
    private int _counter = 0;

    private void Start()
    {
        dialogText = dialogPanelNPC.GetComponentInChildren<Text>();
    }

    void OnMouseDown()
    {
        Debug.Log("It works!");
        _counter++;
        ChooseText();
        StartCoroutine(ShowDialogText());
        StartCoroutine(Waiting());
        if (_counter >= 3)
        {
            shopPanel.SetActive(true);
        }

        IEnumerator ShowDialogText()
        {
            dialogPanelNPC.SetActive(true);
            dialogText.text = _textNpc;
            yield return new WaitForSeconds(3f);
            dialogPanelNPC.SetActive(false);
        }

        void ChooseText()
        {
            if (_counter == 1)
            {
                _textNpc = "You shouldn't be here, it's very dangerous...";
            }
            else if (_counter == 2)
            {
                _textNpc = "I do not know you, if I do not know you do not pass Long! You do not interest me.";
            }
            else if (_counter == 3)
            {
                _textNpc = "What are you looking for?";
                //StartCoroutine(Waiting());
                //shopPanel.SetActive(true);
            }
            else if (_counter > 3)
            {
                _textNpc = "You again?";
                //StartCoroutine(Waiting());
                //shopPanel.SetActive(true);
            }
        }

        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(5f);
        }
    }
}
