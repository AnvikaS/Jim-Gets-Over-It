using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;

    // Player movement variables
    float speed = 5f;
    Vector3 move;
    float horizontalMove = 0f;
    public Vector2 jumpHeight = new Vector2(0, 3);

    // Player direction flag
    bool facingRight = true;
    // Player ground check flag
    bool isGrounded;

    // Start is called before the first frame update
    void Update()
    {
        // Temp variable to store player input value
        move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        horizontalMove = move.x * speed;

        // set anim controller Speed
        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // Player jump detection
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded)
        {
            isGrounded = false;
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
        }

        // Update player position
        transform.position += move * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Set temp variable to store and manipulate local scale
        Vector3 localScale = transform.localScale;

        // Set moving right boolean dependant on direction facing
        if (move.x < 0)
        {
            facingRight = false; 
        }
        else
        {
            if (move.x > 0)
            {
                facingRight = true;
            }
        }

        // Set temp local scale variable to direction
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        // Set players local scale variable to set sprite direction
        transform.localScale = localScale;

    }

    // check if player is touching ground
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
            //Debug.Log("Grounded");
            isGrounded = true;
        }
    }
        
    
}
