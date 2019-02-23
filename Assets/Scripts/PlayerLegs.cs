using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLegs : MonoBehaviour
{
    [SerializeField] private LegLine _leftLegLine;
    [SerializeField] private LegLine _rightLegLine;

    [SerializeField] private Rigidbody _playerLeftLeg;
    [SerializeField] private Rigidbody _playerRightLeg;

    [SerializeField] private float _legForceMultiplier = 10f;


    private void Update()
    {
        CheckLegAlignment();
    }

    private void FixedUpdate()
    {
        MoveLegs();
    }

    private void MoveLegs()
    {
        MoveLeftLeg();
        MoveRightLeg();
    }

    private void MoveLeftLeg()
    {
        if (_leftLegLine.SelectedKeyIndex.HasValue)
        {
            var leftLegTargetPosition = _leftLegLine.LineVisualizer.Keys[_leftLegLine.SelectedKeyIndex.Value].transform.position;
            leftLegTargetPosition = new Vector3(leftLegTargetPosition.x, 0.3f, leftLegTargetPosition.z);
            // _playerLeftLeg.AddForce((leftLegTargetPosition - _playerLeftLeg.position) * _legForceMultiplier);
            var forcePosition = _playerLeftLeg.position - new Vector3(0, - 1f, 0);
            _playerLeftLeg.AddForceAtPosition((leftLegTargetPosition - _playerLeftLeg.position) * _legForceMultiplier, forcePosition);
        }
        else if (_rightLegLine.SelectedKeyIndex.HasValue)
        {
            var leftLegTargetPosition = _rightLegLine.LineVisualizer.Keys[_rightLegLine.SelectedKeyIndex.Value].transform.position;
            leftLegTargetPosition = new Vector3(leftLegTargetPosition.x, 0.6f, _playerLeftLeg.transform.position.z);
            _playerLeftLeg.AddForce((leftLegTargetPosition - _playerLeftLeg.position) * _legForceMultiplier);
        }
    }

    private void MoveRightLeg()
    {
        if (_rightLegLine.SelectedKeyIndex.HasValue)
        {
            var rightLegTargetPosition = _rightLegLine.LineVisualizer.Keys[_rightLegLine.SelectedKeyIndex.Value].transform.position;
            rightLegTargetPosition = new Vector3(rightLegTargetPosition.x, 0.3f, rightLegTargetPosition.z);
            var forcePosition = _playerLeftLeg.position - new Vector3(0, -1f, 0);
            //_playerRightLeg.AddForce((rightLegTargetPosition - _playerRightLeg.position) * _legForceMultiplier);
            _playerRightLeg.AddForceAtPosition((rightLegTargetPosition - _playerRightLeg.position) * _legForceMultiplier, forcePosition);
        }
        else if (_leftLegLine.SelectedKeyIndex.HasValue)
        {
            var rightLegTargetPosition = _leftLegLine.LineVisualizer.Keys[_leftLegLine.SelectedKeyIndex.Value].transform.position;
            rightLegTargetPosition = new Vector3(rightLegTargetPosition.x, 0.6f, _playerRightLeg.transform.position.z);
            _playerRightLeg.AddForce((rightLegTargetPosition - _playerRightLeg.position) * _legForceMultiplier);
        }
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
