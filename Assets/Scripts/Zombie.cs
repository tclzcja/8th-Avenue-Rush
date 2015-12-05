using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour
{
	private float Speed = 200F;
	private int Life = 3;
	private GameObject Player;
	private bool Attack_Cooldown = true;

	// Use this for initialization
	void Start ()
	{
		this.Player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		Walk ();
		Attack ();
	}
	
	void Be_Hit ()
	{
		this.Life -= 1;
		if (this.Life <= 0) {
			Object.Destroy (this.gameObject, 0F);
		}
	}
	
	void Walk ()
	{
		this.transform.LookAt (Player.transform);
		this.rigidbody.AddRelativeForce (this.transform.forward * -Speed);
	}
	
	void Attack ()
	{
		if ((Vector3.Distance (this.transform.position, Player.transform.position) <= 7F) && Attack_Cooldown) {
			Debug.Log ("Attack");
			this.Attack_Cooldown = false;
			Invoke ("Attack_Unlock", 0.25F);
			Component P = Player.GetComponent ("Player");
			P.BroadcastMessage ("Be_Hit");
		}
	}
	
	void Attack_Unlock ()
	{
		this.Attack_Cooldown = true;
	}
}
