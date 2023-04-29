using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy();
    }

    public float Frequency { get; private set; }

    public void SetFrequencyValue(float frequency)
    {
        Frequency = frequency;
    }

    private void Destroy()
    {
        float addedTimeToDestroy = 2f;

        Destroy(gameObject, Frequency + addedTimeToDestroy);
    }
}
