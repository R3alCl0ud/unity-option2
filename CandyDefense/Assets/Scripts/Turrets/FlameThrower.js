﻿#pragma strict
import UnityEngine.GameObject;
import projectile;

var enemy : Transform;
var turret : GameObject;
var gos : GameObject[];	
var shotnormal : GameObject;
var closest : GameObject; 
var shotFlame : GameObject;

var distance : float;
var fireRate : int;
private var nextFire = 0.0;


var coolDown : float;		//new
var timestamp: float;		//new
var flame : AudioClip;			//new


function Start () {

	FindClosestEnemy();
	transform.position.z = 0;
	fireRate = 0.1;
	coolDown += 1.0;

}

function Update () {
	
	FindClosestEnemy();
	transform.rotation.x = 0;
	transform.rotation.y = 0;
Physics2D.IgnoreLayerCollision(10,13, true);
Physics2D.IgnoreLayerCollision(13,11, true);
Physics2D.IgnoreLayerCollision(13,13, true);
Physics2D.IgnoreLayerCollision(13,14, true);
Physics2D.IgnoreLayerCollision(11,14, true);
Physics2D.IgnoreLayerCollision(10,14, true);

}

function FindClosestEnemy (){
		// Find all game objects with tag Enemy
		
		gos = GameObject.FindGameObjectsWithTag("Enemy"); 
		turret = GameObject.FindGameObjectWithTag("Turret");
		var closest : GameObject; 
		var distance = Mathf.Infinity; 
		var position = transform.position; 
		
		// Iterate through them and find the closest one
		for (var go : GameObject in gos)  { 
			var diff = (go.transform.position - position);
			var curDistance = diff.sqrMagnitude; 
			if (curDistance < distance) { 
				closest = go; 
				distance = curDistance; 
			}
			if (distance < 1 && closest.transform.position.x >= -2.388) {
			transform.LookAt(closest.transform.position, Vector3.forward);
			if (Time.time > nextFire) {
			nextFire = (Time.time + fireRate);
			Shoot();
			
			}
		} 	
	}// && this.gameObject.name != "Flame thrower(Clone)"
}

function Shoot () {


		Instantiate(shotFlame, transform.position, transform.rotation);
		
		if(Time.time > timestamp){			//new timer for sound

				GetComponent.<AudioSource>().PlayOneShot(flame);				//new Add Audio Source Componets
				timestamp = Time.time + coolDown;
		}
	
}