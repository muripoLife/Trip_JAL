﻿using UnityEngine;
using System.Collections;

public class TripManager : MonoBehaviour {
	public static string tripFile = "";

	public string getTripName() {
		return tripFile;
	}

	public void setTripName(string tripName) {
		tripFile = tripName;
	}
}
