using UnityEngine;
using System.Collections;
using Store;

namespace Level {
public class LevelControl : MonoBehaviour
{

	//Strings
	public string round;
	
	//Textures
	public Texture startbutton;
	
	//Game Objects	
	public GameObject[] enemies;     //array of enemies
	public GameObject[] spawnPoints; //array of spawnpoints
	public GameObject Raptor;	
	public GameObject SanicRaptor;
	
	//Bools	
	public bool roundIsOver;    //are we inbetween rounds?
	public bool pause = false;

	//integers
	public int wave;            //the wave we're on
	public int RoundHeight;
	public int maxEnemies;        //max ammount of enemies on the map at any given time
	public int currentEnemies;  //amount of enemies currently on the map
	public int pauseX;
	public int pauseY;
		public int lives;

	public int current_enemy_amount;
		
	public int Tutorial;

	//floats
	public float hSliderValue = 5.0F;
	public float startTimer;    //countdown until timer ends	
	
	//Access other scripts
		public GameObject store_accessor;
		public StoreControl storecontrol;
	
	public void CountDown ()  //countsdown  1 every 1 second
	{
		if (startTimer != 0) {
			startTimer -= 1;
		}
		if (startTimer == 0) {

			CancelInvoke ();
				}
	}
	
	// Use this for initialization
	void Start ()
	{
		wave = 3;
		maxEnemies = 4;
		roundIsOver = true;
		startTimer = 2;
		current_enemy_amount = 0;
		Tutorial = 1;
		lives = 3;
		store_accessor = GameObject.Find ("Store");
		storecontrol = store_accessor.GetComponent <StoreControl> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
						if (startTimer > 0) {          //if we're either counting down or still waiting
								roundIsOver = true; 		//round is still in over state

						} else {                         //otherwise
								//the round is over and we need to
								NextWave ();  			   //start the next wave
								roundIsOver = false;
						}
	
						if (roundIsOver == true) {                                            //if the round is in over state
								if (Input.GetKeyDown ("space")) {                   //"press space to start the countdown timer
										if (startTimer > 0) {                        // but only if its not 0
												InvokeRepeating ("CountDown", 1, 1);
										}    
								}

								current_enemy_amount = enemies.Length;
						}     
						enemies = GameObject.FindGameObjectsWithTag ("Enemy");
						round = "<color=#ff0000ff><size=30>Round: " + wave + "</size></color>";
						RoundHeight = (Screen.height - 75);


						if (Input.GetKey ("escape") && pause == false) {

								if (Input.GetKeyDown ("escape") && pause == false) {

										pause = true;
								} else if (Input.GetKeyDown ("escape") && pause == true) {
										pause = false;
								}

								pauseY = (Screen.height - 300);
								//pauseX Perry, what does this do?

								pauseY = (Screen.height / 2 - 100);
								pauseX = (Screen.width / 2 - 200);

						}
					if (lives == 0) 
			{
				StoreControl.Coins = 100;
				storecontrol.StoreOpen = true;
				lives = 3;
				for (int i = 0; i < enemies.Length; i++)
				{
					Destroy (enemies[i]);
				}
				GameObject[] turret_objects = GameObject.FindGameObjectsWithTag("Turret");
				foreach (GameObject objs in turret_objects)
					Destroy(objs);
				wave = 1;
				maxEnemies = 4;
			}
				}
	void NextWave ()   //resets the spawn timer, adds 1 to the wave #, and then spawns based on wave
	{
		currentEnemies = 0;
		startTimer = 2;
		SetWave (wave + 1);
		maxEnemies ++;
		roundIsOver = false;
		StartCoroutine (Spawn (0, maxEnemies));
	}
	
	void SetWave (int waveToSet) //sets the wave number
	{
		wave = waveToSet;
	}

	IEnumerator Spawn (int arrayIndex, int amount)  //spawns in specific spawnPoint
	{ //call with StartCoroutine (Spawn (enemy array index, number to spawn, spawnpoint array index));
		for (int i = 0; i <= amount; i++) {
			if (currentEnemies < maxEnemies) {
				Instantiate (Raptor, transform.position, transform.rotation);
				yield return new WaitForSeconds (1);
				currentEnemies ++;
				if (wave >= 4) {
					Instantiate (SanicRaptor, transform.position, transform.rotation);
					yield return new WaitForSeconds (1);
					currentEnemies ++;
				}
			}
		}
	}
	void OnGUI () {
		GUI.Label (new Rect (10, RoundHeight, 200, 200), round);
		if(GUI.Button(new Rect(10, 30, 100, 50), startbutton)) {
			if(roundIsOver){
				if (startTimer > 0) {                        // but only if its not 0
					InvokeRepeating ("CountDown", 1, 1);
				}
			}
		}
		if(pause == true) {
			GUI.BeginGroup(new Rect(pauseX, pauseY, 800, 600));
			GUI.Box(new Rect(0, 0, 400, 200), "This is a title");
			if(GUI.Button(new Rect(10, 50, 100, 50), "Quit Game")) {
				Application.Quit();
			}
			GUI.EndGroup();
		}
		if (Tutorial == 1) {
				GUI.BeginGroup(new Rect(pauseX, pauseY, 800, 600));
				GUI.Box(new Rect(0, 0, 600, 400), "Instructions");
				GUI.Label(new Rect(20, 20, 400, 300), "Click on the right edge of the screen to open the store.");
				if(GUI.Button(new Rect(200, 200, 100, 50), "Next")) {
					Tutorial++;
				}
				GUI.EndGroup();
			}
	}
}
}
