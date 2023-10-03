using UnityEngine;

public class CmeraFollow : MonoBehaviour
{
    public Transform target;
    float pos;
    private void Start()
    {
        pos = transform.position.y - 1;
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x + 2, pos, transform.position.z);
    }
}
