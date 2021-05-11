using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {
	public static DialogueSystem instance;
	public ELEMENTS elementos;
	public Coroutine speakRoutine = null;
	public string toCompareSpeech="";
	[HideInInspector] public bool isWaitingForUserInput = false;
	public bool isSpeaking {get{return speakRoutine != null;}}
	public GameObject speechPanel {get{return elementos.speechPanel;}}
	public Text speechBoxName {get{return elementos.speechBoxName;}}
	public Text speechBoxText {get{return elementos.speechBoxText;}}

	void Awake() {
		instance = this;
	}
	public void say( string speech , string name = ""){
		//metodo para que se procese un dialogo completo
		stopSpeaking();
		speakRoutine = StartCoroutine(speak(speech,false,name));
	}
	public void sayAdd(string speech, string name = ""){
		//metodo que procesa la continuacion de un dialogo por partes
		stopSpeaking();
		speakRoutine = StartCoroutine(speak(speech,true,name));
	}
	public void stopSpeaking(){
		//metodo para detener la subrutina que escribe el dialogo
		if(isSpeaking){
			StopCoroutine(speakRoutine);
		}
		speakRoutine=null;
	}
	public string determineSpeakerName(string name){
		//metodo que discierne si es un nuevo personaje hablando, sino regresa el nombre anterior
		string speakerName=name;
		if(name == ""){
			speakerName = speechBoxName.text;
		}
		return speakerName;
	}
	public string determineToCompareSpeech(string newSpeech,bool toAdd){
		//metodo que regresa el dialogo completo objetivo para la rutina
		//si toAdd es true entonces se rescata el texto actual y se le concatena el texto de continuacion
		string speech = newSpeech;
		if(toAdd){
			speech = speechBoxText.text + newSpeech;
		}
		return speech;
	}
	IEnumerator speak(string speech,bool toAdd,string name){
		speechPanel.SetActive(true);//activar panel contenedor
		speechBoxName.text = determineSpeakerName(name);//pinta el nombre del personaje hablando
		toCompareSpeech = determineToCompareSpeech(speech,toAdd);
		if(!toAdd){//si es un nuevo dialogo, limpia la caja de dialogo
			speechBoxText.text="";
		}
		isWaitingForUserInput = false; //el texto aun no termina de escribirse
		while(speechBoxText.text != toCompareSpeech){
			//Debug.Log(speechBoxText.text + " caja");
			//Debug.Log(toCompareSpeech);
			speechBoxText.text += toCompareSpeech[speechBoxText.text.Length];
			
			yield return new WaitForEndOfFrame();
		}
		isWaitingForUserInput = true;//el texto ya termino de procesarse
		while(isWaitingForUserInput){
			yield return new WaitForEndOfFrame();
		}
		stopSpeaking();
	}
	// Use this for initialization
	void Start () {
	}
	public void Close(){
		//cierra la caja de dialogos
		stopSpeaking();
		speechPanel.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
	}
	
	[System.Serializable]
	public class ELEMENTS{
		public GameObject speechPanel;
		public Text speechBoxName;
		public Text speechBoxText;
	}

}
