using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDisapear : MonoBehaviour {

	private float interval = 3f;
	MeshRenderer meshRenderer;
	BoxCollider collider;
	Color[] colors = {Color.red,Color.yellow,Color.green};
	private int currentIndex = 0;
	private float timer = 0f;
	private float colorInterval = 1f;

	void Start()
	{
		StartCoroutine(DispearObject());
		meshRenderer = GetComponent<MeshRenderer>();
		collider = GetComponent<BoxCollider>();
		meshRenderer.material.color = colors[currentIndex];
	}

	void Update()
	{
		timer += Time.deltaTime;
		if(timer >= colorInterval)
		{
			timer = 0f;
			currentIndex = (currentIndex + 1) % colors.Length;
            meshRenderer.material.color = colors[currentIndex];
        }

	}
	private IEnumerator DispearObject()
	{

		yield return new WaitForSeconds(interval);
        meshRenderer.enabled = false;
		collider.enabled = false;
		StartCoroutine(AppearObject());
	}
    private IEnumerator AppearObject()
    {

        yield return new WaitForSeconds(interval);
        meshRenderer.enabled = true;
		collider.enabled = true;
        StartCoroutine(DispearObject());
    }



}
