using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {
	public Slider VolumeSlider, diffSlider;
	public LevelManager levelManager;

	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		VolumeSlider.value = PlayerPrefManager.GetMasterVolume ();
		diffSlider.value = PlayerPrefManager.GetDifficulty ();
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.ChangeVolume (VolumeSlider.value);
	}

	public void SaveAndExit(){
		PlayerPrefManager.SetMasterVolume(VolumeSlider.value);
		PlayerPrefManager.SetDifficulty (diffSlider.value);
		levelManager.LoadLevel("Start Menu");
	}

	public void SetDefault(){
		VolumeSlider.value = 0.8f;
		diffSlider.value = 2f;
	}
}
