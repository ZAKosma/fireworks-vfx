using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX.Utility;
using UnityEngine.VFX;

[ExecuteAlways]
[RequireComponent(typeof(VisualEffect))]
public class FireworkAudioHandler :  VFXOutputEventAbstractHandler
{
    public override bool canExecuteInEditor => true;

    public AudioSource audioSource;
    
    public override void OnVFXOutputEvent(VFXEventAttribute eventAttribute)
    {
        if (audioSource != null)
            audioSource.Play();
    }
}