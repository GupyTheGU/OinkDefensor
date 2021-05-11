using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
	public static LevelController instance;
	public GameObject letrero;
	public Character arian;
	public bool playerEnable=true;
	public bool muerto;
	bool win=false;
	string[] _script= new string[]{
		"«¡¡Muy bien!!... frustraste el ataque sopresa enemigo»",
		"«cough cough...Sabía que el bosque no cometería un error»",
		"«¿Quieres volver a jugar?...»",
		"«¡¡NOOOO!!... no puede ser...»",
		"«Hemos fallado en detener el ataque esta vez, pero yo confío en mi héroe»",
		"«¡¡Una derrota sólo sirve para hacerte más fuerte!!...»",
		"«¿Quieres volver a jugar?...»"
	};
	int final = -1;

	void Awake() {
		instance = this;
	}
	// Use this for initialization
	void Start () {
		playSong("Chemical");
		arian = CharacterManager.instance.GetCharacter("Arian",enableOnStart:false);
	}
	
	// Update is called once per frame
	void Update () {
		if(EnemyManager.instance.numEnemigos==0 && final == -1){
			playSong("ByeByeBrain!");
			playerEnable = false;
			letrero.GetComponent<TextMesh>().text= "!LO HICISTE!";
			letrero.SetActive(true);
			final=0;
			win = true;
			arian.say(_script[final]);
			final++;
		}
		if(muerto && final == -1){
			playSong("SimpleSadness");
			playerEnable = false;
			letrero.gameObject.SetActive(true);
			final=3;
			arian.say(_script[final]);
			final++;
		}

		if(final != -1){
			if(Input.GetButtonDown("Fire1")){
				if(final < _script.Length){
					arian.say(_script[final]);
					final++;
					if(final == 3 && win){ final=_script.Length;}
				}else{
					DialogueSystem.instance.Close();
					SceneManager.LoadScene("BulletHell");
				}
			}
		}
	}

	public void playSong(string songName,float maxVolume = 1f,float pitch = 1f, float startingVolume=0,bool playOnStart=true,bool loop = true){
		AudioClip song = Resources.Load<AudioClip>(string.Format("Audio/Music/{0}",songName));
		AudioManager.instance.PlaySong(song, maxVolume, pitch, startingVolume, playOnStart, loop);
	}

	public void playSFX(string sfxName, float _volume = 1f, float _pitch = 1f){
		AudioClip sfx = Resources.Load<AudioClip>(string.Format("Audio/SFX/{0}",sfxName));
		AudioManager.instance.PlaySFX(sfx, _volume, _pitch);
	}
}
