using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		int T = (int)(Time.time - Transmission.Gametime);
		
		this.guiText.text = "You survived for " + T.ToString () + " seconds.\n";
		
		if (T < 30) {
			this.guiText.text += "Well, Even my grandma can do that.";
		}
		
		if (T >= 30 && T < 60) {
			this.guiText.text += "Not bad, you almost beat the gorilla tester.";
		}
		
		if (T >= 60 && T < 90) {
			this.guiText.text += "It's inappropriate to use bugs in the game for a good record.";
		}
		
		if (T >= 90) {
			this.guiText.text += "Seriously?! You cheated in this tiny little peaceful innouncent game?!";
		}
		
		this.guiText.color = new Color (0F, 0F, 0F, 0F);
		StartCoroutine ("Fade_Body");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.anyKey) {
			Application.LoadLevel ("0");
		}
	}
	
	IEnumerator Fade_Body ()
	{
		
		for (int i=0; i<20; i++) {
			this.guiText.color = new Color (0F, 0F, 0F, this.guiText.color.a + 0.05F);
			yield return new WaitForSeconds(0.1F);
		}
		
	}
}
