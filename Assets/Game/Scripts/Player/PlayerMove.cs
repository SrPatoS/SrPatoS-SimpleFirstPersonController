using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : GameBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerData _data;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;

    //Internal
    private const float _groundCheckRadius = 0.2f;
    private CharacterController _controller;
    private float _speed;
    public Vector2 Velocity {get; private set;}
    private Vector3 _gravityVelocity;
    protected override void Init()
    {
        _controller = GetComponent<CharacterController>();    
    }

    protected override void Frame()
    {
        Move();
        ChangeSpeed();
        Gravity();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Velocity = new Vector2(x, y);

        Vector3 move = transform.right * x + transform.forward * y;
        _controller.Move(move * (Time.deltaTime * _speed));
    }

    private void ChangeSpeed()
    {
        bool canRun = Input.GetKey(KeyCode.LeftShift) && Velocity.y > 0.1f;
        if(canRun && _speed != _data.RunSpeed)
            _speed = _data.RunSpeed;
        else if(!canRun && _speed != _data.WalkSpeed)
            _speed = _data.WalkSpeed;
    }

    private void Gravity()
    {
        float gravityForce = (_data.GravityForce);
        if(Input.GetKeyDown(KeyCode.Space) && CanJump())
            _gravityVelocity.y = Mathf.Sqrt(_data.JumpForce * -2f * gravityForce);

        _gravityVelocity.y += gravityForce * Time.deltaTime;
        _controller.Move(_gravityVelocity * Time.deltaTime);
    }

    private bool CanJump()
    {
        bool canJump = Physics.CheckSphere(_groundCheck.position, _groundCheckRadius, _groundMask);
        //print($"CanJump: {canJump}");
        return canJump;
    }
}
