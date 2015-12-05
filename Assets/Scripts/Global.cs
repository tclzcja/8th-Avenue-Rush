using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour
{
	private static GameObject Zombie;
	
	// Use this for initialization
	void Start ()
	{
		Zombie = Resources.Load ("Prefabs/Zombie") as GameObject;
		Respawn ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void Respawn ()
	{
		int R = Random.Range (1, 3);
		if (R == 1) {
			Instantiate (Zombie, new Vector3 (0, 5, 10), Zombie.transform.rotation);
		} else {
			Instantiate (Zombie, new Vector3 (0, 5, 6), Zombie.transform.rotation);
		}
				
		
		Invoke ("Respawn", 0.2F);	
	}
	
}
