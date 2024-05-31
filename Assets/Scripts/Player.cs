using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement System")]
    [SerializeField]
    [Min(0)]
    private float speed;

    [Header("Look at Target System")]
    [SerializeField]
    private Camera mainCamera;

    private MovementSystem movementSystem;
    private LookAtTargetSystem lookAtTargetSystem;

    private void Awake()
    {
        movementSystem = new MovementSystem(transform, speed);
        lookAtTargetSystem = new LookAtTargetSystem(transform);
    }

    private void Update()
    {
        Vector2 movementDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
            movementDirection += Vector2.up;
        if (Input.GetKey(KeyCode.S))
            movementDirection += Vector2.down;
        if (Input.GetKey(KeyCode.D))
            movementDirection += Vector2.right;
        if (Input.GetKey(KeyCode.A))
            movementDirection += Vector2.left;

        Vector3 cursorWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        movementSystem.Move(movementDirection);
        lookAtTargetSystem.LookAt(cursorWorldPosition);
    }
}
