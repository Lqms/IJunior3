using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class SawRotate : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 200f;

    void Update()
    {
        transform.Rotate(0, 0, _rotateSpeed);
    }
}
