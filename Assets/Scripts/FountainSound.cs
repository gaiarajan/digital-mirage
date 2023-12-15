using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainSound : MonoBehaviour
{
    // FMOD Event Info
    private FMOD.Studio.EventInstance fountainInstance;
    public FMODUnity.EventReference fmodEventFountain;
    
    // Occlusion Variables
    [SerializeField] 
    private bool occlusionEnabled = false;

    [SerializeField] 
    private string occlusionParameterName = null;

    [Range(0.0f, 10.0f)] [SerializeField] 
    private float occlusionIntensity = 1f;

    private float currentOcclusion = 0.0f;
    private float nextOcclusionUpdate = 0.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        fountainInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEventFountain);
        fountainInstance.start();
    }
    
    // Update is called once per frame
    void Update() 
    {
        if (fountainInstance.isValid()) 
        {
            fountainInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(this.gameObject));
            if (!occlusionEnabled) 
            {
                currentOcclusion = 0.0f;
            } 
            else if (Time.time >= nextOcclusionUpdate) 
            {
                nextOcclusionUpdate = Time.time + FMODUnityResonance.FmodResonanceAudio.occlusionDetectionInterval;
                currentOcclusion = occlusionIntensity * FMODUnityResonance.FmodResonanceAudio.ComputeOcclusion(transform);
                fountainInstance.setParameterByName(occlusionParameterName, currentOcclusion);
            }
        }
    }   
 
}
