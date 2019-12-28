using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speedY;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Physics here
    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speedY);   
    }
}
