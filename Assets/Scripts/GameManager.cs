using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{

	[SerializeField] private GameObject MarkerObj;
	private int totalScore;
	private float distance;


	private void CalcScore(float dis)
	{
		totalScore += (100 - (int)dis * 30);
	}

	public void Score (Vector3 hitposition)
	{
		distance = Vector2.Distance ((Vector2)hitposition, (Vector2)MarkerObj.transform.position);
		totalScore += (100 - (int)distance * 30);
	}

	public int putScore ()
	{
		return this.totalScore;
	}
}
