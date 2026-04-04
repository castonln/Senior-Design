using UnityEngine;

public abstract class FiringStudent : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] protected float secondsBetweenFire = 2f;
    [SerializeField] protected Transform firingPoint;

    protected LayerMask laneMask;
    protected Transform target;
    protected float timeSinceFire = 0f;

    public void SetLaneMask(LayerMask _laneMask)
    {
        laneMask = _laneMask;
        FindTarget();
    }

    public LayerMask GetLaneMask() { return laneMask; }

    public void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 15f, (Vector2)transform.position, 0f, laneMask);
        target = hits.Length > 0 ? hits[0].transform : null;
    }

    public Transform GetTarget() { return target; }

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        timeSinceFire += Time.deltaTime;
        if (timeSinceFire >= secondsBetweenFire)
        {
            Shoot();
            timeSinceFire = 0f;
        }
    }

    protected abstract void Shoot();
}