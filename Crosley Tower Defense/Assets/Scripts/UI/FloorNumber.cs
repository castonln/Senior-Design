using TMPro;
using UnityEngine;

public class FloorNumber : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI floorNumberUI;
    private void OnEnable()
    {
        Tower.OnFloorsStackChange += SetFloorNumber;
    }

    private void OnDisable()
    {
        Tower.OnFloorsStackChange -= SetFloorNumber;
    }

    private void SetFloorNumber()
    {
        floorNumberUI.text = Tower.main.GetFloorsStackLength().ToString();
    }
}
