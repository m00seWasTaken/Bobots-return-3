using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControl : MonoBehaviour
{

    private Rigidbody2D rb;
    private float input;

    [SerializeField] private float MoveSpeed, jumpForce, groundCheckRadius = 1;          //Istället för public, gör så att den syns fast den är private
    [SerializeField] private int numJumps;
    [SerializeField] private bool canJump;

    [SerializeField] Transform groundCheck;
    public LayerMask isGround;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        numJumps = 1;
        canJump = true;
    }

    // FixedUpdate is called once per 50 frame
    private void FixedUpdate()
    {
        moveCube();
    }

    private void Update()
    {
        if (canJump == true)    // samma som canJump == 1
        {
            numJumps = 1;
        }
        if(Input.GetKeyDown(KeyCode.Space) && numJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            numJumps--;
        }

        input = Input.GetAxisRaw("Horizontal");
    }

    private void moveCube()
    {
        canJump = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGround);    //vart den är, radius och om den är i marken
        rb.velocity = new Vector2(input * MoveSpeed, rb.velocity.y);
    }


}
