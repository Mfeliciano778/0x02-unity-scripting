using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    CharacterController character;
    Vector3 moveVec;
    public float speed = 15f;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        score = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        character.Move(moveVec * speed * Time.fixedDeltaTime);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        moveVec = new Vector3(direction.x, 0, direction.y);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            // disable game object
            other.gameObject.SetActive(false);
            score += 1;
            Debug.Log($"Score: {score}");
        }
    }
}
