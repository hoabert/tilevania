using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    // Config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    float gravityScaleAtStart;

    // State
    bool isAlive = true;
    float jumpsLeft = 1;

    // Cached component references
    Rigidbody2D myRigidBody;
    Animator myAnimator ;
    Collider2D bodyCollider2D;
    Collider2D feetCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        bodyCollider2D = GetComponent<Collider2D>();
        feetCollider2D = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }

        Run();
        FlipSprite();
        Jump();
        ClimbLadder();
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal"); // value is between -1 to 1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);

        
    }

    private void Jump()
    {
        bool grounded = feetCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
    }
    
    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }


    }

    private void ClimbLadder()
    {
        if (!bodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Ladders"))) {

            myAnimator.SetBool("isClimbing", false);
            myRigidBody.gravityScale = gravityScaleAtStart;
            return;
        }

        float controlThrow = Input.GetAxis("Vertical");

        if (controlThrow > Mathf.Epsilon)
        {
            myRigidBody.gravityScale = 0f;
        }

        if (Mathf.Abs(controlThrow) > Mathf.Epsilon)
        {
            Debug.Log("climbing");
            Vector2 climbingVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbSpeed);
            myRigidBody.velocity = climbingVelocity;

            bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
            myAnimator.SetBool("isClimbing", playerHasVerticalSpeed);
        }




    }

    private void deathHandler()
    {
        
    }

}

