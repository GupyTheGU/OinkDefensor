using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public int startHp=40;
	public Text vida;
	public float bulletCooldown;
	float bulletTimer;
	int hp;
	// Use this for initialization
	void Start () {
		hp = startHp;
		vida.text = hp.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		bulletTimer -= Time.deltaTime;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		
		if(other.tag == "Bullet" && bulletTimer <= 0 && !LevelController.instance.muerto){
			hp -= 1;
			LevelController.instance.playSFX("mouseSqueak",0.4f,0.6f);
			vida.text= hp.ToString();
			bulletTimer = bulletCooldown;
			
			if(hp <= 0){
				LevelController.instance.muerto=true;
			}
		}
	}

	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Enemy"){
			print("colisiona");
		}
	}

}
