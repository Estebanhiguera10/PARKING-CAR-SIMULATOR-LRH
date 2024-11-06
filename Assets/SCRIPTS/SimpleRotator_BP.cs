using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotator_BP : MonoBehaviour
{
    //Rotational Speed
    public float speed = 0f;

    void Update()
    {
            transform.Rotate(0, 0, -Time.deltaTime * speed, Space.Self);
    }
}