using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerLook : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    void Update()
    {
        transform.LookAt(player);
    }
}
