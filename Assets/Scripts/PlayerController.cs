using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;

    [Header("Movement")]
    [SerializeField] private float _speed = 10f;

    [Header("Jump")]
    [SerializeField] private float _jumpPower = 0.1f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _legsDistance = 0.4f;
    [SerializeField] private Transform _legs;
    [SerializeField] private bool _isJump = false;

    [Header("Sounds")]
    [SerializeField] private AudioClip _stepsSound;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _coinSound;

    public void PlayJumpSound()
    {
        _audioSource.PlayOneShot(_jumpSound);
    }

    public void PlayStepsSound()
    {
        _audioSource.PlayOneShot(_stepsSound);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float velocityX = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(_speed * velocityX, _rigidbody.velocity.y);
        _animator.SetBool("isRunning", velocityX != 0);

        if (velocityX != 0)       
            _spriteRenderer.flipX = velocityX < 0;      
    }

    private void Jump()
    {
        float velocityY = Input.GetAxis("Jump");
        _isJump = !Physics2D.OverlapCircle(_legs.position, _legsDistance, _groundMask);
        _animator.SetBool("isJumping", _isJump);

        if (velocityY > 0 && _isJump == false)
            _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            _audioSource.PlayOneShot(_coinSound);
            Destroy(collision.gameObject);
        }
    }
}
