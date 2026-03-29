using UnityEngine;

public enum SpawnSide {
    left,
    right,
    topLeft,
    topRight,
};

[System.Serializable]
public struct SubWaveInfo
{
    public GameObject enemyPrefab;
    public int count;
    public float secondsBetweenEnemies;
    public SpawnSide spawnSide;
}

[CreateAssetMenu(fileName = "WaveData", menuName = "Waves/WaveData")]

public class WaveData : ScriptableObject
{
    public SubWaveInfo[] subWaves;
}
