using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private Placeable[] placeables;

    private int selectedPlaceable = 0;
    private bool isSelectedPlaceableBought = false;

    private bool isPlacingStudent = false;

    private void Awake()
    {
        main = this;
    }

    public bool IsPlacingStudent()
    {
        return isPlacingStudent;
    }

    public void SetIsPlacingStudent(bool _isPlacingStudent)
    {
        isPlacingStudent = !isPlacingStudent;
    }

    public Placeable GetSelectedPlaceable()
    {
        return placeables[selectedPlaceable];
    }

    public void SetSelectedPlaceableFromShop(int _selectedPlaceable)
    {
        selectedPlaceable = _selectedPlaceable;
        isPlacingStudent = true;
    }

    public bool IsSelectedPlaceableBought()
    {
        return isSelectedPlaceableBought;
    }

    public void SetIsSelectedPlaceableBought(bool _isSelectedPlaceableBought)
    {
        isSelectedPlaceableBought = _isSelectedPlaceableBought;
    }
}
