using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Countdown : MonoBehaviour {
	private float time = 15;

	void Start () {
		//初期値15を表示
		//float型からint型へCastし、String型に変換して表示
		GetComponent<Text>().text = ((int)time).ToString();
	}

	void Update (){
		// 1秒に1ずつ減らしていく
		time -= Time.deltaTime;
		// マイナスは表示しない
		if (time < 0) time = 0;
		GetComponent<Text> ().text = ((int)time).ToString ();
		// VRscene読み込み
		if (time < 1) {
			SceneManager.LoadScene("Trip");
		}
	}
}
