using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMOD.Studio;
using FMODUnity;
public class SoundManager : MonoBehaviour
{
    // Game Objects
    public GameObject fountain;
    public GameObject guitar;
    
    
    // Event Instances
    private FMOD.Studio.EventInstance fountainInstance;
    private FMOD.Studio.EventInstance guitarInstance;
    
    // Start is called before the first frame update
    void Start()
    {
        fountainInstance = AmbientStart(fountain, "event:/Fountain");
        guitarInstance = AmbientStart(guitar, "event:/Guitar");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
    public FMOD.Studio.EventInstance AmbientStart(GameObject obj, string path)
    {
        if (obj != null)
        {
            Transform objTransform = obj.transform;
            FMOD.Studio.EventInstance eventInstance = FMODUnity.RuntimeManager.CreateInstance(path);
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(eventInstance, objTransform);
            eventInstance.start();
            return eventInstance;
        }
        return new EventInstance();
    }
    
}
