using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carousel : MonoBehaviour {

	[SerializeField] float _speed;
	[SerializeField] float _duration;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 1 * _speed * _duration, 0);
	}
}
