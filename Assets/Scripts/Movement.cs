using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Running,
    Death
}

public class Movement : MonoBehaviour
{
    public static Movement instance;
    [SerializeField] private Rigidbody2D rb;
    public PlayerState currentState = PlayerState.Running;
    [SerializeField] private Animator anim;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    [SerializeField] private float moveInput;
    public bool isGrounded, canMove = true;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    void Start()
    {
        SwitchState();
    }
    private void OnEnable()
    {
        StaticEvents.obstaccleTouch += Death;
    }

    private void OnDisable()
    {
        StaticEvents.obstaccleTouch -= Death;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (GameManager.instance.canMove && GameManager.instance.isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        if (GameManager.instance.canMove)
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
    void Jump()
    {
        anim.SetTrigger("Jump");
        rb.AddForce(new Vector2(0, jumpForce));
        GameManager.instance.isGrounded = false;
    }
    void Death(GameObject obj)
    {
        currentState = PlayerState.Death;
        SwitchState();
    }


    public void SwitchState()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                // idle kullanım için
                break;

            case PlayerState.Running:
                if (canMove && !anim.GetCurrentAnimatorStateInfo(0).IsName("death"))
                {
                    anim.SetTrigger("Run");
                }
                break;

            case PlayerState.Death:
                anim.SetTrigger("Death");
                GameManager.instance.canMove = false;
                StartCoroutine(GameManager.instance.RestartTheGame());
                break;

            default:
                break;
        }
    }

}


