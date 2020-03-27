using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTree : MonoBehaviour
{
    public ScoreData scoreData;
    public Text dialogText;

    private void OnCollisionEnter(Collision col)
    {

        if (Input.GetKey(KeyCode.E))
            {

                scoreData.hLife = scoreData.hLife + 10;
                scoreData.hLife = scoreData.hLife + 10;
                dialogText.text = "Score++";
            }
            else
            {
                dialogText.text = "Score Full";
            }
        
        
    }
}
