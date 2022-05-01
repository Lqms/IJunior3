using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyAI : Enemy
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
    private int _rightDirection = 1;
    private int _leftDirection = -1;

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
            DetermineDirection(_player.transform.position.x);
            Move(_spriteAggro);
        }
        else if (Vector2.Distance(_startPoint, transform.position) > _minimalStartPointDistance)
        {
            DetermineDirection(_startPoint.x);
            Move(_spriteSleep);
        }
    }

    private void DetermineDirection(float otherPointX)
    {
        if (transform.position.x > otherPointX)
            _direction = _leftDirection;
        else
            _direction = _rightDirection;
    }

    private void Move(Sprite movingSprite)
    {
        transform.Translate(new Vector2(_speed * _direction * Time.deltaTime, 0));
        _spriteRenderer.sprite = movingSprite;
    }
}
