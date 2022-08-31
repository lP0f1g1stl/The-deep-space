using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesHolder : MonoBehaviour
{
    public static Transform _projectilesHolder;

    private void Awake()
    {
        _projectilesHolder = transform;
    }
}
