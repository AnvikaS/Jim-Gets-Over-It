using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // sprite size/location variables
    private float length, startPosition, startHeight;
    // reference to main camera
    [SerializeField]
    private GameObject Camera;
    // public variable to set parallax amount
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        // Set temp variables to current position and size
        startPosition = transform.position.x;
        startHeight = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // temp variables to check current position
        float temp = Camera.transform.position.x * (1 - parallaxEffect);

        // temp variables to show how far the player has moved with the parallax effect
        float distance = Camera.transform.position.x * parallaxEffect;
        float height = Camera.transform.position.y * parallaxEffect;

        // move the object in relation to camera dependant on parallax effect
        transform.position = new Vector3(startPosition + distance, startHeight + height, transform.position.z);

        // conditional statements to determine if sprite should be repositioned to left or right
        if (temp > startPosition + length)
        {
            startPosition += length;
        }
        else if (temp < startPosition - length)
        {
            startPosition -= length;
        }
    }
}
