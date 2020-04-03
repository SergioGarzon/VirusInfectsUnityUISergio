using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTree : MonoBehaviour
{
    public ScoreData scoreData;
    public Text dialogText;

    private Animator animator;
    public GameObject mago;

    private Animator animator2;
    public GameObject hacker;
     
    void Start()
    {
        animator = mago.GetComponent<Animator>();
        this.animator2 = hacker.GetComponent<Animator>();
    }

    


    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Hasta aqui llega");


        if (Input.GetKey(KeyCode.E))
        {
            if (scoreData.hLife == 100)
            {
                dialogText.text = "Score Full";
            }
            else
            {
                scoreData.hLife = scoreData.hLife + 10;
                scoreData.hLife = scoreData.hLife + 10;
                dialogText.text = "Score++";
            }

            animator.SetTrigger("MagoCargaVida");
            this.animator2.SetTrigger("CharlieRecibeVida");
        }
    }


}