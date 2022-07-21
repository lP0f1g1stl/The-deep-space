using UnityEngine;

public class EngineHolder : MonoBehaviour
{
    [SerializeField] private Transform _engine;

    public void ChangeAnimationPosition(Vector3 animationPosition) 
    {
        _engine.localPosition = animationPosition;
    }
}
