using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask enemyMask;

    [Header("Attributes")]
    [SerializeField] private float baseSpeed = 1.5f;
    [SerializeField] private float enemyDetectionRange = 2f;

    private Transform moveTarget;

    private float moveSpeed;

    private void Start()
    {
        moveSpeed = baseSpeed;
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(moveTarget.position, transform.position) < enemyDetectionRange
            || IsNearSlowingEnemy())
        {
            moveSpeed = moveSpeed <= 0f ? 0f : (0.95f * moveSpeed) - 0.05f;
        }

        if (Vector2.Distance(moveTarget.position, transform.position) < 0.1f) return;

        Vector2 direction = (moveTarget.position - transform.position).normalized;

        rb.linearVelocity = direction * moveSpeed;

    }

    public void SetTarget(Transform newTarget)
    {
        moveTarget = newTarget;
    }

    private bool IsNearSlowingEnemy()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, enemyDetectionRange, (Vector2)transform.position, 0f, enemyMask);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.rigidbody.GetComponent<EnemyMovement>().IsDecelerating()) return true;
        }
        return false;
    }

    public bool IsDecelerating()
    {
        if (moveSpeed < baseSpeed) return true;
        else return false;
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, enemyDetectionRange);
    }
}
