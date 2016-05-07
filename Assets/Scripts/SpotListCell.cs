using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpotListCell : MonoBehaviour {
	[SerializeField] GameObject spotButton;
	public Vector3 spotButtonPosition;

	void Start () {
		spotButtonPosition = spotButton.transform.position;
		Debug.Log(spotButtonPosition);
	}

	public void OnClick () {
		Debug.Log("SpotListCell OnClick");
		Debug.Log("押されたよ~" + spotButtonPosition);
		SceneManager.LoadScene ("SettingDevice");
	}
}
