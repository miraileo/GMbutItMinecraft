using UnityEngine;
using UnityEngine.SceneManagement;

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
        player.isGrounded = Physics2D.OverlapCircle(GroundPivot.position, 0.3f, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ship")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if(other.tag == "Portal")
        {
            player.shipMode = true;
        }
    }
}
