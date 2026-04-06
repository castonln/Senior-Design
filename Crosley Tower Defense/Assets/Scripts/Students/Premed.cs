using UnityEngine;

public class Premed : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LaneMultipliers multipliers;

    private Lane lane;
    private void Start()
    {
        SetLaneMultipliers();
    }
    private void OnTransformParentChanged()
    {
        SetLaneMultipliers();
    }
    private void OnBeforeTransformParentChanged()
    {
        ResetLaneMultipliers();
    }

    private void OnDestroy()
    {
        ResetLaneMultipliers();
    }

    private void SetLaneMultipliers()
    {
        lane = GetComponentInParent<Lane>();
        if (lane == null) return;
        lane.SetMultipliers(multipliers);
    }

    private void ResetLaneMultipliers()
    {
        lane = GetComponentInParent<Lane>();
        if (lane == null) return;
        lane.ResetMultipliers();
    }
}
