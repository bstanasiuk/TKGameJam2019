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
    [SerializeField] private Transform neckTransform;

    [SerializeField] private float _legForceMultiplier = 10f;
    [SerializeField] private float _torsoForceMultiplier = 10f;
    [SerializeField] private float _torsoheight = 4f;
    [SerializeField] private float _forceTargetSpeed = 0.7f;
    [SerializeField] private GameObject debugSphere;
    [SerializeField] private GameObject debugSphere2;
    [SerializeField] private GameObject debugCube;
    [SerializeField] private float attackTreshold = 0.6f;
    [SerializeField] private float attackForce = 700f;


    private Vector3 leftLegTargetPosition;
    private Vector3 rightLegTargetPosition;
    private float velocity;
    private float oldVelocity;
    private Vector3 oldDebugPos;
    private Vector3 followingPos;

    private int frameCounter = 0;

    void Start()
    {
        followingPos = (_playerRightLegFootPosition.position + _playerLeftLegFootPosition.position) * 0.5f;
        followingPos.y = _torsoheight;
        followingPos.z = -2.412662f;
    }
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

        Vector3 debugPos = (leftLegTargetPosition + rightLegTargetPosition) * 0.5f;
        if(frameCounter == 0)
        {

        }
        frameCounter++;
        debugPos.y = _torsoheight;
        debugPos.z = -2.412662f;
        if(debugSphere != null)
        {
            debugSphere.transform.position = debugPos;
        }

        if(oldDebugPos != debugPos)
        {
            velocity += debugPos.x - oldDebugPos.x;
        }

        if(debugCube != null)
        {
            debugCube.transform.position = debugPos + new Vector3(velocity, 0, 0) * 0.5f;
            debugCube.transform.localScale = new Vector3(velocity, debugCube.transform.localScale.y, debugCube.transform.localScale.z);
        }

        followingPos = Vector3.Lerp(followingPos, debugPos, _forceTargetSpeed * Time.fixedDeltaTime);

        if(debugSphere2 != null)
        {
            debugSphere2.transform.position = followingPos;   
        }

        velocity -= Mathf.Sign(velocity) * 2.0f * Time.fixedDeltaTime;
        if(Mathf.Abs(velocity) > attackTreshold)
        {
            _playerTorso.AddForceAtPosition((followingPos - debugPos) * attackForce * 0.1f, neckTransform.position);
        }
        else if(Mathf.Abs(velocity) < attackTreshold && !(Mathf.Abs(oldVelocity) >= attackTreshold))
        {
            //Debug.Log(velocity + " " + oldVelocity + "  " + debugPos + " "  + followingPos + " " + (oldDebugPos - followingPos).magnitude);
            _playerTorso.AddForce((debugPos - followingPos) * attackForce);
        }

        oldDebugPos = debugPos;
        oldVelocity = velocity;
    }

    private void MoveLeftLeg()
    {
        if (_leftLegLine.SelectedKeyIndex.HasValue)
        {
            leftLegTargetPosition = _leftLegLine.LineVisualizer.Keys[_leftLegLine.SelectedKeyIndex.Value].transform.GetChild(1).position;
            leftLegTargetPosition = new Vector3(leftLegTargetPosition.x, 0.3f, leftLegTargetPosition.z);
            var forcePosition = _playerLeftLegFootPosition.position;
            _playerLeftLeg.AddForceAtPosition((leftLegTargetPosition - _playerLeftLeg.position) * _legForceMultiplier, forcePosition);

        }
        else if (_rightLegLine.SelectedKeyIndex.HasValue)
        {
            leftLegTargetPosition = _rightLegLine.LineVisualizer.Keys[_rightLegLine.SelectedKeyIndex.Value].transform.GetChild(1).position;
            leftLegTargetPosition = new Vector3(leftLegTargetPosition.x, 0.6f, _playerLeftLeg.transform.position.z);
            var forcePosition = _playerLeftLegFootPosition.position;
            _playerLeftLeg.AddForceAtPosition((leftLegTargetPosition - _playerLeftLeg.position) * _legForceMultiplier, forcePosition);
        }
    }

    private void MoveRightLeg()
    {
        if (_rightLegLine.SelectedKeyIndex.HasValue)
        {
            rightLegTargetPosition = _rightLegLine.LineVisualizer.Keys[_rightLegLine.SelectedKeyIndex.Value].transform.GetChild(1).position;
            rightLegTargetPosition = new Vector3(rightLegTargetPosition.x, 0.3f, rightLegTargetPosition.z);
            var forcePosition = _playerRightLegFootPosition.position;
            _playerRightLeg.AddForceAtPosition((rightLegTargetPosition - _playerRightLeg.position) * _legForceMultiplier, forcePosition);
        }
        else if (_leftLegLine.SelectedKeyIndex.HasValue)
        {
            rightLegTargetPosition = _leftLegLine.LineVisualizer.Keys[_leftLegLine.SelectedKeyIndex.Value].transform.GetChild(1).position;
            rightLegTargetPosition = new Vector3(rightLegTargetPosition.x, 0.6f, _playerRightLeg.transform.position.z);
            _playerRightLeg.AddForce((rightLegTargetPosition - _playerRightLeg.position) * _legForceMultiplier);
        }
    }

    private void MoveTorso()
    {
        if (_leftLegLine.SelectedKeyIndex.HasValue || _rightLegLine.SelectedKeyIndex.HasValue)
        {
            _playerTorso.AddForceAtPosition((new Vector3(0, _torsoheight - _playerTorso.position.y, 0)) * _torsoForceMultiplier, neckTransform.position);
        }
        else
        {
            _playerTorso.AddForceAtPosition((new Vector3(0, _playerTorso.position.y - _torsoheight, 0)) * _torsoForceMultiplier, neckTransform.position);
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
