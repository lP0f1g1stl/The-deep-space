using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform _playerShip;
    [SerializeField] private Renderer _bgRend;

    private Vector3 offset;

    void Start()
    {
        if (_playerShip != null)
        {
            offset = transform.position - _playerShip.position;
        }
    }

    void LateUpdate()
    {
        transform.position = _playerShip.position + offset;
        _bgRend.material.mainTextureOffset = _playerShip.position/50;
    }

    public void SetNewShip(Transform ship) 
    {
        _playerShip = ship;
        transform.position = new Vector3(_playerShip.position.x, _playerShip.position.y, -10);
        offset = transform.position - _playerShip.position;
    }
}
