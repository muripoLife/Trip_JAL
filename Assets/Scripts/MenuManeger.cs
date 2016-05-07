using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManeger : MonoBehaviour
{
	public void OnClickAreaList() {
		SceneManager.LoadScene ("AreaList");
	}

	public void OnClickSpotList() {
		SceneManager.LoadScene ("SpotList");
	}

	/*
	public Button freeChoiceButton;
	public Button sightSeeingButton;

	// Use this for initialization
	void Start()
	{
		freeChoiceButton  = gameObject.GetComponent("FreeChoiceButton") as Button;
		sightSeeingButton = gameObject.GetComponent("SightSeeingButton") as Button;
	}

	// Update is called once per frame
	void Update()
	{
		freeChoiceButton.onClick.AddListener(() => {
			Debug.Log("freeChoiceButton Push !!");
			Application.LoadLevel("Trip");
		});

		sightSeeingButton.onClick.AddListener(() => {
			Debug.Log("sightSeeingButton Push !!");
			Application.LoadLevel("Trip");
		});

	}
	*/
}