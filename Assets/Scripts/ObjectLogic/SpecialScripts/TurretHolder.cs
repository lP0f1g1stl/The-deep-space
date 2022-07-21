using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHolder : MonoBehaviour
{
    [SerializeField] private Turret _turret;

    public Turret Turret 
    {
        set => _turret = value;
        get => _turret;
    }
}
