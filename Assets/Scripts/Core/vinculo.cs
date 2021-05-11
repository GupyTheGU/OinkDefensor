using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vinculo : MonoBehaviour {
	public GameObject sprite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!EnemyManager.instance.muerto){
			transform.position = sprite.transform.position;
		}
	}
}
