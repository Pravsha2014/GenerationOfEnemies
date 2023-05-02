using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnEnable()
    {
        DestroyWithDelay();
    }

    public float Frequency { get; private set; }

    public void SetFrequencyValue(float frequency)
    {
        Frequency = frequency;
    }

    private void DestroyWithDelay()
    {
        float addedTimeToDestroy = 2f;

        Destroy(gameObject, Frequency + addedTimeToDestroy);
    }
}
