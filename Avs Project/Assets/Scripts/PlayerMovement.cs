using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    public Animator animator;

    private float horizontal;
    private float vertical;
    private float facing = 0f;//facing

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Inputs();

    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * GameManager.Instance.playerMoveSpd, vertical * GameManager.Instance.playerMoveSpd);//
    }
    void Inputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        /*
        facing = horizontal;
        if (facing > 0f)
        {
            transform.localScale = new Vector2(1, 1);//turns right
        }
        else if (facing < 0f)
        {
            transform.localScale = new Vector2(-1, 1);//turns left
        }
        */
    }
}
