using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _gravity = 9.8f;
    [SerializeField]
    private float _jumpHeight = 15f;
    private float _yVelocity;
    private bool _doubleJump = false;
    private int _coins = 0;
    private int _lives = 3;
    private UIManager _uiManager;

    public void LoseLife()
    {
        if (_lives > 0)
        {
            _lives--;
            _uiManager.UpdateLivesDisplay(_lives);
        }
    }
    public void IncrementCoins()
    {
        _coins++;
        _uiManager.UpdateCoinDisplay(_coins);
    }
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontal, 0, 0);
        Vector3 velocity = direction * _speed;
        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _doubleJump = true;
                _yVelocity = _jumpHeight;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _doubleJump)
            {
                _doubleJump = false;
                _yVelocity = _jumpHeight;
            }
            _yVelocity -= _gravity * Time.deltaTime;
        }
        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }
}
