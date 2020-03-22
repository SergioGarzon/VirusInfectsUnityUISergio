using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContollerCharacter : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    public CharacterController player;
    private Vector3 inputPlayer; //Acá definimos el Input de nuestro jugador, va a incorporar el verticalmove
                                 // y el horizontalmove
    public float playerSpeed;
    private Vector3 movePlayer;

    public Camera mainCamara; //Esto es para la camara
    private Vector3 camForward;  //Esto es para que siga la camara camForward significa adelante y hacia atrás
    private Vector3 camRight;  //Esto es para que siga la camara a la derecha

    void Start() {
        player = GetComponent<CharacterController>();
    }


    void Update() {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        inputPlayer = new Vector3(horizontalMove, 0, verticalMove);
        inputPlayer = Vector3.ClampMagnitude(inputPlayer, 1); //Esto es para que se mantenga siempre en 1 (uno)

        direccionCamara(); //Aquí llama al método de la cámara

        movePlayer = inputPlayer.x * camRight + inputPlayer.z * camForward;
        
        player.transform.LookAt(player.transform.position + movePlayer);

        player.Move(movePlayer * playerSpeed * Time.deltaTime);

        Debug.Log(player.velocity.magnitude);
    }

    //A esto lo excluye ya directamente tenia la linea de código siguiente
    //player.Move(new Vector3(horizontalMove, 0, verticalMove) * playerSpeed);
    //Fue movido al metodo update()
    private void FixedUpdate() {
        
    }

    /*
        Este método es para que el personaje siga la cámara
    */
    void direccionCamara() {
        camForward = mainCamara.transform.forward;
        camRight = mainCamara.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}
