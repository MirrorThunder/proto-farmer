using UnityEngine;
using System.Collections;

public class FastFirePowerUp : MonoBehaviour
{
    public float speed = 10f;
    public float respawnTime = 3f;

    private Collider powerUpCollider;
    private Renderer powerUpRenderer;

    private bool waitingForRespawn = false;

    private float spawnY;
    private float spawnZ;

    private void Start()
    {
        powerUpCollider = GetComponent<Collider>();
        powerUpRenderer = GetComponent<Renderer>();

        spawnY = transform.position.y;
        spawnZ = transform.position.z;
    }

    private void Update()
    {
        if (waitingForRespawn)
            return;

        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.z < -10f)
        {
            StartCoroutine(RespawnPowerUp());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (waitingForRespawn)
            return;

        PlayerController player = other.GetComponentInParent<PlayerController>();

        if (player != null)
        {
            player.ActivateFastFire();

            Debug.Log("¡POWER-UP DE DISPARO RÁPIDO RECOGIDO!");

            StartCoroutine(RespawnPowerUp());
        }
    }

    private IEnumerator RespawnPowerUp()
    {
        if (waitingForRespawn)
            yield break;

        waitingForRespawn = true;

        powerUpCollider.enabled = false;
        powerUpRenderer.enabled = false;

        yield return new WaitForSeconds(respawnTime);

        float randomX = Random.Range(-10f, 10f);

        transform.position = new Vector3(
            randomX,
            spawnY,
            spawnZ
        );

        powerUpRenderer.enabled = true;
        powerUpCollider.enabled = true;

        waitingForRespawn = false;

        Debug.Log("¡POWER-UP DE DISPARO RÁPIDO REAPARECIÓ!");
    }
}