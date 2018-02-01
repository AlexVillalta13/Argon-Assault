using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float Speed = 10f;
    [SerializeField] GameObject[] guns;

    [Header("Screen Limit")]
    [SerializeField] private float xScreenLimit = 5f;
    [SerializeField] private float yMinLimit = -3f;
    [SerializeField] private float yMaxLimit = 3f;

    [Header("Rotate based on position")]
    [SerializeField] private float positionPitchFactor = -5f;

    [SerializeField] private float positionYawFactor = 5f;

    [Header("Rotate based on throw")]
    [SerializeField] private float ControlRollFactor = -20f;

    [SerializeField] private float ControlPitchFactor = -20f;

    private float xThrow, yThrow;

    private bool isControlEnable = true;

    // Use this for initialization
    void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isControlEnable)
        {
            ProcessTranslate();
            ProcessRotate();
            ProcessFiring();
        }
    }

    private void ProcessRotate()
    {
        float pitchDueToYPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToYThrow = yThrow * ControlPitchFactor;
        float pitch = pitchDueToYPosition + pitchDueToYThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * ControlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslate()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * Speed * Time.deltaTime;
        float yOffset = yThrow * Speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float XPos = Mathf.Clamp(rawXPos, -xScreenLimit, xScreenLimit);

        float rawYPos = transform.localPosition.y + yOffset;
        float YPos = Mathf.Clamp(rawYPos, yMinLimit, yMaxLimit);

        transform.localPosition = new Vector3(XPos, YPos, transform.localPosition.z);
    }

    private void PlayerDeath() // string referenced
    {
        isControlEnable = false;
    }

    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }
    }

    private void SetGunsActive(bool isActive)
    {
        foreach (GameObject gun in guns)
        {
            ParticleSystem.EmissionModule emissionModule = gun.GetComponent<ParticleSystem>().emission;
            print(emissionModule.GetType().ToString());
        }
    }
}
