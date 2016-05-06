using UnityEngine;
using System.Collections;
using UniRx;

/// <summary>
/// Head gesture manager.
/// </summary>
public class HeadGestureManager : SingletonMonoBehaviour<HeadGestureManager> {

	public bool isHeadGesture {
		private set;get;
	}

	/// <summary>
	/// デバッグ用
	/// </summary>
	[SerializeField] bool m_isDebugGetYESNOGesture;
	[SerializeField] bool m_isYes = true;

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

	#if UNITY_EDITOR
	void OnValidate(){
		if(m_isDebugGetYESNOGesture){
			m_isDebugGetYESNOGesture = false;
			m_isGETYESNOStream.OnNext(m_isYes);
			m_isGETYESNOStream.OnCompleted();
			isHeadGesture = m_isYes;
			Debug.Log("Gesture End");
		}
	}
	#endif
}
