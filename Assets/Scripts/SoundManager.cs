using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMOD.Studio;
using FMODUnity;
public class SoundManager : MonoBehaviour
{

    public GameObject speaker1;
    public GameObject speaker2;
    public GameObject speaker3;
    public GameObject speaker4;
    
    private FMOD.Studio.EventInstance speaker1Instance;
    private FMOD.Studio.EventInstance speaker2Instance;
    private FMOD.Studio.EventInstance speaker3Instance;
    private FMOD.Studio.EventInstance speaker4Instance;
    
    // Start is called before the first frame update
    void Start()
    {
        speaker1Instance = AmbientStart(speaker1, "event:/Starter_Texture");
        //speaker2Instance = AmbientStart(speaker2, "event:/Starter_Texture");
        speaker3Instance = AmbientStart(speaker3, "event:/Starter_Texture");
        //speaker4Instance = AmbientStart(speaker4, "event:/Starter_Texture");
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
