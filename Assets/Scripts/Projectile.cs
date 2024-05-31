using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile: MonoBehaviour
{
    [Header("Movement System")]
    [SerializeField]
    [Min(0)]
    private float speed;

    private void Start()
    {
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * transform.up;
    }
}
