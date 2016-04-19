using UnityEngine;
using System.Collections;

public class mathGen : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		//Random number between 1 and 100
		if (easy)
		{
			int AddNum = Mathf.RoundToInt (Random.value * (12 - 1 + 1)) + 1;
		} 
		else if (medium)
		{
			int AddNum = Mathf.RoundToInt (Random.value * (12 - 1 + 1)) + 1;
		} 
		else if (hard)
		{
			int AddNum = Mathf.RoundToInt (Random.value * (12 - 1 + 1)) + 1;
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}