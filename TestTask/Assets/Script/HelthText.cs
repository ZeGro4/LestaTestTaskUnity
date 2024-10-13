using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelthText : MonoBehaviour {

	[SerializeField] GameObject player;
	[SerializeField] Text text;
	
	// Update is called once per frame
	void Update () {
		text.text = "Helth: " + player.GetComponent<PlayerScript>().Heth;
	}
}
