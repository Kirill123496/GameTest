using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private PlayerInputSystem _playerActionsAsset;
    private InputAction _move;

    private Rigidbody _rb;
    [SerializeField] private float _movementForce = 1f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _maxSpeed = 5f;
    private Vector3 _forceDirection = Vector3.zero;

    [SerializeField] private Camera _playerCamera;
    private Animator _animator;

    private void Awake()
    {
        _rb = this.GetComponent<Rigidbody>();
        _playerActionsAsset = new PlayerInputSystem();
        _animator = this.GetComponent<Animator>();
    }
    private void OnEnable()
    {
        _playerActionsAsset.Player.Jump.started += DoJump;
        _playerActionsAsset.Player.Attack.started += DoAttack;
        _move = _playerActionsAsset.Player.Move;
        _playerActionsAsset.Player.Enable();
    }
    private void OnDisable()
    {
        _playerActionsAsset.Player.Jump.started -= DoJump;
        _playerActionsAsset.Player.Attack.started -= DoAttack;
        _playerActionsAsset.Player.Disable();
    }
    private void FixedUpdate()
    {
        _forceDirection += _move.ReadValue<Vector2>().x * GetCameraRight(_playerCamera) * _movementForce;
        _forceDirection += _move.ReadValue<Vector2>().y * GetCameraForward(_playerCamera) * _movementForce;

        _rb.AddForce(_forceDirection, ForceMode.Impulse);
        _forceDirection = Vector3.zero;

        if (_rb.velocity.y < 0f)
            _rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

        Vector3 horizontalVelocity = _rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > _maxSpeed * _maxSpeed)
            _rb.velocity = horizontalVelocity.normalized * _maxSpeed + Vector3.up * _rb.velocity.y;


        if (_rb.angularVelocity.y == 0)
        {
            _animator.SetTrigger("Idle");
        }
        if (_rb.angularVelocity.y!=0)
        {
            _animator.SetTrigger("Run");
        }

        LookAt();
    }
    private void LookAt()
    {
        Vector3 direction = _rb.velocity;
        direction.y = 0f;

        if (_move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            this._rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            _rb.angularVelocity = Vector3.zero;
    }
    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }
    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }
    private void DoJump(InputAction.CallbackContext obj)
    {
        if (IsGrounded())
        {
            _forceDirection += Vector3.up * _jumpForce;
        }
    }
    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
            return true;
        else
            return false;
    }
    private void DoAttack(InputAction.CallbackContext obj)
    {
        _animator.SetTrigger("Attack");
    }
    public void DoMove()
    {
        _animator.SetTrigger("Run");
    }
}