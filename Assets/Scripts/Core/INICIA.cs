using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class INICIA : MonoBehaviour {

	// Use this for initialization
	void Start () {
		playSong("SillyVillain");
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			playSFX("mouseSqueak");
			SceneManager.LoadScene("Intro");
		}
	}
	public void playSong(string songName,float maxVolume = 1f,float pitch = 1f, float startingVolume=0,bool playOnStart=true,bool loop = true){
		AudioClip song = Resources.Load<AudioClip>(string.Format("Audio/Music/{0}",songName));
		AudioManager.instance.PlaySong(song, maxVolume, pitch, startingVolume, playOnStart, loop);
	}

	public void playSFX(string sfxName, float _volume = 2f, float _pitch = 1f){
		AudioClip sfx = Resources.Load<AudioClip>(string.Format("Audio/SFX/{0}",sfxName));
		AudioManager.instance.PlaySFX(sfx, _volume, _pitch);
	}
}
