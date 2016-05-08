using UnityEngine;
using System.Collections;

public class ChageScene : MonoBehaviour
{
	[SerializeField] GameObject[] tourismPhoto = new GameObject[5];
	TripManager tripManager;

	void Start()
	{
		tripManager = new TripManager();
		string tripfile = tripManager.getTripName();
		tourismPhoto[nameToNum(tripfile)].SetActive(true);
	}

	public int nameToNum(string name)
	{
		int num = 0;
		switch (name)
		{
			case "01":
				return 0;
				break;
			case "02":
				return 1;
				break;
			case "03":
				return 2;
				break;
			case "04":
				return 3;
				break;
			case "05":
				return 4;
				break;
			case "06":
				return 5;
				break;
			default:
				return 8;
				break;
		}
	}
}