using UnityEngine;
using System.Collections;


public class PauseBehaviourScript : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{


	}
	void OnApplicationPause(bool isPause)
	{
		if (isPause)
		{
			Application.Quit();
		}
	}
}