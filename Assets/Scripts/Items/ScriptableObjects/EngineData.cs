using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemData/CreateNewEngine", fileName = "NewEngine")]
public class EngineData : ItemBaseData
{
    [Space]
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
}
