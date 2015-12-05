using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	private float Speed;
	
	// Use this for initialization
	void Start ()
	{
		this.Speed = 5000F;
		this.rigidbody.AddRelativeForce (Vector3.forward * Speed);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void OnCollisionEnter (Collision collision)
	{	
		if (collision.gameObject.tag == "Zombie") {
			Debug.Log ("Boom");
			this.rigidbody.useGravity = true;
			Component Z = collision.gameObject.GetComponent ("Zombie");
			Z.BroadcastMessage ("Be_Hit");
			
			this.BroadcastMessage ("Deactivate", SendMessageOptions.DontRequireReceiver);
			
			collision.gameObject.BroadcastMessage("Activate", SendMessageOptions.DontRequireReceiver);
			collision.gameObject.BroadcastMessage("Shake", SendMessageOptions.DontRequireReceiver);
		}
		
		if (collision.gameObject.tag == "Floor") {
			Object.Destroy (this.gameObject, 1.0F);
			this.BroadcastMessage ("Deactivate", SendMessageOptions.DontRequireReceiver);
		}
		
		if (collision.gameObject.tag == "Wall") {
			Object.Destroy (this.gameObject, 1.0F);
			this.rigidbody.useGravity = true;
			this.BroadcastMessage ("Deactivate", SendMessageOptions.DontRequireReceiver);
		}
	}
}
