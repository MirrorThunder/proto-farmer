using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

	private float topBound = 30;
	private float lowerBound = -10;

	void Update()
	{

		// Elimina objetos que dejan el área visible del juego.
		if (transform.position.z > topBound)
		{
			Destroy(gameObject);
		}

		else if (transform.position.z < lowerBound)
		{
			Debug.Log("Game Over!");
			Destroy(gameObject);
		}
	}
}
