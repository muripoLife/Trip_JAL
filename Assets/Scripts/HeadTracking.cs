using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UniRx;

public class HeadTracking : SingletonMonoBehaviour<HeadTracking>
{
	
	public bool isHeadGesture {
		private set;get;
	}

	/// <summary>
	/// 外部に公開するObservable
	/// </summary>
	public IObservable<bool> isGETYESNOObservable
	{
		get
		{
			return m_isGETYESNOStream.AsObservable();
		}
	}

	/// <summary>
	/// The is done effect.
	/// </summary>
	Subject<bool> m_isGETYESNOStream = new Subject<bool>();


	bool success = false;
	float lotate_x;
	float pre_lotate_x;
	float lotate_y;
	float pre_lotate_y;
	int down_count = 0;
	int down_count2 = 0;


	int side_count = 0;
	int side_count2 = 0;

	public int up_down_frame_series_count;
	public int left_rigt_frame_series_count;
	//string text = "未回答";

	float countTime;
	float setTimeTate;
	float setTimeYoko;

	bool tate_first_OK;
	bool yoko_first_OK;

	bool m_isTrackStart = false;


	/// <summary>
	/// Trakings the start.
	/// </summary>
	public void TrakingStart(){
		isHeadGesture = false;
		m_isTrackStart = true;
	}


	/// <summary>
	/// Trakings the stop.
	/// </summary>
	public void TrakingStop(){
		isHeadGesture = false;
		m_isTrackStart = false;
	}

	void Start ()
	{
		pre_lotate_x = this.gameObject.transform.localEulerAngles.x -360;
		pre_lotate_y = this.gameObject.transform.localEulerAngles.y;
	}

	// ログの出力
	void Update ()
	{
		if(!m_isTrackStart){
			return;
		}

		countTime += Time.deltaTime;

		lotate_x = this.gameObject.transform.localEulerAngles.x -360;
		lotate_y = this.gameObject.transform.localEulerAngles.y -360;

		log (" Time sinse fromStartup : " + Time.realtimeSinceStartup + "[12345678901234567890]");
		log (" lotate x : " + lotate_x);
		log (" lotate y : " + lotate_y);
		//log (" 縦振りの回数 : " + down_count2 + " 縦振りの回数 : " + side_count2);

		// 縦振り未検出
		if (!tate_first_OK) {
			// 下方向へ視線が移動している
			if (pre_lotate_x < lotate_x) {
				++down_count;
				if (down_count > 5) {
					// 一回目OK
					Debug.Log ("縦 一回目OK");
					tate_first_OK = true;
					setTimeTate = countTime;
				}
			} else {
				// リセット
				//Debug.Log("一回目がリセット");
				down_count = 0;
			}
		}

		// 横振り未検出
		if (!yoko_first_OK) {
			// 横方向へ視線が移動している
			if (pre_lotate_y < lotate_y) {
				++side_count;
				if (side_count > 5) {
					// 一回目OK
					Debug.Log ("横 一回目OK");
					yoko_first_OK = true;
					setTimeYoko = countTime;
				}
			} else {
				// リセット
				//Debug.Log("一回目がリセット");
				side_count = 0;
			}
		}

		// 縦
		if (tate_first_OK) {
			// 縦は一度振ってる
			if (setTimeTate > (countTime - 1.0f)) {
				// 縦振りしていて、かつ、一秒以内
				if (pre_lotate_x > lotate_x) {
					++down_count;
					if (down_count > 5) {
						down_count = 0;
						++down_count2;
						Debug.Log ("あと少し" + down_count2.ToString ());
						if (down_count2 > 2) {
							Debug.Log ("告白成功");
							m_isGETYESNOStream.OnNext(true);
							m_isGETYESNOStream.OnCompleted();
							isHeadGesture = true;
							return;
							//down_count2 = 0;
						}
					}
				} 
			} else {
				// リセット
				//Debug.Log("二回目がリセット");
				down_count = 0;
				tate_first_OK = false;
			}
		}

		// 横
		if (yoko_first_OK) {
			// 縦は一度振ってる
			if (setTimeYoko > (countTime - 1.0f)) {
				// 横振りしていて、かつ、一秒以内
				if (pre_lotate_y > lotate_y) {
					++side_count;
					if (side_count > 5) {
						side_count = 0;
						++side_count2;
						Debug.Log ("あと少し" + side_count2.ToString ());
						if (side_count2 > 4) {
							Debug.Log ("告白失敗");
							m_isGETYESNOStream.OnNext(false);
							m_isGETYESNOStream.OnCompleted();
							isHeadGesture = false;
							return;
							//side_count2 = 0;
						}
					}
				} 
			} else {
				// リセット
				//Debug.Log("二回目がリセット");
				side_count = 0;
				yoko_first_OK = false;
			}
		}

		if (countTime > (setTimeTate + 1.2f)) {
			down_count2 = 0;
		}

		if (countTime > (setTimeYoko + 1.2f)) {
			side_count2 = 0;
		}
			
		pre_lotate_x = lotate_x;
		pre_lotate_y = lotate_y;

		return;
	}

	// ログの記録
	private static List<string> logMsg = new List<string> ();

	public static void log (string msg)
	{
		logMsg.Add (msg);
		// 直近の5件のみ保存する
		if (logMsg.Count > 4) {
			logMsg.RemoveAt (0);
		}
	}

	// 記録されたログを画面出力する
	void OnGUI ()
	{
		Rect rect = new Rect (0, 0, Screen.width, Screen.height);

		// フォントサイズを10px,白文字にする。
		// styleのnewは遅いため、本来はStart()で実施すべき...
		GUIStyle style = new GUIStyle ();
		style.fontSize = 10;
		style.fontStyle = FontStyle.Normal;
		style.normal.textColor = Color.white;

		// 出力された文字列を改行でつなぐ
		string outMessage = "";
		foreach (string msg in logMsg) {
			outMessage += msg + System.Environment.NewLine;
		}

		// 改行でつないだログメッセージを画面に出す
		GUI.Label (rect, outMessage, style);
	}
}
