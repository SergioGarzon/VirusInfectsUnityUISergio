using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPlayerMovement : MonoBehaviour
{
    public Vector3 offset; //Distancia que va a haber entre la camara y nuestro jugador
    private Transform target; 
    [Range (0, 1)] public float lerpValue; //Eso entre parentesis Range es para ponerle un rango 
                                          //en este caso de 0 a 1
    public GameObject objeto;
    public float sensibilidad;


    void Start() {
        this.target = objeto.transform;
        
    }

    //Last Update es lo que se ejecuta al final
    void LateUpdate() {
        //Aqui ponemos la posicion de nuestra camara

        //Vector.Lerp va a hacer mover la posicion de un objeto desde su vector hasta otro vector
        //La camara se mueva desde su propia posicion (transform.position, hasta la posicion del objetive, el 
        // + offset es para apartar. lerpValue es una velocidad)
        transform.position = Vector3.Lerp(transform.position, this.target.position + offset, lerpValue);

        this.offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * this.sensibilidad, Vector3.up) * this.offset;

        //transform.position = this.target.position;

        transform.LookAt(this.target);
    }


}
