
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Enemy : MonoBehaviour {
	public int startHp=30;
	LevelController lc;
	Vector3 nuevaPosicion;
	public bool isMoving=true;
	float moveTime=1f;
	float toMove=0f;
	public float bulletCooldown=0.2f;
	float bulletTimer;
	int hp;
	Coroutine movement;
	// Use this for initialization
	void Start () {
		lc = LevelController.instance;
		startPos();
		restartEnenmy();
		moveEnemy();
	}
	
	// Update is called once per frame
	void Update () {
		
		bulletTimer -= Time.deltaTime;
		if(EnemyManager.instance.restartHP){
			restartEnenmy();
			EnemyManager.instance.restartHP=false;
		}
		if(isMoving){
			toMove-= Time.deltaTime;
			if(toMove > 0){
				transform.position = Vector3.Lerp(transform.position, nuevaPosicion,0.05f);
			}else{
				isMoving=false;
				toMove=moveTime;
			}
		}else{
			//si no se esta moviendo regresa el conteo
			toMove-= Time.deltaTime;
			if(toMove <= 0){
				//print(toMove);
				isMoving=true;
				toMove = 3f;
				moveEnemy();
				lc.playSFX("spaceSwoosh");
			}
		}
		//if(EnemyManager.instance.isMoving && !
	}
	private void OnTriggerEnter2D(Collider2D other) {
		//print("colisiona");
		if(other.tag == "Esfera" && bulletTimer <= 0){
			lc.playSFX("spaceButton");
			hp -= 1;
			Destroy(other.gameObject);
			//other.gameObject.SetActive(false);
			if(hp <= 0){
				lc.playSFX("explosion");
				isMoving=true;
				bulletTimer = bulletCooldown;
				EnemyManager.instance.muerto=true;
				EnemyManager.instance.numEnemigos--;
				lc.playSFX("futuristic");startPos();
			}
			EnemyManager.instance.setVida(hp.ToString());
		}
	}
	public void moveEnemy(){
		float offsetX = Random.Range(-3.0f,3.0f);
		float offsetY = Random.Range(1.0f,5.0f);
		nuevaPosicion = new Vector3(offsetX,offsetY,0f);
	}
	public void restartEnenmy(){
		EnemyManager bc = EnemyManager.instance;
		hp=startHp;
		bc.setVida(hp.ToString());
		bc.setVisible(true);
	}
	public void startPos(){
		float offsetX = Random.Range(-4.0f,4.0f);
		float offsetY = Random.Range(5.5f,7.0f);
		transform.position = new Vector2(offsetX,offsetY);
	}
}
