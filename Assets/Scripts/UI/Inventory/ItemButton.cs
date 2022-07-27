using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _amount;
    [SerializeField] private TextMeshProUGUI _weight;
    [SerializeField] private TextMeshProUGUI _price;
    [Space]
    [SerializeField] private Button _button;

    public Button Button => _button;

    public void Init(Sprite image, string name, string description, string amount, string weight, string price) 
    {
        _image.sprite = image;
        _name.text = name;
        _description.text = description;
        _amount.text = amount;
        _weight.text = weight;
        _price.text = price;
    }
    public void SetAmount(string amount) 
    {
        _amount.text = amount;
    }
}
