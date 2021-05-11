
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {
	BackgroundController.LAYER layer; //para la capa de background
	public Character arian, peny, sPeny;
	int index = 0;
	bool toAdd=false;
	string[] _script = new string[]{
		"granja/FloatingOompa/footsteps/???/*pasos*",
		"-/-/chikens/Granjero A/«Ayer hubo luna llena...",
		"-/-/-/Granjero A/¡Fue una noche muy brillante!»",
		"-/-/footsteps/Granjero B/«¡Y que lo digas, nada que ver con la horrible vista de la ciudad!»",
		"-/-/-/Granjero A/«En la ciudad nunca se ve cielo como aquí»",
		"-/-/-/Granjero A/«Por eso siempre estan en sus telefonos esos»",
		"-/-/-/Granjero B/«Hasta el bosque oscuro estaba muy brillante a esa hora por la luna llena»",
		"-/-/pigToy1/Granjero A/«¡¿El bosque oscuro?!»",
		"-/-/-/Granjero B/«Eh.., sí»",
		"-/-/-/Granjero A/«¡¡¿Por qué estabas en ese bosque tan tarde?!!...",
		"-/-/-/Granjero A/Ahí es peligroso, mi sobrino fue disque a jugar un día y sigue que no ha vuelto»",
		"-/-/pigToy1/Granjero B/«!!»",
		"-/-/-/Granjero B/«Pues es que mi hija quería ir a tomar unas fotos para mandarle a sus amigos por el internet ese»",
		"-/-/-/Granjero A/«Quería estrenar su teléfono nuevo..,»",
		"-/-/-/Granjero A/«..,»",
		"-/-/-/Granjero B/«..,»",
		"-/-/-/Granjero B/«¡¡¡Le voy a decir que ya no vaya para alla!!!»",
		"-/-/footsteps/ /*pasos alejandose*",
		"-/-/pigToy1/Peny/«..,Oink»",
		"-/-/-/Peny/«Los granjeros siempre hablan de la luna",
		"-/-/pigToy1/Peny/«Dicen que está en el cielo...",
		"-/-/-/Peny/Dicen que es muy brillante y hermosa»",
		"-/-/pigToy1/Peny/«¡¡¡PERO PENY NO PUEDE VER AL CIELO!!!»",
		"-/-/-/Peny/ ",
		"-/-/-/Peny/«Peny también quiere verla...",
		"-/-/-/Peny/Una vez dijeron que se ve donde hay agua»",
		"-/-/pigToy1/Peny/«¡¡¡En el bosque hay un rio!!!»",
		"-/-/-/Peny/«O eso dijeron..,»",
		"-/-/pigToy1/Peny/«¡¡VOY A IR AL BOSQUE!!»",
		"-/-/-/Peny/«¡Escaparé de aquí!»",
		"-/-/spaceSwoosh/ /*tap tap tap*",
		"-/-/pigToy1/Granjero A/«¡¡OH!!»",
		"-/-/-/Granjero A/«¡No cerraste bie-!»",
		"-/-/-/Granjero B/«¡¡Corre!!»",
		"bosque/WinterNight/spaceSwoosh/ /*tap tap tap*",
		"-/-/pigToy1/Peny/«¿Es aquí?...",
		"-/-/-/Peny/Está muy oscuro, no veo el rí-»",
		"-/-/pigToy1/Peny/«¡¡Ahí está!!»",
		"-/-/pigToy1/Peny/«Pero no veo nada»",
		"-/-/-/Peny/«..,»",
		"-/-/-/Arian/«¿hmm?»",
		"-/-/-/Peny/«¿Será porque es de día?»",
		"-/-/boing/Arian/«..,»",
		"-/-/-/Arian/«¿Quien eres, pequeña?»",
		"-/-/pigToy1/Peny/«¡¡Oink!!»",
		"-/-/womanlaugh/Arian/«He he~»",
		"-/-/-/Arian/«Hace mucho tiempo que nadie llegaba a esta parte del bosque»",
		"-/-/-/Arian/«El río de este lugar es una leyenda entre los humanos»",
		"-/-/-/Arian/«En realidad es una prueba...",
		"-/-/-/Arian/El bosque oscuro escoge a alguien que entre y sea digno para convertirse en héroe»",
		"-/-/pigToy1/Peny/«..,»",
		"-/-/-/Arian/«,..mhm»",
		"-/-/-/Arian/«Bueno...",
		"-/-/-/Arian/aunque yo esperaba un caballero..,»",
		"-/-/-/Arian/«Fuiste tu pequeña, la elegida por el bosque»",
		"-/-/-/Arian/«Mi nombre es Arian»",
		"-/-/-/Arian/«Soy la diosa de este recinto y el bosque oscuro es mi compañero»",
		"-/-/pigToy1/Peny/«¿Diosa?,..¡¡¿Héroe?!!»",
		"-/-/womanlaugh/Arian/«He he~»",
		"-/-/-/Arian/«Puedo ver tu corazon puro y tu inocente deseo»",
		"-/-/-/Arian/«Una vez convertida en el héroe del bosque oscuro estarás cerca de lo que estas buscando»",
		"-/-/pigToy1/Peny/«!!»",
		"-/SimpleSadness/-/Arian/«Verás...",
		"-/-/-/Arian/Este mundo está en peligro»",
		"-/-/-/Peny/«¡¡Peligro!!»",
		"-/-/-/Arian/«Hay seres que viajaron desde muy lejos con el fin de destruir nuestro hogar»",
		"-/WinterNight/-/Arian/«¡¡Por eso te necesitamos pequeña!!»",
		"-/-/pigToy1/Peny/«¡¿Qué debe hacer Peny?!»",
		"-/-/-/Arian/«Las fuerzas enemigas del espacio exterior se preparan para atacar en este momento»",
		"-/-/-/Arian/«Su base de operaciones para este ataque se encuentra en la luna..,»",
		"-/-/-/Peny/«luna..,»",
		"-/-/-/Arian/«¡¡Debes ir y derrotarlos antes de que sea demasiado tarde!!»",
		"-/-/-/Arian/«¡¡EN EL NOMBRE DE ARIAN, TE CONCEDO EL TÍTULO DE HÉROE!!»",
		"-/-/spaceSwoosh/Super Peny/«!!»",
		"-/-/spaceSwoosh/Super Peny/«¿Qué es todo esto?»",
		"-/-/-/Arian/«Te he otorgado dones especiales que te servirán durnate la batalla»",
		"-/-/womanlaugh/Arian/«Espero que te gus-»",
		"-/ /explosion/Arian/«!!»",
		"-/-/futuristic/Super Peny/«¡¡¿Qué son esos ruidos?!!»",
		"-/-/explosion/Arian/«Parece que ya comenzaron a atacar..,»",
		"-/-/-/Arian/«¡¡Es hora del duelo!!»",
		"-/-/boing/Super Peny/«¿Q-Qué?!!!!!!!!!!!»"
	};
	// Use this for initialization
	void Start () {
		setFondo("granja");
		playSong("FloatingOompa");
		peny = CharacterManager.instance.GetCharacter("Peny",enableOnStart:false);
		arian = CharacterManager.instance.GetCharacter("Arian",enableOnStart:false);
		sPeny = CharacterManager.instance.GetCharacter("Super Peny",enableOnStart:false);
		arian.setName("?????");
		siguiente();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			if(index < _script.Length){
				siguiente();
				if(index==55){
					arian.setName("Arian");
				}
			}else{
				DialogueSystem.instance.Close();
				SceneManager.LoadScene("BulletHell");
			}
		}
	}

	void setFondo(string bgName){
		Sprite imagen = Resources.Load<Sprite>(string.Format("images/IU/{0}",bgName));
		layer = BackgroundController.instance.background;
		layer.setSprite(imagen);
	}

	void playSong(string songName,float maxVolume = 1f,float pitch = 1f, float startingVolume=0,bool playOnStart=true,bool loop = true){
		AudioClip song = Resources.Load<AudioClip>(string.Format("Audio/Music/{0}",songName));
		AudioManager.instance.PlaySong(song, maxVolume, pitch, startingVolume, playOnStart, loop);
	}

	void playSFX(string sfxName, float _volume = 1f, float _pitch = 1f){
		AudioClip sfx = Resources.Load<AudioClip>(string.Format("Audio/SFX/{0}",sfxName));
		AudioManager.instance.PlaySFX(sfx, _volume, _pitch);
	}

	void siguiente(){
		string[] parts = _script[index].Split('/');
		if(parts[0] !="-"){
			setFondo(parts[0]);
		}//fondo
		if(parts[1] !="-"){
			playSong(parts[1]);
		}else if(parts[1] ==" "){
			playSong(null);
		}//musica
		if(parts[2] !="-"){
			playSFX(parts[2]);
		}//efectos
		if(parts[3] != "Peny" && parts[3] != "Arian" && parts [3] != "Super Peny"){
			if(toAdd){
				DialogueSystem.instance.sayAdd(parts[4],parts[3]);
			}else{
				DialogueSystem.instance.say(parts[4],parts[3]);
			}
			peny.disableChar();
			arian.disableChar();
			sPeny.disableChar();
		}else{
			switch(parts[3]){
				case "Peny": 
					arian.disableChar();
					sPeny.disableChar();
					if(toAdd){peny.sayAdd(parts[4]);}
					else{peny.say(parts[4]);}
					break;
				case "Arian": 
					sPeny.disableChar();
					peny.disableChar();
					if(toAdd){arian.sayAdd(parts[4]);}
					else{arian.say(parts[4]);}
					break;
				case "Super Peny": 
					peny.disableChar();
					arian.disableChar();
					if(toAdd){sPeny.sayAdd(parts[4]);}
					else{sPeny.say(parts[4]);}
					break;
			}
		}// personaje y texto
		toAdd = parts[4].Contains("...");
		index++;
	}

}
