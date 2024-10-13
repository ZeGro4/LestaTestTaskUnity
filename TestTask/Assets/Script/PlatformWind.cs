using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformWind : MonoBehaviour {

	[SerializeField] private float ForceWind; // сила ветра
	private Vector3 wind_direction;
	bool onBlock = false; // отслеживает нахождение игрока на блоке



	private void OnCollisionEnter(Collision col)
	{
        if (col.gameObject.CompareTag("Player"))
        {
            onBlock = true;
            StartCoroutine(ChangeWind());
        }
        
    }

	private void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
            collision.gameObject.GetComponent<Rigidbody>().AddForce(wind_direction * ForceWind, ForceMode.Force);

            
		}
	}

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            onBlock = false;
        }
    }

    private IEnumerator ChangeWind()
	{
		while (onBlock)
		{
            float rand = Random.Range(0f, 360f);
            wind_direction = Quaternion.Euler(0, rand, 0) * Vector3.forward;

            yield return new WaitForSeconds(2f);
          

        }
    }

}
