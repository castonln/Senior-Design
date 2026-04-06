using UnityEngine;

public class Architect : Student
{
    [SerializeField] private int healthPerInterval = 10;
    protected override float GetStrength() => healthPerInterval;
    protected override void DoAction(float health)
    {
        Tower.main.HealDamage((int)health);
    }
}