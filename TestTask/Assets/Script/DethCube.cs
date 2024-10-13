using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DethCube : MonoBehaviour {

	[SerializeField] private GameObject canvas;
	private void OnTriggerEnter(Collider other) {

		if (other.CompareTag("Player"))
		{
			canvas.GetComponent<UIScript>().PanelView();
            Time.timeScale = 0f;

        }
	
	}
	
}
