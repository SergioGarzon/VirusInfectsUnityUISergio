using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
	[SerializeField] private float step = 1f;
	public float speed = 1f;
	private Vector3 nextPosition;


	void Start()
	{
		this.nextPosition = this.transform.position;

		GameObject camera = GameObject.Find("Main Camera");
		camera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10f);
		camera.transform.SetParent(this.transform);

	}


	void Update()
	{
		if (Input.GetAxis("Horizontal") < 0) //Si mueve UP 
			this.nextPosition = transform.position + Vector3.forward;

		if (Input.GetAxis("Horizontal") > 0)  //Si mueve Down
			this.nextPosition = transform.position + Vector3.back;

		if (Input.GetAxis("Vertical") < 0)  //Si mueve LEFT
			this.nextPosition = transform.position + Vector3.left;

		if (Input.GetAxis("Vertical") > 0)  //Si mueve RIGHT
			this.nextPosition = transform.position + Vector3.right;

		StartCoroutine(CorrutinaMagoCaminaCorre());

		transform.position = Vector3.MoveTowards(this.transform.position, this.nextPosition, Time.deltaTime * speed);



	
	}

	IEnumerator CorrutinaMagoCaminaCorre()
	{
		yield return new WaitForSeconds(3000f);
	}
}


/*
 *
	private Animator animatorMago;
	public GameObject mago;

	private Animator animatorHacker;
	public GameObject hacker;

	En el void Start() tenes que poner
	this.animatorMago = mago.GetComponent<Animator>();
	this.animatorHacker = hacker.GetComponent<Animator>();

	Poner cuando el mago camina los animators 
	variableAnimator.SetTrigger("Jump");
	variableAnimator.ResetTrigger("Jump");

*/
