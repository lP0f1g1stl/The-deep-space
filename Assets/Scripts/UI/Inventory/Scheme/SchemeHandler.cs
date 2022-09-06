using UnityEngine;

public class SchemeHandler : MonoBehaviour
{
    [SerializeField] private EquipmentCell[] _cells;

    [SerializeField] private EquipmentCell _currentCell;
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
        bool isCurrent = _currentCell == cell;  
        _currentCell?.CellUI.ChangeOutlineState(false);
        _currentCell?.ChangeActiveState(false);
        _currentCell = cell;
        _currentCell.CellUI.ChangeOutlineState(!isActive);
        _currentCell.ChangeActiveState(!isActive);
        if (isCurrent) _currentCell = null;
    }
    public void ChangeItemImage(Sprite newImage) 
    {
        _currentCell.CellUI.ChangeItemImage(newImage);
    }
}
