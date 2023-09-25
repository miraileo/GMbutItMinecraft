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
        player.isGrounded = Physics2D.OverlapCircle(gameObject.transform.position, 0.7f, groundLayer);
    }
}
