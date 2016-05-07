using UnityEngine;
using System.Collections;

public class ChageScene : MonoBehaviour
{
	SpotListCell spotListCell;
	Vector3 spotButtonPosition;

	void Start()
	{
		spotButtonPosition = spotListCell.spotButtonPosition;
		Debug.Log("ポジション" + spotButtonPosition);
	}

	void Update()
	{
	}
}