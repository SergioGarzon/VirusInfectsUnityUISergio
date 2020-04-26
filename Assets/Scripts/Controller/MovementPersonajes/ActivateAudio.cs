using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ActivateAudio : MonoBehaviour
{
    public GameObject objetoPlayer;
    public AudioSource audio;
    public AudioClip audioClip;
    public GameObject objeto;


    void Start()
    {
        this.audio = GetComponent<AudioSource>();
        this.audio.clip = this.audioClip;
    }


    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Aqui entro");

        if (other.gameObject == this.objetoPlayer)
        {
            Debug.Log("Aqui entro para reproducir audio");
            this.objeto.SetActive(false);
            this.audio.Play();
            
        }
    }


    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject == this.objetoPlayer)
        {

            Debug.Log("Aqui entro para reproducir audio");

            this.audio.Stop();
            this.objeto.SetActive(true);
        }
    }





}
