using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _aggroDistanceX = 5f;
    [SerializeField] private float _aggroDistanceY = 2f;
    [SerializeField] private float _minimalStartPointDistance = 0.1f;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private int _direction = 1;
    [SerializeField] private Sprite _spriteAggro;
    [SerializeField] private Sprite _spriteSleep;
    [SerializeField] private Player _player;

    private SpriteRenderer _spriteRenderer;
    private Vector3 _startPoint;

    private void Start()
    {
        _startPoint = transform.position;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_player == null)
            return;

        if (Vector2.Distance(_player.transform.position, transform.position) < _aggroDistanceX &&
            Mathf.Abs(_player.transform.position.y - transform.position.y) < _aggroDistanceY)
        {
            if (transform.position.x > _player.transform.position.x)
                _direction = -1;
            else
                _direction = 1;

            transform.Translate(new Vector2(_speed * _direction * Time.deltaTime, 0));
            _spriteRenderer.sprite = _spriteAggro;
        }
        else if (Vector2.Distance(_startPoint, transform.position) > _minimalStartPointDistance)
        {
            if (transform.position.x > _startPoint.x)
                _direction = -1;
            else
                _direction = 1;

            transform.Translate(new Vector2(_speed * Time.deltaTime, 0));
            _spriteRenderer.sprite = _spriteSleep;
        }
    }
}
