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
        //assigns value to playPosition
        Vector2 playerPosition = transform.position;

        if (rightButton.IsPressed())
        {
            playerPosition.x += playerSpeed * Time.deltaTime;
            Debug.Log("Player moving right!");
        }
        if (leftButton.IsPressed())
        {
            playerPosition.x -= playerSpeed * Time.deltaTime;
            Debug.Log("Player moving left!");
        }

        //reassigns value to transform.position
        transform.position = playerPosition;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Edible"))
        {
            Destroy(other.gameObject);
            Debug.Log("Edible object in pot!");
        }
        else if(other.gameObject.CompareTag("Inedible"))
        {
            Destroy(other.gameObject);
            Debug.Log("That doesn't belong in soup");
        }
    }
}
