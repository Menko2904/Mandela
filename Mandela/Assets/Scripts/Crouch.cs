using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 local = transform.localScale;
      
      if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3 (1.2f, 1f, 1.2f);
        }    
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3 (1.2f, 1.8f, 1.2f);
            transform.localPosition = new Vector3 (0f, 1.8f, 0f);
        } 

    }
}
