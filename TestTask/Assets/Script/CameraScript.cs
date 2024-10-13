using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	[SerializeField] Transform player;

	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		

		Quaternion quaternion = Quaternion.Euler(0f,player.position.y,0f);
		transform.LookAt(player.position);


	}
}
