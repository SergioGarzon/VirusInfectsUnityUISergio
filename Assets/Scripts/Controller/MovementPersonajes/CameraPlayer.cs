using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraPlayer : MonoBehaviour
{
    public Vector3 distanceCamera;
    private Transform targetPlayer;  //Este es el currentView
    
    public Transform objectCubo1;
    public Transform objectCubo2;


    public GameObject objectPlayer;
    [Range (0 , 1)] public float lerpValue;
    public float sensibilidad;
    
    private bool validationBattle;
    private bool validation1;
    private bool validation2;
    

    void Start()
    {
        this.targetPlayer = this.objectPlayer.transform;
        this.validationBattle = false;
        this.validation1 = false;
        this.validation2 = false;
    }

    void Update()
    {
        if (!this.objectPlayer.gameObject.activeSelf)
        {
            this.validationBattle = true;
            this.targetPlayer = this.objectCubo1.transform;
        }

        
        
        if(this.validation1)
        {
            this.targetPlayer = this.objectCubo2.transform;
            this.validation2 = true;   
        }

    }

    void LateUpdate()
    {
        
        //if(this.objectPlayer != null && !this.validationBattle)
        //{
            
            //this.distanceCamera = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * +sensibilidad, Vector3.up) * this.distanceCamera;

            
        if(this.validationBattle == false)
        {
            transform.position = Vector3.Lerp(transform.position, targetPlayer.position + distanceCamera, lerpValue);
            this.distanceCamera = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * +sensibilidad, Vector3.up) * this.distanceCamera;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, targetPlayer.position + distanceCamera, Time.deltaTime * 0.2f);
            StartCoroutine(CorrutinaEspera());
            this.validation1 = true;
        }

        
        if(this.validation2 == true)
        {
            transform.position = Vector3.Lerp(transform.position, targetPlayer.position + distanceCamera, Time.deltaTime * 1f);
            this.distanceCamera = new Vector3(-10, 1.2f, 5);
        }


        transform.LookAt(this.targetPlayer);            
       
    }

    IEnumerator CorrutinaEspera()
    {
        yield return new WaitForSeconds(100f);
    }

}


