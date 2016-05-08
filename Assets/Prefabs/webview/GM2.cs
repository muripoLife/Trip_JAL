using UnityEngine;

public class GM2 : MonoBehaviour
{
	private string url = "https://www.google.co.jp/maps/place/%E9%87%91%E9%96%A3%E5%AF%BA/@35.039444,135.727073,16.88z/data=!4m5!3m4!1s0x6001a820c0eb46bd:0xee4272b1c22645f!8m2!3d35.03937!4d135.7292431";
	WebViewObject webViewObject;

	void Start() {
		webViewObject =
			(new GameObject ("WebViewObject")).AddComponent<WebViewObject> ();
		webViewObject.Init ((msg) => {
			if (msg == "clicked") {
				webViewObject.SetVisibility (false);
			}
		});
	}
	public void onClick() {

		webViewObject.LoadURL(url);
		webViewObject.SetMargins(50,100,50,50);
		webViewObject.SetVisibility(true);

		webViewObject.EvaluateJS(
			"window.addEventListener('load', function() {" +
			"   window.addEventListener('click', function() {" +
			"       Unity.call('clicked');" +
			"   }, false);" +
			"}, false);");

	}

	void OnGUI() {
		if (GUI.Button ( new Rect(500,0,100,100), "GO")) {
			webViewObject.LoadURL(url);
			webViewObject.SetVisibility(true);
		}
	}
}
