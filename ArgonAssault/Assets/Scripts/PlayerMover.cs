using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float controlSpeed = 50f;
    [SerializeField] float xRange = 32.5f;
    [SerializeField] float yRange = 22f;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;

    float yControl, xControl;

    void Update()
    {
        ProcessControl();
    }

    void ProcessControl()
    {
        xControl = Input.GetAxis("Horizontal");
        yControl = Input.GetAxis("Vertical");

        float xOffset = xControl * Time.deltaTime * controlSpeed;
        float newXPos = transform.localPosition.x + xOffset;
        float clampedX = Mathf.Clamp(newXPos, -xRange, xRange);

        float yOffset = yControl * Time.deltaTime * controlSpeed;
        float newYPos = transform.localPosition.y + yOffset;
        float clampedY = Mathf.Clamp(newYPos, -yRange, yRange);

        transform.localPosition = new Vector3 (clampedX, clampedY, transform.localPosition.z); 
    }

    void ProccesRotation()
    {
        xControl = Input.GetAxis("Horizontal");
        yControl = Input.GetAxis("Vertical");

        float pitch = transform.localPosition.y * positionPitchFactor + yControl * controlPitchFactor;
        float yaw = 0f;
        float roll = 0f;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
