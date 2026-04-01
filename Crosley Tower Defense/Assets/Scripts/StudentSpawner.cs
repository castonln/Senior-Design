using UnityEngine;
using UnityEngine.EventSystems;

public class StudentSpawner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("References")]
    [SerializeField] Transform studentSpawnPoint;
    [SerializeField] SpriteRenderer plot;
    [SerializeField] GameObject studentGroup;

    bool plotFilled = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!BuildManager.main.IsPlacingStudent()) return;
        if (plotFilled) return;

        plot.enabled = true;
    }

    public void OnPointerClick(PointerEventData eventData) 
    {
        if (!BuildManager.main.IsPlacingStudent()) return;
        if (plotFilled) return;

        SpawnStudent();

        plot.enabled = false;
        BuildManager.main.SetIsPlacingStudent(false);
        plotFilled = true;
     }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!BuildManager.main.IsPlacingStudent()) return;
        if (plotFilled) return;

        plot.enabled = false;
    }
    public void SpawnStudent()
    {
        Placeable studentToPlace = BuildManager.main.GetSelectedPlaceable();

        if (BuildManager.main.IsSelectedPlaceableBought())
        {
            // TODO: destroy or something
        } 
        else
        {
            LevelManager.main.SpendCurrency(studentToPlace.cost);
        }

        GameObject student = Instantiate(
                studentToPlace.prefab,
                studentSpawnPoint.position + Vector3.up,
                studentSpawnPoint.rotation,
                studentGroup.transform
            );
    }
}
