using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        offset.y = transform.position.y - player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        transform.position = (new Vector3(transform.position.x, player.transform.position.y + offset.y, transform.position.z));
    }
}
