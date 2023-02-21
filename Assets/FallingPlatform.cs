using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
	public float detectionRadius = 1f;
    public Transform playerTransform;
	public float fallTime = 2.0f;

	void Update()
	{
		if (Vector3.Distance(transform.position, playerTransform.position) < detectionRadius)
        {
			StartCoroutine(Fall(fallTime));
		}
	}


	// void OnTriggerEnter(Collider collision)
	// {
	// 	// foreach (ContactPoint contact in collision.contacts)
	// 	// {
	// 		//Debug.DrawRay(contact.point, contact.normal, Color.white);
	// 		print("collision");
	// 		if (collision.gameObject.tag == "player")
	// 		{
	// 			print("collision player");
	// 			StartCoroutine(Fall(fallTime));
	// 		}
	// 	// }
	// }

	IEnumerator Fall(float time)
	{
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
	}
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class FallingPlatform : MonoBehaviour
// {
// 	public float fallTime = 1.5f;


// 	void OnCollisionEnter(Collision collision)
// 	{
// 		print("collision");
		
// 			//Debug.DrawRay(contact.point, contact.normal, Color.white);
// 			if (collision.gameObject.CompareTag("player"))
// 			{
// 				print("Player colliding");
// 				StartCoroutine(Fall(fallTime));
// 			}
		
// 	}

// 	IEnumerator Fall(float time)
// 	{
// 		yield return new WaitForSeconds(time);
// 		Destroy(gameObject);
// 	}
// }

