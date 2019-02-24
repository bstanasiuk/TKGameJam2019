using UnityEngine;

public class LegLine : MonoBehaviour
{
    [SerializeField] private KeyCode[] _keys;

    [SerializeField] private MatchController _matchController;
    [SerializeField] private LegLine _secondLegLine;
    public LineVisualizerWithMeshKeys LineVisualizer { get; private set; }
    public int? SelectedKeyIndex { get; private set; }
    public int LastSelectedKey { get; private set; }

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
        ActivateKeys();
    }

    private void ActivateStartKeys()
    {
        LineVisualizer.ShowEligibleFrame(0);
    }

    private void ActivateKeys()
    {
        for (var i = 0; i < _keys.Length; i++)
        {
            if (IsEligible(i))
                LineVisualizer.ShowEligibleFrame(i);
            if (SelectedKeyIndex.HasValue && SelectedKeyIndex.Value == i)
                LineVisualizer.ActivateKey(i);
        }
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
                if (Input.GetKey(_keys[i]) && !SelectedKeyIndex.HasValue && IsEligible(i))
                {
                    SelectedKeyIndex = i;
                    LastSelectedKey = i;
                }
                else
                {
                    LineVisualizer.DisableKey(i);
                }
        }
    }

    private bool IsEligible(int keyIndex)
    {
        if (!_matchController.Ready && keyIndex > 0 && keyIndex < 3) return false;
        var lowerLastLinesIndex = Mathf.Min(LastSelectedKey, _secondLegLine.LastSelectedKey);
        var higherLastLinesIndex = Mathf.Max(LastSelectedKey, _secondLegLine.LastSelectedKey);
        return keyIndex <= lowerLastLinesIndex + 2 && keyIndex >= higherLastLinesIndex - 2;
    }
}