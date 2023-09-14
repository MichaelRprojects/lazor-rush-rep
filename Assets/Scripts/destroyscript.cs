using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyscript : MonoBehaviour
{
    public float destroytimenum = 0f; 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, destroytimenum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
