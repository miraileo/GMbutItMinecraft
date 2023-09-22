using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private float moveSpeed;

    [SerializeField] private float jumpForce;

    [SerializeField] private bool isGrounded;

    [SerializeField] private Transform groundPivot;

    [SerializeField] private LayerMask groundLayer;

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
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        else if(!IsGrounded())
        {
            transform.Rotate(-Vector3.forward*0.5f);
        }
        
    }
    bool IsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundPivot.position, 0.1f, groundLayer);
        return isGrounded;
    }
}
