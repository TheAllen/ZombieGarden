using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInOut : MonoBehaviour {

	public float fadeSpeed;

	private Image fadePanel;
	private Color currentColor = Color.black;

	void Start(){
		fadePanel = GetComponent<Image> ();
	}

	void Update(){
		if (Time.timeSinceLevelLoad < fadeSpeed) {
			//fade in 
			float alphaChange = Time.deltaTime / fadeSpeed;
			currentColor.a -= alphaChange;
			fadePanel.color = currentColor;
		} else {
			gameObject.SetActive (false);
		}
	}
}