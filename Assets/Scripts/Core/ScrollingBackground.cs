using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {
	public float timeToFinish = 0f;
	public float timer=0.05f;
	float aumento = 0.007f; //0.003 para movil
	Vector3 nuevaPosicion;
	// Use this for initialization
	void Start () {
		nuevaPosicion = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		 timeToFinish += Time.deltaTime;
		 //print(timeToFinish);// movil = 122;
		if(timeToFinish < 156){
			nuevaPosicion.y -= aumento;
			transform.position = Vector3.Lerp(transform.position, nuevaPosicion,timer);
		}
		
	}
}
