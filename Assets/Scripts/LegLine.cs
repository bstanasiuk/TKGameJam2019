using UnityEngine;

public class LegLine : MonoBehaviour
{
    [SerializeField] private KeyCode[] _keys;
    public LineVisualizerWithMeshKeys LineVisualizer { get; private set; }
    public int? SelectedKeyIndex { get; private set; }

    public KeyCode[] Keys
    {
        get { return _keys; }
    }

    private void Awake()
    {
        LineVisualizer = GetComponent<LineVisualizerWithMeshKeys>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (SelectedKeyIndex.HasValue)
        {
            if (!Input.GetKey(Keys[SelectedKeyIndex.Value]))
                SelectedKeyIndex = null;
        }
        else
        {
            for (var i = 0; i < _keys.Length; i++)
                if (Input.GetKey(_keys[i]) && !SelectedKeyIndex.HasValue)
                {
                    SelectedKeyIndex = i;
                    LineVisualizer.ActivateKey(i);
                }
                else
                {
                    LineVisualizer.DisableKey(i);
                }
        }
    }
}