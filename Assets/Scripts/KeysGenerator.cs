using System.Collections.Generic;
using UnityEngine;

public class KeysGenerator : MonoBehaviour
{
   // TO DO refaktor skryptu na 4 rowy dla każdej nogi
    private readonly List<KeyCode> _firstPlayerLeftLegKeys = new List<KeyCode>
    {
        KeyCode.Q,
        KeyCode.W,
        KeyCode.E,
        KeyCode.R,
        KeyCode.T,
        KeyCode.Y,
        KeyCode.U,
        KeyCode.I,
        KeyCode.O,
        KeyCode.P
    };

    private readonly List<MeshRenderer> _firstPlayerLeftLegKeysQuads = new List<MeshRenderer>();

    private readonly List<MeshRenderer> _firstPlayerRightLegKeysQuads = new List<MeshRenderer>();
    private readonly List<MeshRenderer> _secondPlayerLeftLegKeysQuads = new List<MeshRenderer>();
    private readonly List<MeshRenderer> _secondPlayerRightLegKeysQuads = new List<MeshRenderer>();

    private List<KeyCode> _firstPlayerRightLegKeys = new List<KeyCode>
    {
        KeyCode.Z,
        KeyCode.X,
        KeyCode.C,
        KeyCode.V,
        KeyCode.B,
        KeyCode.N,
        KeyCode.M,
        KeyCode.Comma,
        KeyCode.Period,
        KeyCode.Slash
    };

    [SerializeField] private GameObject _keyPrefab;

    private void Awake()
    {
        SpawnKeys();
    }

    private void Update()
    {
        for (var i = 0; i < _firstPlayerLeftLegKeys.Count; i++)
            if (Input.GetKey(_firstPlayerLeftLegKeys[i]))
                _firstPlayerLeftLegKeysQuads[i].material.color = Color.black;
            else
                _firstPlayerLeftLegKeysQuads[i].material.color = Color.white;
        for (var i = 0; i < _firstPlayerRightLegKeys.Count; i++)
            if (Input.GetKey(_firstPlayerRightLegKeys[i]))
                _firstPlayerRightLegKeysQuads[i].material.color = Color.black;
            else
                _firstPlayerRightLegKeysQuads[i].material.color = Color.white;

    }

    private void SpawnKeys()
    {
        var xOffset = 1.2f;
        for (var i = 0; i < _firstPlayerLeftLegKeys.Count; i++)
        {
            _firstPlayerLeftLegKeysQuads.Add(
                Instantiate(_keyPrefab, new Vector3(i * xOffset, 0, 0), _keyPrefab.transform.rotation, transform)
                    .GetComponent<MeshRenderer>());
            _secondPlayerLeftLegKeysQuads.Add(Instantiate(_keyPrefab, new Vector3(0.25f + i * xOffset, 0, -1.2f),
                _keyPrefab.transform.rotation, transform).GetComponent<MeshRenderer>());
            _firstPlayerRightLegKeysQuads.Add(Instantiate(_keyPrefab, new Vector3(0.5f + i * xOffset, 0, -2.4f),
                _keyPrefab.transform.rotation, transform).GetComponent<MeshRenderer>());
            _secondPlayerRightLegKeysQuads.Add(Instantiate(_keyPrefab, new Vector3(0.75f + i * xOffset, 0, -3.6f),
                _keyPrefab.transform.rotation, transform).GetComponent<MeshRenderer>());
        }
    }
}