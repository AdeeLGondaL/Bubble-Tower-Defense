using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            //Debug.Log($"{hit.transform.name},{hit.transform.position}");
            Debug.DrawRay(transform.position, transform.forward * 100f, Color.green);
        }
    }
}
