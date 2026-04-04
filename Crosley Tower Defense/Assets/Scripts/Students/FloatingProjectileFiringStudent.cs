using UnityEngine;

public class FloatingProjectileFiringStudent : FiringStudent
{
    [SerializeField] private GameObject floatingProjectilePrefab;

    protected override void Shoot()
    {
        FloatingProjectile projectile = Instantiate(floatingProjectilePrefab, firingPoint.position, Quaternion.identity)
            .GetComponent<FloatingProjectile>();
        projectile.SetDirection(target.position);
    }
}