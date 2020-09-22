using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{

    [SerializeField] private float parallaxEffectMultiplier = .5f;
    private Transform cameraTransform;
    private Vector3 lastcameraPosition;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastcameraPosition = cameraTransform.position;
    }


    void Update()
    {
        Vector3 deltaMovement = cameraTransform.position - lastcameraPosition;
        transform.position += deltaMovement * parallaxEffectMultiplier;
        lastcameraPosition = cameraTransform.position;
    }

}
