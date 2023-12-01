using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(VisualEffect))]
public class Firework : MonoBehaviour
{
    private VisualEffect vfx;

    [SerializeField] private float timeToPop;
    [SerializeField] private float popDuration;

    public AudioSource launchSoundObject;
    public AudioSource explodeSoundObject;
    
    /*[SerializeField] private Color leadParticleColor;
    [SerializeField] private Color trailColorStart;
    [SerializeField] private Color trailColorEnd;
    [SerializeField] private Color popColorStart;
    [SerializeField] private Color popColorEnd;*/

    private void Start()
    {
        vfx = this.GetComponent<VisualEffect>();
        InitFirework();
    }

    void InitFirework()
    {
        vfx.SetFloat("timeToPop", timeToPop);
        vfx.SetFloat("popDuration", popDuration);
        
        
        /*(vfx.SetVector4("leadColor", leadParticleColor);

        Gradient g = vfx.GetGradient("trailColor");

        g.colorKeys[0].color = trailColorStart;
        g.colorKeys[1].color = trailColorStart;
        
        vfx.SetGradient("trailColor", g);
        
        g = vfx.GetGradient("popColor");
        
        g.colorKeys[0].color = popColorStart;
        g.colorKeys[1].color = popColorStart;
        
        vfx.SetGradient("popColor", g);*/
    }

    [ContextMenu("Start the fire")]
    void LaunchFirework()
    {
        vfx.Play();
        launchSoundObject.Play();
        StartCoroutine(WaitToPop());
    }

    IEnumerator WaitToPop()
    {
        yield return new WaitForSeconds(timeToPop);
        launchSoundObject.Stop();
        explodeSoundObject.Play();

        StartCoroutine(WaitTillEnd());
    }

    IEnumerator WaitTillEnd()
    {
        yield return new WaitForSeconds(popDuration);
        explodeSoundObject.Stop();
    }
    
}
