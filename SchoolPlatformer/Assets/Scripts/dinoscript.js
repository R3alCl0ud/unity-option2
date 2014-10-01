﻿#pragma strict

var dino: GameObject;
var rngx: int;
var imageText: Texture;
var dinoPrefab: Transform;

function Start () 
{

	rngx = Random.Range(-2,10);
	Instantiate(dinoPrefab,Vector3(rngx, -2.5,-4),Quaternion.identity);
		
}
function Update () 
{
		var index = Mathf.FloorToInt(Time.time * 12.0) % 6;
		var size = Vector2(0.15,1);
		var offset = Vector2(index/6.0,0);
		renderer.material.SetTextureScale("_MainTex", size);
		renderer.material.SetTextureOffset("_MainTex", offset);
}