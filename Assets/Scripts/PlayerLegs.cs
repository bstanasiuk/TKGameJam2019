﻿using System.Collections;
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
    [SerializeField] private Vector3 _playerRightLegFootStartingPosition;
    [SerializeField] private Vector3 _playerLeftLegFootStartingPosition;
    [SerializeField] private GameObject shockwave;


    private Vector3 leftLegTargetPosition;
    private Vector3 rightLegTargetPosition;
    private float velocity;
    private float oldVelocity;
    private Vector3 oldDebugPos;
    private Vector3 followingPos;

    private bool needToStop; 

    private int frameCounter = 0;

    private bool playerReady;
    private bool playParticle;
    private bool particlePlayed;

    void Start()
    {
        followingPos = (_playerRightLegFootPosition.position + _playerLeftLegFootPosition.position) * 0.5f;
        followingPos.y = _torsoheight;
        followingPos.z = -2.412662f;

        EventManager.Instance.PlayerDead.AddListener(OnPlayerDead);
        EventManager.Instance.PlayerReady.AddListener(OnPlayerReady);
        EventManager.Instance.PlayerUnready.AddListener(OnPlayerReady);
    }

    private void FixedUpdate()
    {
        if(playerReady)
        {
            MoveLegs();
            if(playParticle && !particlePlayed)
            {
                playParticle = false;
                particlePlayed = true;
                shockwave.transform.position = _playerLeftLegFootPosition.transform.position;
                shockwave.GetComponent<ParticleSystem>().Play();
            }
        }
        else
        {
            _playerLeftLegFootPosition.position = _playerLeftLegFootStartingPosition;
            _playerRightLegFootPosition.position = _playerRightLegFootStartingPosition;
        }
    }

    private void MoveLegs()
    {
        MoveLeftLeg();
        MoveRightLeg();
        MoveTorso();

        Vector3 debugPos = (leftLegTargetPosition + rightLegTargetPosition) * 0.5f;
        
        debugPos.y = _torsoheight;
        debugPos.z = -2.412662f;
        if(frameCounter == 0)
        {
            followingPos = debugPos;
        }
        frameCounter++;
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

        followingPos = Vector3.Lerp(followingPos, debugPos, _forceTargetSpeed * Time.fixedUnscaledDeltaTime);

        if(debugSphere2 != null)
        {
            debugSphere2.transform.position = followingPos;   
        }

        velocity -= Mathf.Sign(velocity) * 2.0f * Time.fixedUnscaledDeltaTime;
        //if(playerReady)
        {
            if(Mathf.Abs(velocity) > attackTreshold)
            {
                _playerTorso.AddForceAtPosition((followingPos - debugPos) * attackForce * 0.1f, neckTransform.position);
            }
            else if(Mathf.Abs(velocity) < attackTreshold && !(Mathf.Abs(oldVelocity) >= attackTreshold))
            {
                //Debug.Log(velocity + " " + oldVelocity + "  " + debugPos + " "  + followingPos + " " + (oldDebugPos - followingPos).magnitude);
                _playerTorso.AddForce((debugPos - followingPos) * attackForce);
            }
        }

        oldDebugPos = debugPos;
        oldVelocity = velocity;
    }

    private void MoveLeftLeg()
    {
        Vector3 forcePosition = Vector3.zero;
        Vector3 forceDirection = Vector3.zero;
        if (_leftLegLine.SelectedKeyIndex.HasValue)
        {
            leftLegTargetPosition = _leftLegLine.LineVisualizer.Keys[_leftLegLine.SelectedKeyIndex.Value].transform.GetChild(1).position;
            leftLegTargetPosition = new Vector3(leftLegTargetPosition.x, 0.0f, leftLegTargetPosition.z);
            forcePosition = _playerLeftLegFootPosition.position;
            forceDirection = Vector3.ClampMagnitude((leftLegTargetPosition - _playerLeftLeg.position), 100.0f);
            //_playerLeftLeg.AddForceAtPosition(forceDirection * _legForceMultiplier, forcePosition);
            //_playerLeftLeg.transform.position = leftLegTargetPosition - (-_playerLeftLeg.transform.position + _playerLeftLegFootPosition.position);
        }
        else if (_rightLegLine.SelectedKeyIndex.HasValue)
        {
            //leftLegTargetPosition = _rightLegLine.LineVisualizer.Keys[_rightLegLine.SelectedKeyIndex.Value].transform.GetChild(1).position;
            //leftLegTargetPosition = new Vector3(leftLegTargetPosition.x, 0.6f, _playerLeftLeg.transform.position.z);
            forcePosition = _playerLeftLegFootPosition.position;
            forceDirection = Vector3.ClampMagnitude((leftLegTargetPosition - _playerLeftLeg.position), 100.0f);
            //_playerLeftLeg.AddForceAtPosition(forceDirection * _legForceMultiplier, forcePosition);
            //_playerLeftLeg.transform.position = leftLegTargetPosition - (-_playerLeftLeg.transform.position + _playerLeftLegFootPosition.position);
        }

        //if(!playerReady)
        //{
            //leftLegTargetPosition = new Vector3(leftLegTargetPosition.x, 5.0f, leftLegTargetPosition.z);
        //}
        _playerLeftLegFootPosition.transform.position =  leftLegTargetPosition;

        //_playerLeftLeg.AddForceAtPosition(forceDirection * _legForceMultiplier, forcePosition);
        //_playerLeftLeg.AddForceAtPosition(forceDirection / Time.fixedDeltaTime, forcePosition);//, ForceMode.Impulse);
    }

    private void MoveRightLeg()
    {
        Vector3 forcePosition = Vector3.zero;
        Vector3 forceDirection = Vector3.zero;
        if (_rightLegLine.SelectedKeyIndex.HasValue)
        {
            rightLegTargetPosition = _rightLegLine.LineVisualizer.Keys[_rightLegLine.SelectedKeyIndex.Value].transform.GetChild(1).position;
            rightLegTargetPosition = new Vector3(rightLegTargetPosition.x, 0.0f, rightLegTargetPosition.z);
            forcePosition = _playerRightLegFootPosition.position;
            forceDirection = Vector3.ClampMagnitude(rightLegTargetPosition - _playerRightLeg.position, 100.0f);
            //_playerRightLeg.AddForceAtPosition(forceDirection * _legForceMultiplier, forcePosition);
            //_playerRightLeg.transform.position = rightLegTargetPosition - (-_playerRightLeg.transform.position + _playerRightLegFootPosition.position);
        }
        else if (_leftLegLine.SelectedKeyIndex.HasValue)
        {
            //rightLegTargetPosition = _leftLegLine.LineVisualizer.Keys[_leftLegLine.SelectedKeyIndex.Value].transform.GetChild(1).position;
            //rightLegTargetPosition = new Vector3(rightLegTargetPosition.x, 0.6f, _playerRightLeg.transform.position.z);
            forcePosition = _playerRightLegFootPosition.position;
            forceDirection = Vector3.ClampMagnitude(rightLegTargetPosition - _playerRightLeg.position, 100.0f);
            //_playerRightLeg.AddForceAtPosition(forceDirection * _legForceMultiplier, forcePosition);
            //_playerRightLeg.transform.position = rightLegTargetPosition - (-_playerRightLeg.transform.position + _playerRightLegFootPosition.position);
        }

        //if(!playerReady)
        //{
            //rightLegTargetPosition += new Vector3(rightLegTargetPosition.x, 5.0f, rightLegTargetPosition.z);
        //}

        _playerRightLegFootPosition.transform.position = rightLegTargetPosition;

        //_playerRightLeg.AddForceAtPosition(forceDirection * _legForceMultiplier, forcePosition);
        //_playerRightLeg.AddForceAtPosition(forceDirection / Time.fixedDeltaTime, forcePosition);//, ForceMode.Impulse);
    }

    private void MoveTorso()
    {
        //if(playerReady)
        {
            if (_leftLegLine.SelectedKeyIndex.HasValue || _rightLegLine.SelectedKeyIndex.HasValue)
            {
                _playerTorso.AddForceAtPosition((new Vector3(0, _torsoheight - _playerTorso.position.y, 0)) * _torsoForceMultiplier, neckTransform.position);
                needToStop = true;
            }
            else
            {
                _playerTorso.AddForceAtPosition((new Vector3(0, _playerTorso.position.y - _torsoheight, 0)) * _torsoForceMultiplier * 10.0f, neckTransform.position);
                if(needToStop)
                {
                    //_playerTorso.velocity = new Vector3(0, _playerTorso.velocity.y, 0);
                    needToStop = false;
                }
            }
        }
    }

    private void OnPlayerDead(PlayerDeadStruct pos)
    {
        this.enabled = false;
    }

    private void CheckLegAlignment()
    {
        var legRange = _rightLegLine.SelectedKeyIndex - _leftLegLine.SelectedKeyIndex;
        if (legRange >= -2 && legRange <= 1)
        {
            print("OK");
        }
    }

    void OnPlayerReady(int number)
    {
        if(gameObject.layer - 9 == number)
        {
            playerReady = true;
            playParticle = true;
        }
    }

    void OnPlayerUnready(int number)
    {
        if(gameObject.layer - 9 == number)
            playerReady = false;
    }
}
