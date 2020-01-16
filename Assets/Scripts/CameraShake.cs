﻿using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDecayStart = 0.002f;
    [SerializeField] float shakeIntensityStart = 0.03f;

    private float shakeDecay;
    private float shakeIntensity;

    private Vector3 originPosition;
    private Quaternion originRotation;
    private bool shaking;
    private Transform transformAtOrigin;

    void OnEnable()
    {
        transformAtOrigin = transform;
    }

    void Update()
    {
        if (!shaking)
            return;
        if (shakeIntensity > 0f)
        {
            transformAtOrigin.localPosition = originPosition + Random.insideUnitSphere * shakeIntensity;
            transformAtOrigin.localRotation = new Quaternion(
                originRotation.x + Random.Range(-shakeIntensity, shakeIntensity) * .1f,
                originRotation.y + Random.Range(-shakeIntensity, shakeIntensity) * .1f,
                originRotation.z + Random.Range(-shakeIntensity, shakeIntensity) * .1f,
                originRotation.w + Random.Range(-shakeIntensity, shakeIntensity) * .1f);
            shakeIntensity -= shakeDecay;
        }
        else
        {
            shaking = false;
            transformAtOrigin.localPosition = originPosition;
            transformAtOrigin.localRotation = originRotation;
        }
    }

    public void Shake()
    {
        if (!shaking)
        {
            originPosition = transformAtOrigin.localPosition;
            originRotation = transformAtOrigin.localRotation;
        }
        shaking = true;
        shakeDecay = shakeDecayStart;
        shakeIntensity = shakeIntensityStart;
    }
}