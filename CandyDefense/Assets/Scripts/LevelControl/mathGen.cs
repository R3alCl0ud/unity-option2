
using UnityEngine;
using System.Collections;


 public class mathGen : MonoBehaviour 
{
	int a;
	int AddNum ();
	int sym ();

	// Use this for initialization
	void Start () 
	{
		//Random number between 1 and 20
		int AddNum1 = AddNum ();
		int AddNum2 = AddNum ();

		//Pass bool made in LevelControl
		if (easy)
		{
			a = 20;
			sym ();

			switch sym
			{
				case 1:
				AddNum1 + AddNum2;
				break;

				case 2:
				AddNum1 - AddNum2;
				break;

				default:
				sym();
				break;
			}


		} 
		else if (medium)
		{
			a = 12;
			sym ();

			switch sym
			{
			case 1:
				AddNum1 + AddNum2;
				break;

			case 2:
				AddNum1 - AddNum2;
				break;

			case 3:
				AddNum1 * AddNum2;
				break;

			case 4:
				AddNum1 / AddNum2;
				break;
			}

		} 
		else if (hard)
		{
			a = 20;
			sym ();

			switch sym
			{
			case 1:
				AddNum1 + AddNum2;
				break;

			case 2:
				AddNum1 - AddNum2;
				break;

			case 3:
				AddNum1 * AddNum2;
				break;

			case 4:
				AddNum1 / AddNum2;
				break;
			}
		}

	}

	int AddNum() {
		Mathf.RoundToInt (Random.value * (a - 1 + 1)) + 1;
		return a;
	}

	int sym() {
		Mathf.RoundToInt (Random.value * (4 - 1 + 1)) + 1;
		return sym;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
