using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private InputAction rightButton;
    private InputAction leftButton;
    public float playerSpeed;

    //Vector2 playerPosition = transform.position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rightButton = InputSystem.actions.FindAction("Right");
        leftButton = InputSystem.actions.FindAction("Left");
    }


    // Update is called once per frame
    void Update()
    {
        //assigns value to playPosition -> the method i used to create boundaries for this is def wrong (made a rigidbody2d for the player) but I had to jank it up sorry Karina
        Vector2 playerPosition = transform.position;

        if (rightButton.IsPressed())
        {
            playerPosition.x += playerSpeed * Time.deltaTime;
        }
        if (leftButton.IsPressed())
        {
            playerPosition.x -= playerSpeed * Time.deltaTime;
        }

        //reassigns value to transform.position
        transform.position = playerPosition;
    }
}
