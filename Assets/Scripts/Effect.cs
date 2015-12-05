using UnityEngine;
using System.Collections;

public class Effect : MonoBehaviour
{
	
	void Activate ()
	{
		if (this.particleSystem) {
			this.particleSystem.Play ();
		}
	}
	
	void Deactivate ()
	{
		if (this.light) {
			this.light.enabled = false;
		}
		
		if (this.renderer) {
			this.renderer.enabled = false;
		}
	}
	
	void Blink ()
	{
		if (this.light) {
			StartCoroutine ("Blink_Body");
		}
	}
	
	IEnumerator Blink_Body ()
	{
		for (int i=0; i<2; i++) {
			this.light.intensity *= 0.5F;
			yield return new WaitForSeconds(0.1F);
		}
		
		for (int i=0; i<2; i++) {
			this.light.intensity *= 2F;
			yield return new WaitForSeconds(0.1F);
		}
	}
	
	void Dark ()
	{
		if (this.light) {
			this.light.range -= 0.05F;
			Debug.Log (this.light.range.ToString());
		}
	}
}
