using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemButtonUI : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _amount;
    [SerializeField] private TextMeshProUGUI _volume;
    [SerializeField] private TextMeshProUGUI _price;
    [Space]
    [SerializeField] private Button _button;

    public Button Button => _button;

    public void Init(Sprite image, string name, string description, string amount, string volume, string price) 
    {
        _image.sprite = image;
        _name.text = name;
        _description.text = description;
        _amount.text = amount;
        _volume.text = volume;
        _price.text = price;
    }
    public void ChangeAmount(string amount) 
    {
        _amount.text = amount;
    }
}
