using UnityEngine;

public class ColissionCheckScript : MonoBehaviour
{
    MovementScript player;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform GroundPivot;

    private void Start()
    {
        player = GetComponent<MovementScript>();
    }
    private void Update()
    {
        player.isGrounded = Physics2D.OverlapCircle(GroundPivot.position, 0.2f, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ship")
        {
            Destroy(gameObject);
        }
    }
}
