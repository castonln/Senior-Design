using TMPro;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI studentName;
    [SerializeField] private TextMeshProUGUI path1Title;
    [SerializeField] private TextMeshProUGUI path2Title;
    [SerializeField] private TextMeshProUGUI path1Description;
    [SerializeField] private TextMeshProUGUI path2Description;

    private void EnableUpgradeMenu()
    {
        gameObject.SetActive(true);
        studentName.text = BuildManager.main.GetSelectedStudentName();
    }

    private void DisableUpdgradeMenu()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        BuildManager.OnSelectMoveStudent += EnableUpgradeMenu;
        BuildManager.OnDeselectMoveStudent += DisableUpdgradeMenu;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        BuildManager.OnSelectMoveStudent -= EnableUpgradeMenu;
        BuildManager.OnDeselectMoveStudent -= DisableUpdgradeMenu;

    }
}
