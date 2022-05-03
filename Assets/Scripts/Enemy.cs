using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _minimalStartPointDistance = 0.1f;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _hitDistance = 1f;
    [SerializeField] private int _direction = 1;
    [SerializeField] private Sprite _spriteAggro;
    [SerializeField] private Sprite _spriteSleep;
    [SerializeField] private Player _target;

    private SpriteRenderer _spriteRenderer;
    private Vector3 _startPoint;
    private bool _isTargetVisible = false;

    private const int RightDirection = 1;
    private const int LeftDirection = -1;

    private void Start()
    {
        _startPoint = transform.position;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (_target == null)
            return;

        if (_isTargetVisible)
        {
            DetermineDirection(_target.transform.position.x);
            Move(_spriteAggro);

            if (Vector2.Distance(transform.position, _target.transform.position) < _hitDistance)
                _target.Die();
        }
        else if (Vector2.Distance(_startPoint, transform.position) > _minimalStartPointDistance)
        {
            DetermineDirection(_startPoint.x);
            Move(_spriteSleep);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _isTargetVisible = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _isTargetVisible = false;
        }
    }

    private void DetermineDirection(float otherPointX)
    {
        if (transform.position.x > otherPointX)
            _direction = LeftDirection;
        else
            _direction = RightDirection;
    }

    private void Move(Sprite movingSprite)
    {
        transform.Translate(new Vector2(_speed * _direction * Time.deltaTime, 0));
        _spriteRenderer.sprite = movingSprite;
    }
}
