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

    [SerializeField]
    private GameObject[] cameras;

    private void Update()
    {
        movementForward = Input.GetAxisRaw("Vertical") > 0 ? 1 : 0;
        rotationMovement = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.P))
        {
            cameras[0].SetActive(false);
            cameras[1].SetActive(true);
        }
        else 
        {
            cameras[0].SetActive(true);
            cameras[1].SetActive(false);
        }
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
