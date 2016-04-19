using UnityEngine;
using System.Collections;


namespace math 
{
	public class mathGen : MonoBehaviour 
	{

		// Use this for initialization
		void Start () 
		{

		}
	
		// Update is called once per frame
		void Update () 
		{
	
		}
		void NewProb ()
		{
			//Random number between 1 and 100
			int AddNum = Mathf.RoundToInt (Random.value * (100 - 1 + 1)) + 1;
		}
	}
}