using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(HealthLogic), typeof(ShipController))]
public class Ship : MonoBehaviour
{
    [SerializeField] private ShipController _shipController;
    [SerializeField] private TurretsController _trurretsController;
    [SerializeField] private EngineAnimation _engineAnimation;

    public ShipController ShipController => _shipController;
    public TurretsController TurretsController => _trurretsController;
    public EngineAnimation EngineAnimation => _engineAnimation;

    private void Awake()
    {
        _trurretsController.Init(gameObject.GetComponent<Rigidbody2D>());
    }
}
