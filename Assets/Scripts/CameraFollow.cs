using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public Transform targetObj;
    public float speed = 2.0f;
    [SerializeField] float offsetY;
    private Vector3 startOffset;

    void Start()
    {
        startOffset = new Vector3(transform.position.x - targetObj.position.x, transform.position.y - targetObj.position.y + offsetY, transform.position.z - targetObj.position.z);
    }

    void LateUpdate()
    {
        Vector3 targetPos = targetObj.position + startOffset;
        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
    }
}

