using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour {

	Rigidbody rb;

	bool hasLanded;
	bool thrown;

	Vector3 initPosition; 

	public int diceValue;

	public DiceSide[] diceSides;


	void Start(){
		rb = GetComponent<Rigidbody> ();
		initPosition = transform.position;
		rb.useGravity = false;
	}

	void Update(){


		if(Input.GetKeyDown(KeyCode.Mouse0)){
			RollAgain ();
		}

		if (rb.IsSleeping () && !hasLanded && thrown) {
			hasLanded = true;
			rb.useGravity = false;

			SideValueCheck ();
		}
	}

	void RollDice (){
		
		if (!thrown && !hasLanded) {
			thrown = true;
			rb.useGravity = true;
			rb.AddTorque (Random.Range (0, 500), Random.Range (0, 500), Random.Range (0, 500));
		} else if (thrown && hasLanded) {
			Reset ();
		}
	}

	void Reset (){
		
		transform.position = initPosition;
		thrown = false;
		hasLanded = false;
		rb.useGravity = false;
	}

	void RollAgain(){
		
		Reset ();
		thrown = true;
		rb.useGravity = true;
		rb.AddTorque (Random.Range (0, 500), Random.Range (0, 500), Random.Range (0, 500));
	}


	void SideValueCheck(){
		diceValue = 0;

		foreach (DiceSide side in diceSides) {
			if (side.OnGround ()) {
				diceValue = side.sideValue;
				Debug.Log ("Has tirado " + diceValue);
			}
		}
	}
}
