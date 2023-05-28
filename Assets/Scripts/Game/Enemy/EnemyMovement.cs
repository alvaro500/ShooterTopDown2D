using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private Rigidbody2D _rigidBody;
    private PlayerAwarenessController _playerAwarenessController;
    private Vector2 _targetDirection;

    // Start is called before the first frame update
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }
    
    private void UpdateTargetDirection()
    {
        if (_playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }else
        {
            _targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTarget()
    {
        if (_targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        _rigidBody.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        if (_targetDirection == Vector2.zero)
        {
            _rigidBody.velocity = Vector2.zero;
        }
        else
        {
            _rigidBody.velocity = transform.up * _speed;
        }
    }
}