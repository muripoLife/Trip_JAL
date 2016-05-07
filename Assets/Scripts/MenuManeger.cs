using UnityEngine;
using System.Collections;

public class MenuManeger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update()
	{
		/*
		if (Input.GetMouseButton(0))
		{
			Application.LoadLevel("Trip");
		}
		*/
	}


	public void ButtonPush() {
		Debug.Log("Button Push !!");
		Application.LoadLevel("Trip");
	}

	public void SceneLoad () {
		
	}

}
