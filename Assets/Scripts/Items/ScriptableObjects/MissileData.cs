using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemData/CreateNewMissile", fileName = "NewMissile")]
public class MissileData : ItemBaseData
{
    [Space]
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private int damage;
    //[Space]
    //[SerializeField] private
}
