using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody Body;

    [SerializeField]
    private Animator AnimationController;

    [SerializeField]
    private Transform playerTransform;

    private float movementForward;
    private float rotationMovement;

    private void Update()
    {
        movementForward = Input.GetKey(KeyCode.W) ? 1 : 0;
        rotationMovement = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate() 
    {
        if (rotationMovement != 0)
        {
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x, 
                transform.eulerAngles.y + rotationMovement * Time.fixedDeltaTime * 30, 
                transform.eulerAngles.z
            );
        }
        Vector3 movement = Vector3.zero;
        bool isWalking = movementForward != 0;
        AnimationController.SetBool("isWalking", isWalking);
        if (isWalking) {
            movement = playerTransform.forward * movementForward * 3 * Time.fixedDeltaTime;
        }
        movement.y = 0f;
        if (isWalking) {
            Body.position = transform.position + movement;
        }
    }
}
