using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Cached components
    Rigidbody2D myRigidBody2d;

    // Configurations
    [SerializeField] float moveSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            myRigidBody2d.velocity = new Vector2(moveSpeed, 0f);

        } else
        {
            myRigidBody2d.velocity = new Vector2(-moveSpeed, 0f);

        }
    }


    bool IsFacingRight()
    {
        return transform.localScale.x == 1;
    }

    // should be redone as raycast 
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody2d.velocity.x)), 1f);
        }
    }

}
