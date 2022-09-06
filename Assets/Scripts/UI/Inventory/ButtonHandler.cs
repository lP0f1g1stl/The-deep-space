using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private Button _show;
    [SerializeField] private Button _hide;
    [Space]
    [SerializeField] private GameObject _uIObject;

    private void OnEnable()
    {
        _show.onClick.AddListener(Show);
        _hide.onClick.AddListener(Hide);
    }
    private void OnDisable()
    {
        _show.onClick.RemoveListener(Show);
        _hide.onClick.RemoveListener(Hide);
    }
    private void Show() 
    {
        _uIObject.SetActive(true);
    }
    private void Hide() 
    {
        _uIObject.SetActive(false);
    }

}
