using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMOD.Studio;
using FMODUnity;
public class SoundManager : MonoBehaviour
{
    // Game Objects
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;
    
    
    // Event Instances
    private FMOD.Studio.EventInstance object1Instance;
    private FMOD.Studio.EventInstance object2Instance;
    private FMOD.Studio.EventInstance object3Instance;
    private FMOD.Studio.EventInstance object4Instance;
    private FMOD.Studio.EventInstance object5Instance;
    
    // Start is called before the first frame update
    void Start()
    {
        object1Instance = SoundStart(object1, "event:/Guitar");
        object2Instance = SoundStart(object2, "event:/Guitar");
        object3Instance = SoundStart(object3, "event:/Guitar");
        object4Instance = SoundStart(object4, "event:/Guitar");
        object5Instance = SoundStart(object5, "event:/Guitar");
        
    }
    
    // Update is called once per frame
    void Update() 
    {
        
    }

    public FMOD.Studio.EventInstance SoundStart(GameObject obj, string path)
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