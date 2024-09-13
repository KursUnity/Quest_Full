using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpForce;
    public float XAxisLeft, XAxisRight;
    private bool _isMoveLeft, _isMoveRight;
    private Animator _animator;
    private Rigidbody2D _rb;
    private bool _isCanJump = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        InputCheker();

        if (_isMoveLeft && transform.position.x > XAxisLeft)
        {
            transform.position = new Vector2(transform.position.x - Speed * Time.deltaTime, transform.position.y);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (_isMoveRight && transform.position.x < XAxisRight)
        {
            transform.position = new Vector2(transform.position.x + Speed * Time.deltaTime, transform.position.y);
            transform.localScale = new Vector2(1, 1);
        }
    }

    private void InputCheker()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _isMoveLeft = true;
            _animator.SetBool("isRun", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            _isMoveLeft = false;
            _animator.SetBool("isRun", false);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _isMoveRight = true;
            _animator.SetBool("isRun", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            _isMoveRight = false;
            _animator.SetBool("isRun", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isCanJump)
            {
                _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                _animator.SetTrigger("Jump");
                _isCanJump = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            _isCanJump = true;
        }
    }
}
