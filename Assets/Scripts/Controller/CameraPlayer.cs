using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public Vector3 distanciaCamaraPersonaje; //Distancia que va a haber entre la camara y nuestro jugador
    private Transform target;
    [Range(0, 1)] public float rango; //Eso entre parentesis Range es para ponerle un rango 
                                          //en este caso de 0 a 1, en el Editor de Unity va a aparecer como un slider
    public GameObject objeto;
    public float sensibilidadMovimientoCamara;


    void Start()
    {
        this.target = objeto.transform;

    }

    //Last Update es lo que se ejecuta al final
    void LateUpdate()
    {
        //Aqui ponemos la posicion de nuestra camara

        //Vector.Lerp va a hacer mover la posicion de un objeto desde su vector hasta otro vector
        //La camara se mueva desde su propia posicion (transform.position, hasta la posicion del objetive, el 
        // + offset es para apartar. lerpValue es una velocidad)
        //transform.position = Vector3.Lerp(transform.position, this.target.position + this.distanciaCamaraPersonaje, rango);

        /*
        this.distanciaCamaraPersonaje = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * this.sensibilidadMovimientoCamara, Vector3.up) * this.target;
        */
        //transform.position = this.target.position;

        //transform.LookAt(this.target);
    }

}
