using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameManager.instance.isGrounded = true;
            if (Movement.instance.currentState != PlayerState.Death && GameManager.instance.canMove)
            {
                Movement.instance.currentState = PlayerState.Running;
                Movement.instance.SwitchState();
            }
        }
    }
}
