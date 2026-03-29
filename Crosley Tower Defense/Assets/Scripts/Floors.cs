using UnityEngine;

public class Floors : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Tower tower;

    [Header("Attributes")]
    [SerializeField] private float fallSpeed = 5.0f;

    public void TakeDamage(int damage)
    {
        tower.TakeDamage(damage);
    }
}
