using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGun : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 2f;
    public float rotationSpeed;
    public Camera cameraGun;
    public int distz;
    public GameObject aimart;
    public Canvas canvas;

    [Header("Jostick")] public float speed;
    public FixedJoystick variableJoystick;
    public GameObject fireButton;

    private bool isMobile;

    private Vector3 wordPoint;
    private Vector3 screenPoint;

    private void Start()
    {
        screenPoint = new Vector3(600, 400, 0);
        isMobile = Application.isMobilePlatform;
        if (isMobile)
        {
            variableJoystick.gameObject.SetActive(true);
            fireButton.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        // MoveMobile();
        // MovePC();
        if (isMobile) MoveMobile();
        else MovePC();
    }

    private void MovePC()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 screenPoint = Input.mousePosition;
            // screenPoint.z = Camera.main.farClipPlane;
            screenPoint.z = distz;
            wordPoint = Camera.main.ScreenToWorldPoint(screenPoint);
            Vector2 localPoint = Vector2.zero;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(),
                Input.mousePosition,
                Camera.main, out localPoint);

            aimart.transform.localPosition = localPoint;
            Vector3 origin = transform.position;
            Vector3 direction = (wordPoint - origin).normalized;
            Vector3 directioncam = (wordPoint - Camera.main.transform.position).normalized;

            Quaternion targetTowerRotation = Quaternion.LookRotation(direction);
            transform.rotation =
                Quaternion.Lerp(transform.rotation, targetTowerRotation, rotationSpeed * Time.deltaTime);

            Debug.DrawRay(Camera.main.transform.position, directioncam * 100, Color.red);
            Debug.DrawRay(transform.position, direction * 100, Color.yellow);
        }
    }

    private void MoveMobile()
    {
        Vector3 directions = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        screenPoint = screenPoint + new Vector3(directions.x, directions.z, 0) * speed;
        screenPoint.z = distz;
        wordPoint = Camera.main.ScreenToWorldPoint(screenPoint);
        Vector2 localPoint = Vector2.zero;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(),
            screenPoint,
            Camera.main, out localPoint);
        aimart.transform.localPosition = localPoint;
        Vector3 origin = transform.position;
        Vector3 direction = (wordPoint - origin).normalized;
        Vector3 directioncam = (wordPoint - Camera.main.transform.position).normalized;

        Quaternion targetTowerRotation = Quaternion.LookRotation(direction);
        transform.rotation =
            Quaternion.Lerp(transform.rotation, targetTowerRotation, rotationSpeed * Time.deltaTime);

        Debug.DrawRay(Camera.main.transform.position, directioncam * 100, Color.red);
        Debug.DrawRay(transform.position, direction * 100, Color.yellow);
    }
}