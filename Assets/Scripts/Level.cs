using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.anyKey) {
			Transmission.Gametime = Time.time;
			Application.LoadLevel ("1");
		}
	}
}
