using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pbullet : MonoBehaviour
{
    bool stp2 = false;
    //bool mtht2 = false;
    bool dsph = false;
    [SerializeField] AudioClip MthtS2 = null;
    [SerializeField] GameObject bpartc2;
    Transform rorg;
    float shootdist;
    public bool setdised = true;
    // Start is called before the first frame update
    void Start()
    {
        rorg = GameObject.Find("Gun end").transform;
        Destroy(this.gameObject, 5f);
        shootdist = 20f;
        //DelayHelper.DelayAction(this, chckspa, .2f);
    }
    //private void OnTriggerEnter(Collider other)
    private void OnTriggerEnter(Collider other)
    {
        //mtht2 = true;
        //Rigidbody rbepb2 = this.GetComponent<Rigidbody>();
        //rbepb2.AddForce(-rbepb2.velocity, ForceMode.VelocityChange);
        //rbepb2.velocity = Vector3.zero;
        //Destroy(rbepb2);
        if (other.tag != "Ladder")
        {
            if (other.tag != "HangS")
            {
                sdstrct2();
            }
        }
    }

        // Update is called once per frame
    void Update()
    {
        //dsph = Physics.CheckSphere(transform.position, .31f);
        //if (dsph == true)
        //{
        //sdstrct2();
        //}
        //if (setdised == true)
        //{
        shootdist = Shooting.Pshootdis;
        //}
        if (Vector3.Distance(rorg.position, this.transform.position) > shootdist)
        {
            Rigidbody rbepb = this.GetComponent<Rigidbody>();
            rbepb.velocity = Vector3.zero;
            sdstrct2();
        }
    }
    void sdstrct2()
    {
        //if (mtht2 == true)
        //{
            //AudioHelper.PlayClip2D(MthtS2);
            //mtht2 = false;
        //}
        GameObject bprt2 = Instantiate(bpartc2, this.transform.position, this.transform.rotation);
        Destroy(bprt2, .5f);
        Destroy(this.gameObject);
        //GameObject.Destroy(gameObject);
    }
}
