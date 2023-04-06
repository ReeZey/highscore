using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float move_speed;
    private Vector2 direction;

    private InputManager inputManager;
    private Rigidbody2D rb;

    private void Start() {
        inputManager = InputManager.Instance;
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update() {
        direction = inputManager.GetKey("Move").ReadValue<Vector2>();
    }
    
    private void FixedUpdate() {
        rb.AddForce(direction * move_speed);
        rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, 0.2f);
    }
}
