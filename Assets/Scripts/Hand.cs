using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    Transform Plm;
    [SerializeField] LayerMask Playerl;
    public float pdeth = 20;
    bool aimt;
    //float zt2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        Plm = GameObject.Find("Player").transform;
        //zt2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 lookVectorh = Plm.transform.position - transform.position;
        //Quaternion rot2 = Quaternion.FromToRotation(this.transform.forward, lookVectorh);
        //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rot2, 10f * Time.deltaTime);

        //Vector3 lookVectorh = Plm.transform.position - transform.position;
        //Quaternion rot2 = Quaternion.FromToRotation(this.transform.forward, lookVectorh);
        //this.transform.localRotation = Quaternion.Lerp(this.transform.rotation, rot2, 10f * Time.deltaTime);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.z, 0, 0);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.y, 0, 0);

        aimt = Physics.CheckSphere(transform.position, pdeth, Playerl);
        if (aimt == true)
        {
            this.transform.LookAt(Plm);
        }

        //this.transform.LookAt(loo);
    }
}
