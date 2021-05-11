using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Character {
	public string nombre;
	public Image BodyRenderer;
	GameObject obj;
	[HideInInspector] public RectTransform root; //contenedor parte del prefab de todas las imagenes relacionadas del personaje en escena
	DialogueSystem dialogo;
	public bool enabled {get{return root.gameObject.activeInHierarchy;} set{root.gameObject.SetActive(value);}}
	
	public Character(string _name,bool enableOnStart = true){
		CharacterManager cm = CharacterManager.instance;
		GameObject prefab = Resources.Load("Characters/"+_name+"_NV") as GameObject;
		obj = GameObject.Instantiate(prefab , cm.characterPanel);
		root = obj.GetComponent<RectTransform>();
		nombre = _name;
		BodyRenderer = obj.GetComponentInChildren<Image>();
		dialogo = DialogueSystem.instance;
		enabled = enableOnStart;
	}

	public void say(string speech){
		dialogo.say(speech,nombre);
		enableChar();
	}
	public void sayAdd(string speech){
		dialogo.sayAdd(speech,nombre);
		enableChar();
	}
	public void enableChar(){
		if(!enabled){
			enabled=true;
		}
	}
	public void disableChar(){
		if(enabled){
			enabled=false;
		}
	}

	public void setName(string _name){
		nombre = _name;
	}

	public void removeFromEscene(){
		//elimina el objeto de la escena y de la lista en el manejador de personajes
		CharacterManager cm = CharacterManager.instance;
		cm.removeCharacter(nombre);
		UnityEngine.Object.Destroy(obj);
	}

}
