using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    // check if object colliding with Gem is player
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("Player")) ;
        {
            // increase Players jump height if gem Collected
            collision.gameObject.GetComponent<PlayerMovement>().jumpHeight += new Vector2(0, 1);
            //destroy gem object when collected
            Destroy(this.gameObject);
        }

    }

}




