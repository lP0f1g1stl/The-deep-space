using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class ButtonsHandler : MonoBehaviour
{
    [SerializeField] private ButtonEventHandler _shoot;
    [SerializeField] private Button _missile;
    [SerializeField] private ButtonEventHandler _boost;

    public ButtonEventHandler Shoot => _shoot;
    public Button Missile => _missile;
    public ButtonEventHandler Boost => _boost;
}
