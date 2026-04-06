using UnityEngine;

public abstract class Student : MonoBehaviour
{
    [SerializeField] protected float secondsPerInterval = 1f;
    private float timeSinceAction = 0f;

    protected float speedMultiplier = 1f;
    protected float strengthMultiplier = 1f;

    protected abstract float GetStrength();
    protected virtual float GetInterval() => secondsPerInterval;

    private void Update()
    {
        if (!EnemySpawner.main.IsWaveActive()) return;
        timeSinceAction += Time.deltaTime;
        if (timeSinceAction >= secondsPerInterval / speedMultiplier)
        {
            DoAction(GetStrength() * strengthMultiplier);
            timeSinceAction = 0f;
        }
    }

    public void SetMultipliers(LaneMultipliers _multipliers)
    {
        strengthMultiplier = _multipliers.strength;
        speedMultiplier = _multipliers.speed;
        Debug.Log(gameObject.name + " Multi: " + strengthMultiplier);
    }

    protected abstract void DoAction(float strength);
}