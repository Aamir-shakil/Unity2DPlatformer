using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    [Header("Movement")]
    public float movementSpeed = 5f;
    float horizontalMovement;

    [Header("Jumping")]
    public float jumpPower = 10f;


    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * movementSpeed, rb.linearVelocity.y);

    }

    public void Move(InputAction.CallbackContext context) 
    {
        horizontalMovement = context.ReadValue<Vector2>().x;

    }

    public void Jump(InputAction.CallbackContext context) 
    {
        if (context.performed)
        {   //Hold down the button to jump higher, release to jump lower
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
        }
        else if (context.canceled) 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y / 2);
        }
    }
}
