using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private float moveSpeed;

    [SerializeField] private float jumpForce;

    public bool isGrounded;

    [SerializeField] private Transform sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else if (isGrounded == false)
        {
            sprite.Rotate(-Vector3.forward * 1.2f);
        }
        else if(isGrounded == true)
        {
            Vector3 Rotatation = sprite.rotation.eulerAngles;
            Rotatation.z = Mathf.Round(Rotatation.z / 90) * 90;
            sprite.rotation = Quaternion.Euler(Rotatation);
        }
    }
}
