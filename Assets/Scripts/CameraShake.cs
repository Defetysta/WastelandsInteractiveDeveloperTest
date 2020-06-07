﻿using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance = null;
    [SerializeField]
    private FloatVariable shakeDuration = null;
    [SerializeField]
    private FloatVariable shakeMagnitude = null;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void StartShake()
    {
        StartCoroutine(Shake(shakeDuration.Value, shakeMagnitude.Value));
    }

    private IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}