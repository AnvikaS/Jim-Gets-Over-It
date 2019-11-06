using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // check if object colliding with gem is player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            // increase players jump height if gem collected
            collision.gameObject.GetComponent<PlayerMovement>().jumpHeight += new Vector2(0, 1);
            // Destroy gem object when collected
            Destroy(this.gameObject);
        }
    }
}
