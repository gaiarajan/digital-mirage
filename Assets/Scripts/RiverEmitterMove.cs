using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverEmitterMove : MonoBehaviour
{
    public GameObject camera;
    public GameObject emitter;
    private Collider meshCollider;
    private Vector3 playerPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        meshCollider = this.gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = camera.transform.position;

        emitter.transform.position = meshCollider.ClosestPoint(playerPosition);
    }
}
