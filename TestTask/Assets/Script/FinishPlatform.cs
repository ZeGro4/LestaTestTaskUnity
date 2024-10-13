using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishPlatform : MonoBehaviour {

	[SerializeField] GameObject canvas;
	[SerializeField] Text text_win;
	[SerializeField] GameObject timer_text;
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Debug.Log("Player");
            Time.timeScale = 0f;
			canvas.SetActive(true);
			text_win.text = "Time: " + timer_text.GetComponent<TimerScript>().Time_game.ToString("00");
        }
	}
	
}
