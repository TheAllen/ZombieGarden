using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetStartVolume : MonoBehaviour {

	private MusicManager music;

	// Use this for initialization
	void Start () {
		music = GameObject.FindObjectOfType<MusicManager> ();
		if (music) {
			float volume = PlayerPrefManager.GetMasterVolume ();
			music.ChangeVolume (volume);
		} else {
			Debug.Log ("There is no Music Manager");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
