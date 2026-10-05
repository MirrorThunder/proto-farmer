using UnityEngine;

public class MovePowerUp : MonoBehaviour
{
    public float speed = 10.0f;

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}