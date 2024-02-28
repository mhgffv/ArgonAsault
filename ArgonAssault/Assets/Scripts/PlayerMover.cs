using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float controlSpeed = 50f;
    [SerializeField] float xRange = 32.5f;
    [SerializeField] float yRange = 22f;
    [SerializeField] float RotationRange  = 3f;

    void Update()
    {
        float xControl = Input.GetAxis("Horizontal");
        float yControl = Input.GetAxis("Vertical");

        float xOffset = xControl * Time.deltaTime * controlSpeed;
        float newXPos = transform.localPosition.x + xOffset;
        float clampedX = Mathf.Clamp(newXPos, -xRange, xRange);

        float yOffset = yControl * Time.deltaTime * controlSpeed;
        float newYPos = transform.localPosition.y + yOffset;
        float clampedY = Mathf.Clamp(newYPos, -yRange, yRange);

        float RotationOffset = xControl * Time.deltaTime * controlSpeed;
        float newRotationPos = transform.localRotation.x + RotationOffset;
        float clampedRotation = Mathf.Clamp(newRotationPos, -RotationRange, RotationRange);


        transform.localPosition = new Vector3 (clampedX, clampedY, transform.localPosition.z);
    }
}
