using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attacker))]
public class Fox : MonoBehaviour {

	private Attacker attacker;
	private Animator animator;

	// Use this for initialization
	void Start () {
		attacker = GetComponent<Attacker> ();
		animator = GetComponent<Animator> ();
		//attacker.SetSpeed (0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){

		GameObject obj = col.gameObject;

		if (!obj.GetComponent<Defender> ()) {
			return; //leave method.
		} 

		if (obj.GetComponent<Stone> ()) {
			animator.SetTrigger ("trigger jump");
		} else {
			animator.SetBool ("isAttacking", true);
			attacker.Attack (obj);
		}
	}
}
