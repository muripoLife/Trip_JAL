using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpotListCell : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick () {
		Debug.Log("SpotListCell OnClick");
		SceneManager.LoadScene ("countdown");
	}
}
