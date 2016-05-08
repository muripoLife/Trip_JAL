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
			case "Kinkakuji":
				return 0;
				break;
			case "ginkakuji":
				return 1;
				break;
			case "Arashiyama":
				return 2;
				break;
			case "Kyoto Tower":
				return 3;
				break;
			case "Ryoanji":
				return 4;
				break;
			case "Kiyomizu":
				return 5;
				break;
			default:
				return 8;
				break;
		}
	}
}