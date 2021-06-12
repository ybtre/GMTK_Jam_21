using UnityEngine;

public class Movement : MonoBehaviour {
    
  
    [SerializeField] private float speed = 10f;
    [SerializeField] private float maxSpeed = 40f;

    public Rigidbody rb;

    private void FixedUpdate() {
        Vector3 inputVector = new Vector3(-Input.GetAxis("Vertical") * speed * Time.deltaTime, rb.velocity.y, Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        // rb.velocity = new Vector3(inputVector.x, 0, inputVector.z);
        rb.AddForce(inputVector, ForceMode.VelocityChange);
        if (rb.velocity.magnitude > maxSpeed) {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
       
    }
}
 