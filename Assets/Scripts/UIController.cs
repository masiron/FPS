using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour 
{

	[SerializeField] private Text timer;
	[SerializeField] private Text Score;
	[SerializeField] private Text bullet;
	[SerializeField] private Text storage;
	[SerializeField] private GunController gun;
	[SerializeField] private GameManager game;

	void Update () 
	{
		timer.text = "Time :" + (int)Time.time;
		Score.text = "Score :" + game.putScore ();
		bullet.text = "Bullet :" + gun.putBullet ();
		storage.text = "Storage : " + gun.putStorage ();
	}
}
