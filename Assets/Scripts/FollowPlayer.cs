using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position = new Vector3(transform.position.x, player.position.y + 2.5f, -10);
    }
}
