using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(player != null)
        {
            transform.LookAt(player);
        }
    }
}
