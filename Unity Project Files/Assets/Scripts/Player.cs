using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 1.5f;
    [SerializeField] private float rotationSpeed = 10f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Time.timeScale == 0) return;

        if (Mouse.current.leftButton.wasPressedThisFrame ||
            Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (Time.timeScale == 0) return;

        transform.rotation = Quaternion.Euler(0, 90, -1 * rb.linearVelocity.y * rotationSpeed);
    }

    private void Jump()
    {
        rb.linearVelocity = Vector3.up * jumpForce;
    }
    private void OnTriggerEnter(Collider other)
    {
        HandleHit(other.gameObject);
    }

    void HandleHit(GameObject obj)
    {
        if (obj.CompareTag("Pipe"))
        {
            GameManager.instance.GameOver();
        }
        else if (obj.CompareTag("Score"))
        {
            ScoreManager.instance.AddScore(1);
            Destroy(obj);
        }
    }
}
