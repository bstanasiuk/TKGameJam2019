using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLegs : MonoBehaviour
{
    [SerializeField] private LegLine _leftLegLine;
    [SerializeField] private LegLine _rightLegLine;

    [SerializeField] private Transform _playerTorso;
    [SerializeField] private Transform _playerLeftLeg;
    [SerializeField] private Transform _playerRightLeg;

    private void Start()
    {
/*        var torsoPosition = Vector3.Lerp(_leftLegLine.LineVisualizer.Keys[0].transform.position, _rightLegLine.LineVisualizer.Keys[0].transform.position, 0.5f);
       _playerTorso.transform.position = new Vector3(torsoPosition.x, _playerTorso.transform.position.y, torsoPosition.z);
        var leftLegPosition = _leftLegLine.LineVisualizer.Keys[0].transform.position;
        _playerLeftLeg.transform.position = leftLegPosition;
        var rightLegPosition = _rightLegLine.LineVisualizer.Keys[0].transform.position;
        _playerRightLeg.transform.position = rightLegPosition;*/
    }

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
