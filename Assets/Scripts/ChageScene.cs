using UnityEngine;
using System.Collections;

public class ChageScene : MonoBehaviour
{
	public GameObject Sphere100;
	public GameObject Sphere100_1;
	public GameObject Sphere100_2;
	//public GameObject Sphere100_3;
	//public GameObject Sphere100_4;
	//public GameObject Sphere100_5;
	//public GameObject Sphere100_6;
	//float time;

	// Use this for initialization
	void Start()
	{
		/*
		time = 0;
		Sphere100.SetActive(true);
		Sphere100_1.SetActive(false);
		Sphere100_2.SetActive(false);
		Sphere100_3.SetActive(false);
		Sphere100_4.SetActive(false);
		Sphere100_5.SetActive(false);
		Sphere100_6.SetActive(false);
		*/
		StartCoroutine(Scene_Ch());
	}

	void Update()
	{
		//time += Time.deltaTime;
		/*
		Debug.Log(time);
		if (time < 5.0f)
		{
			Sphere100.SetActive(false);
			Sphere100_1.SetActive(true);
			time = 6.0f;
		}
		else if (time < 30.0f)
		{
			Sphere100_1.SetActive(false);
			Sphere100_2.SetActive(true);
			time++;
		}
		else if (time < 45.0f)
		{
			Sphere100_2.SetActive(false);
			Sphere100_3.SetActive(true);
		}
		else if (time < 60.0f)
		{
			Sphere100_3.SetActive(false);
			Sphere100_4.SetActive(true);
		}
		else if (time < 75.0f)
		{
			Sphere100_4.SetActive(false);
			Sphere100_5.SetActive(true);
		}
		else if (time < 90.0f)
		{
			Sphere100_5.SetActive(false);
			Sphere100_6.SetActive(true);
		}
		else if (time < 105.0f)
		{
			Sphere100_6.SetActive(false);
			Sphere100.SetActive(true);
		}
		*/
	}
	IEnumerator Scene_Ch()
	{
		yield return new WaitForSeconds(15.0f);
		//GetComponent<Renderer>().material.mainTexture = Haikei1;
		Sphere100.SetActive(false);
		Sphere100_1.SetActive(true);
		yield return new WaitForSeconds(15.0f);
		Sphere100_1.SetActive(false);
		Sphere100_2.SetActive(true);
		yield return new WaitForSeconds(15.0f);
		Sphere100_2.SetActive(false);
		//Sphere100_3.SetActive(true);
		//yield return new WaitForSeconds(15.0f);
		//Sphere100_3.SetActive(false);
		Sphere100.SetActive(true);
		//Sphere100_4.SetActive(true);
		//yield return new WaitForSeconds(15.0f);
		//Sphere100_4.SetActive(false);
		//Sphere100_5.SetActive(true);
		//yield return new WaitForSeconds(15.0f);
		//Sphere100_5.SetActive(false);
		//Sphere100_6.SetActive(true);
		//yield return new WaitForSeconds(15.0f);
		//Sphere100_6.SetActive(false);
		//Sphere100.SetActive(true);
	}

		//yield return new WaitForSeconds(15.0f);
		//Application.LoadLevel("hamba_VR_2");
		//yield return new WaitForSeconds(15.0f);
		//Application.LoadLevel("hamba_VR_3");
		//yield return new WaitForSeconds(15.0f);
		//Application.LoadLevel("hamba_VR_4");
		//yield return new WaitForSeconds(15.0f);
		//Application.LoadLevel("hamba_VR_5");
		//yield return new WaitForSeconds(15.0f);
		//Application.LoadLevel("hamba_VR_6");
}