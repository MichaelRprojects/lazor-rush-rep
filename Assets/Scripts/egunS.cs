using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egunS : MonoBehaviour
{
    [SerializeField] LayerMask grounded;
    bool blockc;
    public static bool blockb = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //blockb = true;
    }
    private void OnTriggerExit(Collider other)
    {
        //blockb = false;
    }

    // Update is called once per frame
    void Update()
    {
        //blockb = false;
        //.25
        //blockc = Physics.CheckSphere(transform.position, .25f, grounded);
        //if (blockc == true)
        //{
            //blockb = true;
        //}
        //if (blockc == false)
        //{
            //blockb = false;
        //}
    }
}
