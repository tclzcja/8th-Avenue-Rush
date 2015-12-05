using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	private static GameObject Bullet;
	private static GameObject GUI_Life;
	private static GameObject GUI_Time;
	private static GameObject GUI_Fuel;
	private float Speed = 150F;
	private Vector3 Position_Mouse_Screen;
	private Vector3 Position_Player_Screen;
	private Vector3 Position_Mouse_World;
	private int Life = 100;
	private int Fuel = 100;
	private bool Shoot_Cooldown = true;
	
	void Walk ()
	{
		if (Input.GetKey (KeyCode.D)) {
			this.gameObject.rigidbody.AddForce (new Vector3 (1, 0, 0) * this.Speed);
		}
		if (Input.GetKey (KeyCode.A)) {
			this.gameObject.rigidbody.AddForce (new Vector3 (-1, 0, 0) * this.Speed);
		}
		if (Input.GetKey (KeyCode.W)) {
			this.gameObject.rigidbody.AddForce (new Vector3 (0, 0, 1) * this.Speed);
		}
		if (Input.GetKey (KeyCode.S)) {
			this.gameObject.rigidbody.AddForce (new Vector3 (0, 0, -1) * this.Speed);
		}
	}
	
	void Rotate ()
	{
		this.Position_Player_Screen = Camera.main.WorldToScreenPoint (transform.position);
		this.Position_Mouse_Screen = Input.mousePosition;
		
		this.Position_Mouse_Screen.z = this.Position_Player_Screen.z;
		
		this.Position_Mouse_World = Camera.main.ScreenToWorldPoint (this.Position_Mouse_Screen);
		this.Position_Mouse_World.y = this.transform.position.y;
		
		this.transform.LookAt (this.Position_Mouse_World);
		
		Camera.main.transform.position = this.transform.position + Vector3.up * 20F + Vector3.forward * -10F;
	}
	
	void Shoot ()
	{
		if (Input.GetMouseButton (0) && this.Shoot_Cooldown) {
			GameObject BO = Instantiate (Player.Bullet) as GameObject;
			BO.transform.position = this.transform.position + 3F * this.transform.forward + (1.04F + Random.Range (-0.2F, 0.2F)) * this.transform.right + (1.49F + Random.Range (-0.2F, 0.2F)) * this.transform.up;
			BO.transform.rotation = this.transform.rotation;
			BO.transform.Rotate (new Vector3 (0F, 0, 0));
			
			this.Shoot_Cooldown = false;
			Invoke ("Shoot_Unlock", 0.05F);
			
			audio.Play ();
		}
	}
				
	void Shoot_Unlock ()
	{
		this.Shoot_Cooldown = true;
	}
	
	void Boost ()
	{
		if (Input.GetKeyDown (KeyCode.Space) && this.Fuel >= 50) {
			this.gameObject.rigidbody.AddRelativeForce (Vector3.forward * Speed * 100);
			this.Fuel -= 50;
			this.BroadcastMessage ("Activate");
		}
		
		
	}
	
	void Be_Hit ()
	{
		this.Life -= 1;
		
		GameObject.Find ("Camera").BroadcastMessage ("Shake");
		this.BroadcastMessage ("Blink");
		this.BroadcastMessage ("Dark");
		
		if (this.Life == 0) {
			this.Interface ();
			StartCoroutine ("Lightoff");
		}
	}
	
	void Interface ()
	{
		if (this.Life >= 0) {
			(GUI_Life.GetComponent ("GUIText") as GUIText).text = this.Life.ToString ();
		}
		(GUI_Time.GetComponent ("GUIText") as GUIText).text = ((int)(Time.time - Transmission.Gametime)).ToString ();
		(GUI_Fuel.GetComponent ("GUIText") as GUIText).text = this.Fuel.ToString ();
	}

	// Use this for initialization
	void Start ()
	{
		Player.GUI_Life = GameObject.Find ("GUI_Life");
		Player.GUI_Time = GameObject.Find ("GUI_Time");
		Player.GUI_Fuel = GameObject.Find ("GUI_Fuel");
		
		Bullet = Resources.Load ("Prefabs/Bullet") as GameObject;
	}
	
	void Refuel ()
	{
		if (this.Fuel < 100) {
			this.Fuel += 1;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{	
		Walk ();
		Rotate ();		
		Shoot ();
		Boost ();
		Interface ();
		Refuel ();
	}
	
	IEnumerator Lightoff ()
	{
		for (int i=0; i<30; i++) {
			GameObject.Find ("Player_Light").light.intensity -= 0.1F;
			GameObject.Find ("Player_Light").light.range -= 0.3F;
			Debug.Log (GameObject.Find ("Player_Light").light.intensity.ToString ());
			yield return new WaitForSeconds(0.03F);
		}
		
		
		Application.LoadLevel ("2");
	}
	
	
}
