using UnityEngine;
using System.Collections;
using UniRx;
using System.Collections.Generic;
using System;
using System.Linq;


/// <summary>
/// Fetch manager.
/// </summary>
public class FetchManager : SingletonMonoBehaviour<FetchManager> {

	/// <summary>
	/// リトライ時間
	/// </summary>
	[SerializeField] float m_retryTime = 3.0f;

	[SerializeField] List<string> data = new List<string> ();

	[SerializeField] bool m_isClearPlayerPrefs = false;

	public string Result {
		get;private set;
	}

	private static readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
	DateTime LastTextSendTime = DateTime.Parse ("1992/2/16 12:15:12");

	string dayString = "1992/2/16 12:15:12";
	string dayKey = "LastTextSendTime";

	void Start(){
		// TODO: 初回のみPlayerPrefsに保存し、２回目起動時はPlayerPrefsのあたいを利用
		if(PlayerPrefs.HasKey(dayKey)){
			dayString = PlayerPrefs.GetString(dayKey);
			Debug.Log("Get Time String" + dayString);
		}
		else {
			Debug.Log("Not Have Time Key. Set Time String");
			PlayerPrefs.SetString(dayKey,dayString );
		}
		LastTextSendTime = DateTime.Parse(dayString);
	}


	#if UNITY_EDITOR
	void OnValidate(){
		if(m_isClearPlayerPrefs){
			if(PlayerPrefs.HasKey(dayKey)){
				PlayerPrefs.DeleteKey(dayKey);
			}
			m_isClearPlayerPrefs = false;
		}
	}
	#endif



	/// <summary>
	/// メッセージを取得した事を通知する。
	/// </summary>
	/// <value>The on get responsed as observable.</value>
	public IObservable<string> OnGetResponsedAsObservable()
	{
		return m_onGetResponse.AsObservable();
	}

	private Subject<string> m_onGetResponse = new Subject<string>();
		
	/// <summary>
	/// Starts the retry.
	/// </summary>
	void StartRetry(){
		StartCoroutine(RetryFetch());
	}

	/// <summary>
	/// メッセージ受診失敗時に一呼吸おいてからリトライする
	/// </summary>
	/// <returns>The fetch.</returns>
	IEnumerator RetryFetch(){
		yield return new WaitForSeconds(m_retryTime);
		Debug.Log("Retry Get Text");
		yield return null;
	}

	public static long FromDateTime( DateTime dateTime )
	{
		double nowTicks = ( dateTime.ToUniversalTime() - UNIX_EPOCH ).TotalSeconds;
		return (long)nowTicks;
	}

}
