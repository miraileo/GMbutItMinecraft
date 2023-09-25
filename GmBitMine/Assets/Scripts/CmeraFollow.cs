using UnityEngine;

public class CmeraFollow : MonoBehaviour
{
    public Transform target;
    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x + 2, transform.position.y, transform.position.z);
    }
}
