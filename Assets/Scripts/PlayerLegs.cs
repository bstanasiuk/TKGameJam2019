using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLegs : MonoBehaviour
{
    [SerializeField] private LegLine _leftLegLine;
    [SerializeField] private LegLine _rightLegLine;

    [SerializeField] private Rigidbody _playerLeftLeg;
    [SerializeField] private Transform _playerLeftLegFootPosition;
    [SerializeField] private Rigidbody _playerRightLeg;
    [SerializeField] private Transform _playerRightLegFootPosition;
    [SerializeField] private Rigidbody _playerTorso;

    [SerializeField] private float _legForceMultiplier = 10f;
    [SerializeField] private float _torsoForceMultiplier = 10f;
     [SerializeField] private float _torsoheight = 4f;

    private Vector3 leftLegTargetPosition;
    private Vector3 rightLegTargetPosition;


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
        MoveTorso();
    }

    private void MoveLeftLeg()
    {
        if (_leftLegLine.SelectedKeyIndex.HasValue)
        {
            leftLegTargetPosition = _leftLegLine.LineVisualizer.Keys[_leftLegLine.SelectedKeyIndex.Value].transform.position;
            leftLegTargetPosition = new Vector3(leftLegTargetPosition.x, 0.3f, leftLegTargetPosition.z);
            var forcePosition = _playerLeftLegFootPosition.position;
            _playerLeftLeg.AddForceAtPosition((leftLegTargetPosition - _playerLeftLeg.position) * _legForceMultiplier, forcePosition);

        }
        else if (_rightLegLine.SelectedKeyIndex.HasValue)
        {
            leftLegTargetPosition = _rightLegLine.LineVisualizer.Keys[_rightLegLine.SelectedKeyIndex.Value].transform.position;
            leftLegTargetPosition = new Vector3(leftLegTargetPosition.x, 0.6f, _playerLeftLeg.transform.position.z);
            var forcePosition = _playerLeftLegFootPosition.position;
            _playerLeftLeg.AddForceAtPosition((leftLegTargetPosition - _playerLeftLeg.position) * _legForceMultiplier, forcePosition);
        }
    }

    private void MoveRightLeg()
    {
        if (_rightLegLine.SelectedKeyIndex.HasValue)
        {
            rightLegTargetPosition = _rightLegLine.LineVisualizer.Keys[_rightLegLine.SelectedKeyIndex.Value].transform.position;
            rightLegTargetPosition = new Vector3(rightLegTargetPosition.x, 0.3f, rightLegTargetPosition.z);
            var forcePosition = _playerRightLegFootPosition.position;
            _playerRightLeg.AddForceAtPosition((rightLegTargetPosition - _playerRightLeg.position) * _legForceMultiplier, forcePosition);
        }
        else if (_leftLegLine.SelectedKeyIndex.HasValue)
        {
            rightLegTargetPosition = _leftLegLine.LineVisualizer.Keys[_leftLegLine.SelectedKeyIndex.Value].transform.position;
            rightLegTargetPosition = new Vector3(rightLegTargetPosition.x, 0.6f, _playerRightLeg.transform.position.z);
            _playerRightLeg.AddForce((rightLegTargetPosition - _playerRightLeg.position) * _legForceMultiplier);
        }
    }

    private void MoveTorso()
    {
        if (_leftLegLine.SelectedKeyIndex.HasValue && _rightLegLine.SelectedKeyIndex.HasValue)
        {
            _playerTorso.AddForce((new Vector3(0, _torsoheight - _playerTorso.position.y, 0)) * _torsoForceMultiplier);
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
