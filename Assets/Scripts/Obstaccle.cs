using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaccle : MonoBehaviour
{
    bool canMove = true;

    private void Awake()
    {
        Destroy(gameObject, 2f);
    }
    void FixedUpdate()
    {
        if (canMove)
            transform.position = transform.position + -(transform.right / 3);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canMove = false;
            GameManager.instance.canMove = false;
            StaticEvents.obstaccleTouch?.Invoke(gameObject);
            Destroy(gameObject);
        }
    }
}
