﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MarioThrowingCap : MonoBehaviour
{
    [Header("Public References")]
    public ParticleSystem CapEffect;
    public Transform Cap;
    public Transform Mario;
    [Space]
    [Header("Game Settings")]
    public float CapSpinningSpeed;
    public float spinningDuration;
    public float throwDuration;
    public float ReturnDuration;
    [Space]
    [Header("Public bools")]
    public bool Spinning;

    void Update()
    {
        if ( Input.GetButtonDown("Fire1")) // mouse button
        {

            ThrowingCap();
            CapEffect.Play();
            Spinning = true;
        }

        if ( Input.GetButtonDown("Fire2") && Spinning ) // option button
        { 

            ReturnCap();
        }

        if(Spinning){

            Cap.transform.Rotate (0f,CapSpinningSpeed,0f);
        }
    }

    void ThrowingCap(){

        Sequence throwSequence = DOTween.Sequence();

        //Throw the Cap
        throwSequence.Append(Cap.DOMove(transform.position + transform.forward * 5, throwDuration));

        //Scale Cap
        throwSequence.Join(Cap.DOScale(1.1f, throwDuration));

        //Mario Spinning
        throwSequence.Join(Mario.DORotate(new Vector3(0, 360f, 0), spinningDuration, RotateMode.FastBeyond360));

    }

    void ReturnCap(){

        Sequence ReturnSequence = DOTween.Sequence();

        //Return the Cap
        ReturnSequence.Append(Cap.DOMove(transform.position, ReturnDuration));

        //Cap original Scale
        ReturnSequence.Join(Cap.DOScale(0.65f, ReturnDuration));

        //Cap original Rotation
        Invoke("OriginalRotation", ReturnDuration);

    }

    void OriginalRotation(){

        CapEffect.Stop();
        Spinning = false;
        Cap.DORotate(new Vector3(24f, 0f, 10f), 0f);
    }

}