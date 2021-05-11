using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterManager : MonoBehaviour {
	public static CharacterManager instance;
	public RectTransform characterPanel;
	
	public List<Character> personajes = new List<Character>();
	public Dictionary<string, int> characterDictionary = new Dictionary<string,int>();

	void Awake(){
		instance=this;
	}
	public Character GetCharacter(string nombre,bool createIfNotExists = true,bool enableOnStart = true){
		//busca un personaje en escena
		//si no existe entonces lo crea dependiendo createIfNotExists
		int index = -1;
		if(characterDictionary.TryGetValue(nombre, out index)){
			return personajes[index];
		}else if(createIfNotExists){
			return createCharacter(nombre,enableOnStart);
		}
		return null;
	}

	public Character createCharacter(string nombre,bool enableOnStart){
		Character nuevo = new Character(nombre,enableOnStart);
		characterDictionary.Add(nombre,personajes.Count);
		personajes.Add(nuevo);
		return nuevo;
	}

	public void removeCharacter(string nombre){
		int index = -1;
		if(characterDictionary.TryGetValue(nombre, out index)){
			personajes.RemoveAt(index);
			characterDictionary.Remove(nombre);
		}else{
			Debug.Log("el elemento no existe");
		}
	}
	public void adjustIndexes(int index){
		for(int k=index; k<personajes.Count-1 ; k++){
			characterDictionary[personajes[index++].nombre]=index;
		}
	}
}
