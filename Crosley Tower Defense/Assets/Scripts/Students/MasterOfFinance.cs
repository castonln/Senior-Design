using UnityEngine;

public class MasterOfFinance : FinancialAdvisor
{
    [SerializeField] private int moneyToAddToBaseAfterWave;
    private int currentMoney;
    private int waves = 1;

    protected override float GetStrength() => currentMoney;

    protected override void DoAction(float _money)
    {
        base.DoAction(_money);
        currentMoney *= 2;
    }

    private void WaveEndUpdateMoneyPerInterval()
    {
        currentMoney = moneyToAddToBaseAfterWave * waves;
        waves++;
    }

    private void OnEnable()
    {
        EnemySpawner.OnWaveEnd += WaveEndUpdateMoneyPerInterval;
    }

    private void OnDisable()
    {
        EnemySpawner.OnWaveEnd -= WaveEndUpdateMoneyPerInterval;
    }
}