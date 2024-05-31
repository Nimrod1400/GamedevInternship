using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile: MonoBehaviour
{
    [Header("Movement System")]
    [SerializeField]
    [Min(0)]
    private float speed;

    [Header("Area Handlers")]
    [SerializeField]
    private TriggerHandler attackAreaHandler;

    private void Awake()
    {
        attackAreaHandler.OnTriggerEnter += OnAttackAreaTriggerHandler;
    }

    private void OnDestroy()
    {
        attackAreaHandler.OnTriggerEnter -= OnAttackAreaTriggerHandler;
    }

    private void Start()
    {
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * transform.up;
    }

    private void OnAttackAreaTriggerHandler(Collider2D other)
    {
        if (!other.TryGetComponent(out Enemy _))
            return;

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
