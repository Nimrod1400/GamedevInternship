using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement System")]
    [SerializeField]
    [Min(0)]
    private float speed;

    [Header("Area Handlers")]
    [SerializeField]
    private TriggerHandler viewAreaHandler;

    [SerializeField]
    private TriggerHandler attackAreaHandler;

    private MovementSystem movementSystem;

    private Transform target;

    private void Update()
    {
        if (target == null)
            return;

        var moveDirection = target.position - transform.position;
        movementSystem.Move(moveDirection);
    }

    private void Awake()
    {
        movementSystem = new MovementSystem(transform, speed);

        viewAreaHandler.OnTriggerEnter += OnViewAreaTriggerEntered;
        viewAreaHandler.OnTriggerExit += OnViewAreaTriggerExited;
        attackAreaHandler.OnTriggerEnter += OnAttackAreaTriggerEntered;
    }

    private void OnDestroy()
    {
        viewAreaHandler.OnTriggerEnter -= OnViewAreaTriggerEntered;
        viewAreaHandler.OnTriggerExit -= OnViewAreaTriggerExited;
        attackAreaHandler.OnTriggerEnter -= OnAttackAreaTriggerEntered;
    }

    private void OnViewAreaTriggerEntered(Collider2D other)
    {
        if (!other.TryGetComponent(out Player _))
            return;

        target = other.transform;
    }

    private void OnViewAreaTriggerExited(Collider2D other)
    {
        if (!other.TryGetComponent(out Player _))
            return;

        target = null;
    }

    private void OnAttackAreaTriggerEntered(Collider2D other)
    {
        if (!other.TryGetComponent(out Player _))
            return;

        Destroy(other.gameObject);
    }
}
