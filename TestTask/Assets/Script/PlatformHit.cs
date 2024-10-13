using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHit : MonoBehaviour {

	[SerializeField] GameObject player;

	bool isOneHit = false;

	private void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.CompareTag("Player"))
		{
			gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f,0.3f,0.2f);
			StartCoroutine(OnceHit());
            


        }

    }
	
	private void OnCollisionExit()
	{
		isOneHit = false;
		StopAllCoroutines();
	}

	private IEnumerator OnceHit()
	{
        
        yield return new WaitForSeconds(1f);
        StartCoroutine(Change_Color());
        isOneHit = true;
        if (isOneHit)
        {
            StartCoroutine(Hit());
        }
    }

	private IEnumerator Hit()
	{
		while (isOneHit)
		{
			
			yield return new WaitForSeconds(5f);
			StartCoroutine(Change_Color());
		}
    }

	private IEnumerator Change_Color() {

        gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, 0f);
        player.GetComponent<PlayerScript>().hit_player(1);
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f, 0.3f, 0.2f);
    }
}
