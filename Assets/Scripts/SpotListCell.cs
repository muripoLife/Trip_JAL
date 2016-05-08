using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

<<<<<<< HEAD
	void Start () {
		spotButtonPosition = spotButton.transform.position;
		Debug.Log(spotButtonPosition);
	}

	public void OnClick () {
		Debug.Log("SpotListCell OnClick");
		Debug.Log("押されたよ~" + spotButtonPosition);
		SceneManager.LoadScene ("SettingDevice");
	}

	public void OnClick(string tripFile) {
//		TripManager.tripFile = "file01";
		SceneManager.LoadScene ("SettingDevice");
	}
}
=======
public class SpotListCell : MonoBehaviour {
	//[SerializeField] GameObject spotButton;
	//public Vector3 spotButtonPosition;

	void Start () {
		//spotButtonPosition = spotButton.transform.position;
		//Debug.Log(spotButtonPosition);
	}

	public void OnClick () {
		Debug.Log("SpotListCell OnClick");
		//Debug.Log("押されたよ~" + spotButtonPosition);
		SceneManager.LoadScene ("SettingDevice");
	}

	public void OnClick(string tripFile) {
		TripManager.tripFile = "file01";
		SceneManager.LoadScene ("SettingDevice");
	}
}
>>>>>>> master
