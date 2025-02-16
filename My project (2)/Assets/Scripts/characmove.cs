using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;
    public Transform head; // Assign "Head" in the Inspector

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Move relative to the head's forward direction
        Vector3 move = head.forward * moveZ + head.right * moveX;
        move.y = 0; // Prevent vertical movement

        // controller.Move(move * speed * Time.deltaTime);
        controller.SimpleMove(move * speed);

    }
}