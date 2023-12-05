using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGun : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 2f;

    void Update()
    {
        Vector3 rotate = transform.eulerAngles;
        rotate.y += Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        rotate.x += Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotate);
    }
}