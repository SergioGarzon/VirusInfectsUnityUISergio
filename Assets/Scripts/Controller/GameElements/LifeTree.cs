using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTree : MonoBehaviour
{
    public ScoreData scoreData;
    public Text dialogText;

    private void OnCollisionStay(Collision col)
    {

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
        }
    }
}