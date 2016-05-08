﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpotListCell : MonoBehaviour
{
	public void OnClick ()
	{
		SceneManager.LoadScene ("SettingDevice");
	}

	public void OnClick (string tripFile)
	{
		TripManager.tripFile = "file01";
		SceneManager.LoadScene ("SettingDevice");
	}
}
