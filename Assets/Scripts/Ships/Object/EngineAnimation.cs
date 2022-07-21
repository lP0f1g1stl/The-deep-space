using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineAnimation : MonoBehaviour
{
    [SerializeField] private EngineHolder[] _engineHolders;
    [Space]
    [SerializeField] private float _jetstreamDeltaPos;

    public void CheckThrustForAnimation(float thrust)
    {
        if (thrust < 0.1f)
        {
            ChangeEngineAnimationPosition(0);
        }
        else if (thrust >= 0.1f && thrust <= 0.5f)
        {
            ChangeEngineAnimationPosition(1);
        }
        else
        {
            ChangeEngineAnimationPosition(2);
        }
    }
    private void ChangeEngineAnimationPosition(int animationPhase)
    {
        Vector3 jetstreamPosition = new Vector3(0, -_jetstreamDeltaPos * animationPhase, 0);
        foreach (EngineHolder engineHolder in _engineHolders)
        {
            engineHolder.ChangeAnimationPosition(jetstreamPosition);
        }
    }
}
