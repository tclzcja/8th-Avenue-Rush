using UnityEngine;
using System.Collections;

public class Shaking : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void Shake ()
	{
		StartCoroutine ("Shake_Body");
		Debug.Log ("fdsa");		
		
	}
	
	IEnumerator Shake_Body ()
	{
		this.transform.position += Vector3.right * 0.2F;
		yield return new WaitForSeconds(0.05F);
		
		this.transform.position -= Vector3.right * 0.2F;
		yield return new WaitForSeconds(0.05F);
		
		this.transform.position -= Vector3.right * 0.2F;
		yield return new WaitForSeconds(0.05F);
		
		this.transform.position += Vector3.right * 0.2F;
		yield return new WaitForSeconds(0.05F);
		
		this.transform.position += Vector3.up * 0.2F;
		yield return new WaitForSeconds(0.05F);
		
		this.transform.position -= Vector3.up * 0.2F;
		yield return new WaitForSeconds(0.05F);
		
		this.transform.position -= Vector3.up * 0.2F;
		yield return new WaitForSeconds(0.05F);
		
		this.transform.position += Vector3.up * 0.2F;
		yield return 0;
		
	}
}
