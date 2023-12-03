using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class SplineMover : MonoBehaviour
{
    public SplineContainer spline;
    public Transform camera;

    private float3 splinePosition;
    private float interpolation;

    private Transform emitterTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        emitterTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //SplineUtility.GetNearestPoint(spline, camera.position, out splinePosition, out interpolation);

        //emitterTransform = splinePosition;
    }
    
}
