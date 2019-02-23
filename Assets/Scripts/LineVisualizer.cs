using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineVisualizer : MonoBehaviour
{
    [SerializeField] private MeshRenderer _keyPrefab;
    [SerializeField] private float spaceOffset;
    [SerializeField] private float xOffset;
    [SerializeField] private float zOffset;

    private readonly List<MeshRenderer> _keys = new List<MeshRenderer>();

    private void Awake()
    {
        VisualizeLine();
    }

    private void VisualizeLine()
    {
        for (var i = 0; i < GetComponent<LegLine>().Keys.Length; i++)
        {
            _keys.Add(Instantiate(_keyPrefab, new Vector3(xOffset + i * spaceOffset, 0, zOffset),
                _keyPrefab.transform.rotation, transform));
        }
    }

    public void ActivateKey(int keyIndex)
    {
        _keys[keyIndex].material.color = Color.black;
    }

    public void DisableKey(int keyIndex)
    {
        _keys[keyIndex].material.color = Color.white;
    }
}
