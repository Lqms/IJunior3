using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotate : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 200f;

    void Update()
    {
        transform.Rotate(0, 0, _rotateSpeed);
    }
}
