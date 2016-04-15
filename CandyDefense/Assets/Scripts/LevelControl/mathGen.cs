using UnityEngine;
using System.Collections;

public class mathGen : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		//Random number between 1 and 100
		AddNum = Mathf.RoundToInt (Random.value * (100 - 1 + 1)) + 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
