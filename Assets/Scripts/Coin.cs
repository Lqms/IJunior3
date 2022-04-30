using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject _coinSoundPrefab;
    private float _timeToDestroy = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            GameObject coinSound = Instantiate(_coinSoundPrefab, transform.position, Quaternion.identity);
            Destroy(coinSound, _timeToDestroy);
            Destroy(gameObject);
        }
    }
}
