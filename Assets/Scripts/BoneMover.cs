using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneMover : MonoBehaviour
{
    [SerializeField]
    private TransformTransition [] changes;

    void FixedUpdate()
    {
        for(int i = 0; i < changes.Length; i++)
        {
            if(changes[i].positionChange)
            {
                changes[i].boneTransform.position = changes[i].positionsTransform.position + changes[i].positionOffset;
            }
            if(changes[i].rotationChange)
            {
                changes[i].boneTransform.rotation = changes[i].positionsTransform.rotation;
                changes[i].boneTransform.Rotate(changes[i].rotationOffset);
            }
        }
    }
}

[System.Serializable]
public struct TransformTransition
{
    public Transform boneTransform;
    public Transform positionsTransform;
    public bool positionChange;
    public Vector3 positionOffset;
    public bool rotationChange;
    public Vector3 rotationOffset;
}
