using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        
        if (pos.y < 0)
        {
            Destroy(this.gameObject);
            Debug.Log("—Ž‰º‚µ‚½");
        }
    }
}
