using UnityEngine;

public class MeatProjectile : MonoBehaviour
{
    private bool alreadyHit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (alreadyHit)
            return;

        AnimalScore animal = other.GetComponentInParent<AnimalScore>();

        if (animal != null)
        {
            alreadyHit = true;

            ScoreManager.Instance.AddScore(animal.points);

            Destroy(animal.gameObject);
            Destroy(gameObject);
        }
    }
}