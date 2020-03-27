using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float horizontalMovement;
    public float verticalMovment;
    public CharacterController player;

    public float speedPlayer;

    void Start()
    {
        this.player = GetComponent<CharacterController>();
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovment = Input.GetAxis("Vertical");

        FixedUpdate();

    }


    public void FixedUpdate()
    {
        
    }
}
