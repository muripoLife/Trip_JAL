using UnityEngine;
using System.Collections;
using UniRx;
using UnityEngine.SceneManagement;

/// <summary>
/// Game manager.
/// </summary>
public class GameManager : MonoBehaviour {

	[SerializeField] bool m_isSendMsg = false;

	void Start() {
		StartCoroutine(GameStart());
	}


	// Use this for initialization
	IEnumerator GameStart(){
		///サーバーから結果が文字列を取得するまで待ちUIを更新する
		yield return FetchManager.Instance.OnGetResponsedAsObservable().StartAsCoroutine();
		Init3DText(FetchManager.Instance.Result);

		///はい、いいえを聞いてくる
		HeadTracking.Instance.TrakingStart();
		yield return HeadTracking.Instance.isGETYESNOObservable.StartAsCoroutine();
		GetYESNO(HeadTracking.Instance.isHeadGesture);
		HeadTracking.Instance.TrakingStop();

		yield return new WaitForSeconds(15.0f);
		SceneManager.LoadScene("celestialSphere");

		yield break;
	}

	/// <summary>
	/// Gets the response coroutine.
	/// </summary>
	/// <returns>The response coroutine.</returns>
	/// <param name="result">Result.</param>
	void Init3DText(string result){
		Debug.Log("Get Message In GameManager " + result);
	}
		
	void GetYESNO(bool isYES){
		if(isYES){
			Debug.Log("YES");
		}
		else {
			Debug.Log("NO");
		}
	}
}
