using UnityEngine;

public class LegLine : MonoBehaviour
{
    [SerializeField] private KeyCode[] _keys;
    private LineVisualizer _lineVisualizer;
    private int? _selectedKeyIndex;

    public KeyCode[] Keys
    {
        get { return _keys; }
    }

    private void Awake()
    {
        _lineVisualizer = GetComponent<LineVisualizer>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (_selectedKeyIndex.HasValue)
        {
            if (!Input.GetKey(Keys[_selectedKeyIndex.Value]))
                _selectedKeyIndex = null;
        }
        else
        {
            for (var i = 0; i < _keys.Length; i++)
                if (Input.GetKey(_keys[i]) && !_selectedKeyIndex.HasValue)
                {
                    _selectedKeyIndex = i;
                    _lineVisualizer.ActivateKey(i);
                }
                else
                {
                    _lineVisualizer.DisableKey(i);
                }
        }
    }
}