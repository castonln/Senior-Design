using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private Transform centerPoint;

    [Header("Attributes")]
    [SerializeField] private float baseSpeed = 1.5f;
    [SerializeField] private float enemyDetectionRange = 2f;

    private Transform moveTarget;

    private float moveSpeed;

    private void Start()
    {
        moveSpeed = baseSpeed;
        SetTarget();
    }

    private void FixedUpdate()
    {
        if (moveTarget == null) SetTarget();

        if (GetXDistanceToTarget() < enemyDetectionRange)
        {
            moveSpeed = 0;
        } else
        {
            moveSpeed = baseSpeed;
        }

        Vector2 direction = (moveTarget.position - centerPoint.position).normalized;

        rb.linearVelocity = direction * moveSpeed;

    }

    private float GetXDistanceToTarget()
    {
        return Mathf.Abs(moveTarget.position.x - centerPoint.position.x);
    }

    public void SetTarget()
    {
        moveTarget = gameObject.GetComponent<Triceracopter>().GetLane().GetTargetPoint();
    }
}
