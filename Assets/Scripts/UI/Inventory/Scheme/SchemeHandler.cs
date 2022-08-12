using UnityEngine;

public class SchemeHandler : MonoBehaviour
{
    [SerializeField] private EquipmentCell[] _cells;

    private EquipmentCell _currentCell;
    public EquipmentCell CurrentCell => _currentCell;

    private void OnEnable()
    {
        foreach( EquipmentCell cell in _cells) 
        {
            cell.OnCellClick += ChangeActiveCell;
        }
    }
    private void OnDisable()
    {
        foreach (EquipmentCell cell in _cells)
        {
            cell.OnCellClick += ChangeActiveCell;
        }
    }
    private void ChangeActiveCell(EquipmentCell cell, bool isActive) 
    {
        _currentCell?.CellUI.ChangeOutlineState(false);
        _currentCell?.ChangeActiveState(false);
        _currentCell = cell;
        _currentCell.CellUI.ChangeOutlineState(!isActive);
        _currentCell.ChangeActiveState(!isActive);
    }
    public void ChangeItemImage(Sprite newImage) 
    {
        CurrentCell?.CellUI.ChangeItemImage(newImage);
    }
}
