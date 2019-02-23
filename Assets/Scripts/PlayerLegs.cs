using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLegs : MonoBehaviour
{
    [SerializeField] private LegLine _leftLegLine;
    [SerializeField] private LegLine _rightLegLine;
    
    private void Update()
    {
        CheckLegAlignment();
    }

    private void CheckLegAlignment()
    {
        var legRange = _rightLegLine.SelectedKeyIndex - _leftLegLine.SelectedKeyIndex;
        if (legRange >= -2 && legRange <= 1)
        {
            print("OK");
        }
    }
}
