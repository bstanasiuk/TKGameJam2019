using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineVisualizerWithMeshKeys : MonoBehaviour
{
    [SerializeField] private Transform[] _keys;

    [SerializeField]
    private Material _disabledKeyMaterial;
    [SerializeField]
    private Material _enabledKeyMaterial;

    public Transform[] Keys
    {
        get { return _keys; }
    }

    public void ActivateKey(int keyIndex)
    {
        Keys[keyIndex].GetComponent<MeshRenderer>().material = _enabledKeyMaterial;
    }

    public void DisableKey(int keyIndex)
    {
        Keys[keyIndex].GetComponent<MeshRenderer>().material = _disabledKeyMaterial;
    }
}
