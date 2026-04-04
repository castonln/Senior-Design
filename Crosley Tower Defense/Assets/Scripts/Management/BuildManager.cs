using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.EventSystems.EventTrigger;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private ShopEntry[] studentShopEntries;
    [SerializeField] private LayerMask plotMask;

    private Dictionary<string, ShopEntry> studentDict = new();
    private string selectedShopStudentKey;

    private GameObject selectedMoveStudent;
    private Plot sourcePlot;

    private bool isSelectedStudentFromShop = false;
    private bool isPlacingStudent = false;

    public static event Action OnSelectMoveStudent;
    public static event Action OnDeselectMoveStudent;

    private void Awake()
    {
        main = this;

        foreach (var student in studentShopEntries)
        {
            studentDict[student.name] = student;
        }
    }

    private void Update()
    {
        if (!isPlacingStudent) return;
        if (!Mouse.current.leftButton.wasPressedThisFrame) return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (Physics2D.OverlapPoint(mousePos, plotMask) != null) return;

        CancelPlacement();
    }

    public GameObject SpawnStudent(Plot plot)
    {
        GameObject studentObj;
        if (isSelectedStudentFromShop)
        {
            ShopEntry studentToPlace = GetSelectedShopStudent();
            LevelManager.main.SpendCurrency(studentToPlace.cost);

            studentObj = Instantiate(
                studentToPlace.prefab,
                plot.StudentSpawnPoint().position + Vector3.up * 0.5f,
                plot.StudentSpawnPoint().rotation,
                plot.transform
            );
            studentObj.name = studentToPlace.prefab.name;
        }
        else
        {
            studentObj = selectedMoveStudent;
            studentObj.transform.position = plot.StudentSpawnPoint().position + Vector3.up * 0.5f;
            studentObj.transform.rotation = plot.StudentSpawnPoint().rotation;
            studentObj.transform.SetParent(plot.transform);
            sourcePlot.ClearStudent();

            sourcePlot = null;
            selectedMoveStudent = null;
            OnDeselectMoveStudent?.Invoke();
        }

        FiringStudent firingStudent = studentObj.GetComponent<FiringStudent>();
        if (firingStudent != null)
        {
            firingStudent.SetLaneMask(plot.GetLaneMask());
            firingStudent.FindTarget();
        }

        isPlacingStudent = false;
        isSelectedStudentFromShop = false;
        selectedShopStudentKey = "";

        return studentObj;
    }

    public bool IsPlacingStudent()
    {
        return isPlacingStudent;
    }

    public bool IsMovingStudent()
    {
        return selectedMoveStudent != null;
    }

    private ShopEntry GetSelectedShopStudent()
    {
        studentDict.TryGetValue(selectedShopStudentKey, out ShopEntry student);
        return student;
    }

    public void SetSelectedStudentFromShop(string _selectedStudentKey)
    {
        selectedShopStudentKey = _selectedStudentKey;
        isSelectedStudentFromShop = true;
        isPlacingStudent = true;
    }

    public void SetSelectedStudentFromPlot(Plot plot)
    {
        sourcePlot = plot;
        selectedMoveStudent = plot.GetStudentInPlot();
        isSelectedStudentFromShop = false;
        isPlacingStudent = true;
        OnSelectMoveStudent?.Invoke();
    }

    public void CancelPlacement()
    {
        if (IsMovingStudent())
        {
            sourcePlot = null;
            selectedMoveStudent = null;
            OnDeselectMoveStudent?.Invoke();
        }
        isPlacingStudent = false;
        isSelectedStudentFromShop = false;
        selectedShopStudentKey = "";
    }

    public string GetSelectedStudentName()
    {
        return selectedMoveStudent.name;
    }

}
