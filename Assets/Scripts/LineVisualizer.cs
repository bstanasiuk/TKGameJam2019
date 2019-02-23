using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineVisualizer : MonoBehaviour
{
    [SerializeField] private Transform _keyPrefab;
    [SerializeField] private float spaceOffset;
    [SerializeField] private float xOffset;
    [SerializeField] private float zOffset;

    public List<Transform> Keys { get; } = new List<Transform>();

    private void Awake()
    {
        VisualizeLine();
    }

    private void VisualizeLine()
    {
        for (var i = 0; i < GetComponent<LegLine>().Keys.Length; i++)
        {
            Keys.Add(Instantiate(_keyPrefab, new Vector3(xOffset + i * spaceOffset, 0, zOffset),
                _keyPrefab.transform.rotation, transform));
        }
    }

    public void ActivateKey(int keyIndex)
    {
        Keys[keyIndex].GetComponent<MeshRenderer>().material.color = Color.black;
    }

    public void DisableKey(int keyIndex)
    {
        Keys[keyIndex].GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
