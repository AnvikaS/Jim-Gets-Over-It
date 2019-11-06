using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    // sprite size/location variables
    private float length, startPosition, startHeight;
    // reference to main camera
    [SerializeField]
    private GameObject camera;
    //public variable to set Parallax amount
    public float parallaxEffect;

    // Start is called before the First frame update
    void Start()
    {
        // Set temp Variables to current position and size
        startPosition = transform.position.x;
        startHeight = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        
    }

    // update is called once per frame
    void Update()
    {
        //temp variables to check current position
        float temp = camera.transform.position.x * (1 - parallaxEffect);

        // temp variables to show how far the palyer has moved with parallax effect
        float distance = camera.transform.position.x * parallaxEffect;
        float height = camera.transform.position.y * parallaxEffect;

        //move the object in relation to show how far the player has moved on para effect
        transform.position = new Vector3(startPosition + distance, startHeight * height, transform.position.z);

        // conditional statements to determine if Sprite should be responsiable reposition to left or right
        if (temp > startPosition + length)
        {
            startPosition += length;
        }
        else if (temp < startPosition - length) ;
        {
            startPosition -= length;
        }
    }








}
