using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 200f;

    private void Update()
    {
        transform.Rotate(0, 0, _rotateSpeed);
    }
}
