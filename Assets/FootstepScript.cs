using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FootstepScript : MonoBehaviour
{
    public GameObject camera;
    public GameObject footstepLocation;
    public float timeBetweenSteps = 1f;
    public float distanceTrigger = 100f;
    public float raycastMaxDistance = 2f;
    
    //FMOD Event Stuff
    private string EventPath = "event:/Walking";
    private int MaterialType;

    private RaycastHit rh;
    private bool footstepCoroutineCheck;

    private Vector3 previousPosition;
    
    
    // Start is called before the first frame update
    void Start()
    {
        camera.transform.position = previousPosition;

        footstepCoroutineCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPostion = camera.transform.position;
        
        if ((Math.Abs(currentPostion.magnitude - previousPosition.magnitude) >= distanceTrigger) && (footstepCoroutineCheck == false))
        {
            StartCoroutine(PlayFootstep());
        }
        else
        {
            StopCoroutine(PlayFootstep());
        }

        previousPosition = currentPostion;
    }

    IEnumerator PlayFootstep()
    {
        footstepCoroutineCheck = true;

        MaterialCheck();
        EventInstance Walk = RuntimeManager.CreateInstance(EventPath);
        RuntimeManager.AttachInstanceToGameObject(Walk, footstepLocation.transform);

        Walk.setParameterByName("SurfaceMaterial", MaterialType);

        Walk.start();
        Walk.release();
        
        //Debug.Log("Footstep Triggered");
        
        yield return new WaitForSeconds(timeBetweenSteps);

        footstepCoroutineCheck = false;
    }

   private void MaterialCheck()
    {
        if (Physics.Raycast(camera.transform.position, Vector3.down, out rh, raycastMaxDistance))
        {
            switch (rh.collider.tag)
            {
                case "Wood":
                    MaterialType = 0;
                    break;
                case "Grass":
                    MaterialType = 1;
                    break;
                case "Water":
                    MaterialType = 2;
                    break;
                case "Concrete":
                    MaterialType = 3;
                    break;
                case "Stone":
                    MaterialType = 4;
                    break;
            }
            //Debug.Log(rh.collider.tag);
        }

        //Debug.Log("MaterialType = " + MaterialType);
    }
}
