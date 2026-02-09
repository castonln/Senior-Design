using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Student : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float targetingRange = 15f;
    private Transform target;
    [SerializeField] private float bps = 0.5f;
    [SerializeField] Transform firingPoint;
    [SerializeField] private LayerMask enemyMask;

    [Header("References")]
    [SerializeField] GameObject bulletPrefab;

    private float timeUntilFire = 0f;

    private void Start()
    {

    }

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;

            if (timeUntilFire >= 1f / bps)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
}
