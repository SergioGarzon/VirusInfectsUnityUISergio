using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirusPlayerScore : MonoBehaviour
{   
    public static CharacterController virusEnemy;
    public static CharacterController playerPrincipal;
    public static CharacterController playerSecondary;
    public static CharacterController playerTercery;

    public ParticleSystem sistemParticlesEnemy;

    private Text textPlayerScore;    
    private int score;

    void Start() {
    }



    void OnCollisionEnter(Collision colision) {
        if (colision.collider.CompareTag ("Bioware")) {
             scoreMinus();
        }
        
        if (colision.collider.CompareTag ("Alquimist")) {
             scoreMinus();
        }
        
        if (colision.collider.CompareTag ("Hacker")) {
             scoreMinus();
        }
    }

    void scoreMinus() {
        score -= 1;
        this.textPlayerScore.text = "" + score;
    }





}
