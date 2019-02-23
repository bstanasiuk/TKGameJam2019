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
    [SerializeField]
    private Material _eligibleKeyMaterial;

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

    public void ShowEligibleFrame(int keyIndex)
    {
        Keys[keyIndex].GetComponent<MeshRenderer>().material = _eligibleKeyMaterial;
    }
}
