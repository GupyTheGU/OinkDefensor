
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {
	public static EnemyManager instance;
	public GameObject headerEnemigo;
	public Text vida;
	public Text enemyCounterText;
	public bool muerto=false;
	public RectTransform UnidadesPanel;
	public GameObject enemigoPrefab;
	public GameObject enemigoActual=null;
	public int numEnemigos=3;
	float spawnTime=9f;
	public bool restartHP=false;
	float toSpawn=0f;
	float speed;
	public bool juego,isMoving=true,isFiring=false;

	void Awake(){
		instance = this;
	}
	void Start() {
		//createEnemy();
		toSpawn = spawnTime;
		enemyCounterText.text = "Enemigos: "+numEnemigos.ToString();
	}
	// Update is called once per frame
	void Update () {
		if(muerto){
			enemigoActual.SetActive(false);
			setVisible(false);
			enemyCounterText.text = "Enemigos: "+numEnemigos.ToString();
			if(numEnemigos>0){
				toSpawn -= Time.deltaTime;
				if(toSpawn <= 0 ){
				
				restartEnemy();
				toSpawn = spawnTime;
				}
			}
		}
	}
	void createEnemy(){
		if(enemigoActual==null){
			enemigoActual = new GameObject();
			enemigoActual = Instantiate(enemigoPrefab,UnidadesPanel);
		}
	}
	void restartEnemy(){
		enemigoActual.SetActive(true);
		setVisible(true);
		muerto=false;
		restartHP= true;
	}
	public void setVisible(bool activo){
		headerEnemigo.SetActive(activo);
	}
	public void setVida(string hp){
		vida.text = hp;
	}
	public void IsMoving(bool _moving){
		isMoving = _moving;
	}

	public void IsFiring(bool _firing){
		isFiring = _firing;
	}
	
	
}
