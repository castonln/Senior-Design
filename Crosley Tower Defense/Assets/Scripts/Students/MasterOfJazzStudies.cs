using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MasterOfJazzStudies : FloatingProjectileFiringStudent
{
    protected override float GetInterval() => Random.Range(1, 7);

}
