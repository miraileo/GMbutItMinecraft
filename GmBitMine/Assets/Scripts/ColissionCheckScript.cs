using UnityEngine;

public class ColissionCheckScript : MonoBehaviour
{
    MovementScript player;

    [SerializeField] private LayerMask groundLayer;
    private void Start()
    {
        player = GetComponent<MovementScript>();
    }
    private void Update()
    {
        player.isGrounded = Physics2D.OverlapCircle(gameObject.transform.position, 0.75f, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ship")
        {
            Destroy(gameObject);
        }
    }
}
