using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    public Vector2 moveInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;

    public GameObject projectilePrefab;
    public InputAction fireAction;

    // Power-up de disparo rápido
    private bool fastFireActive = false;
    private float fastFireTimer = 0f;
    private float fireCooldown = 0.15f;
    private float fireTimer = 0f;

    void Start()
    {
        moveAction.Enable();
        fireAction.Enable();
    }

    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        moveInput = moveAction.ReadValue<Vector2>();
        transform.Translate(Vector3.right * moveInput.x * Time.deltaTime * speed);

        if (fastFireActive)
        {
            fastFireTimer -= Time.deltaTime;
            fireTimer -= Time.deltaTime;

            if (fastFireTimer <= 0)
            {
                fastFireActive = false;
            }

            if (fireAction.IsPressed() && fireTimer <= 0)
            {
                Instantiate(
                    projectilePrefab,
                    transform.position,
                    projectilePrefab.transform.rotation
                );

                fireTimer = fireCooldown;
            }
        }
        else
        {
            if (fireAction.triggered)
            {
                Instantiate(
                    projectilePrefab,
                    transform.position,
                    projectilePrefab.transform.rotation
                );
            }
        }
    }

    public void ActivateFastFire()
    {
        fastFireActive = true;
        fastFireTimer = 5f;

        Debug.Log("¡DISPARO RÁPIDO ACTIVADO!");
    }
}