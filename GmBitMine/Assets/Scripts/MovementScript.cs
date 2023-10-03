using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private float moveSpeed;

    [SerializeField] private float jumpForce;

    [SerializeField] private float flightForce;

    public bool isGrounded;

    [SerializeField] private Transform sprite;

    public bool shipMode;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (shipMode == true)
        {
            sprite.rotation = Quaternion.Euler(0,0,0);
            MoveOnShip();
            rb.gravityScale = 0;
        }
        else
        {
            Jump();
            rb.gravityScale = 8;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    void MoveOnShip()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(moveSpeed, flightForce);
        }
        else
        {
            rb.velocity = new Vector2(moveSpeed, -5);
        }
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
