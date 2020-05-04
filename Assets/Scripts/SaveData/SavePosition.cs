using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SavePosition : MonoBehaviour
{

    public GameObject objetoPlayer;
    public GameObject objetoPlayerTwo;
    public static int cargarPosicionInicial = 0;
    private NavMeshAgent positionObject;

    void Start()
    {
        this.positionObject = this.objetoPlayerTwo.GetComponent<NavMeshAgent>();
        CargarPosition();
    }


    private void CargarPosition()
    {

        if (SavePosition.cargarPosicionInicial == 1)
        {
            objetoPlayer.transform.position = new Vector3(PlayerPrefs.GetFloat("x"),
            PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));

            this.positionObject.destination = this.objetoPlayerTwo.transform.position;

            /*objetoPlayerTwo.transform.position = new Vector3(PlayerPrefs.GetFloat("x2"),
                PlayerPrefs.GetFloat("y2"), PlayerPrefs.GetFloat("z2"));
            */

        }




    }

    public void GuardarPosition()
    {
        PlayerPrefs.SetFloat("x", objetoPlayer.transform.position.x);
        PlayerPrefs.SetFloat("y", objetoPlayer.transform.position.y);
        PlayerPrefs.SetFloat("z", objetoPlayer.transform.position.z);

        PlayerPrefs.SetFloat("x2", objetoPlayerTwo.transform.position.x);
        PlayerPrefs.SetFloat("y2", objetoPlayerTwo.transform.position.y);
        PlayerPrefs.SetFloat("z2", objetoPlayerTwo.transform.position.z);
    }

}
