using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class erocket : MonoBehaviour
{
    Transform Pl;
    public float rcktspd = 20f;
    bool islookn = true;
    bool stp = false;
    bool mtht = false;
    bool plyrflct = true;
    public static bool isreflct = false;
    [SerializeField] AudioClip MthtS = null;
    [SerializeField] AudioClip RtrnhtS = null;
    //[SerializeField] GameObject rpartc;
    [SerializeField] GameObject eexpl;
    //[SerializeField] GameObject eklr;
    //public float stimer;

    void Start()
    {
        Pl = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Enemyt")
        //{
        //eklr.SetActive(false);
        //}
        // dddddddddddddddddddddddd
        //if (other.tag == "pshield")
        //{
              //isreflct = true;
            //eklr.SetActive(true);
              //Renderer bren = this.GetComponent<Renderer>();
              //bren.material.color = Color.blue;
            //Rigidbody rthb = this.GetComponent<Rigidbody>();
            //rthb.velocity = Vector3.zero;
            //rthb.AddForce(-transform.forward * 32f, ForceMode.Impulse);
            //if (plyrflct == true)
            //{
                //AudioHelper.PlayClip2D(RtrnhtS);
                //plyrflct = false;
            //}
        //}
        //ddddddddddddddddddddddd
        if (other.tag == "shield")
        {
            sdstrct();
        }
        //|| other.tag != "shield"
        if (other.tag != "pshield" && other.tag != "shield" && other.tag != "mplt")
        {
            mtht = true;
            sdstrct();
        }
        //if (other.tag == "Plyr")
        //{
        //stp = true;
        //}
    }
    // Update is called once per frame
    void Update()
    {
        Pl = GameObject.Find("Player").transform;
        //Vector3 rtarg = Pl.transform.position - Pl.transform.position;
        Vector3 rtarg = Pl.transform.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, rtarg, 1000f * Time.deltaTime, 0.0f);
        //20f
        transform.Translate(Vector3.forward * Time.deltaTime * rcktspd, Space.Self);

        if (Vector3.Distance(transform.position, Pl.transform.position) < 5f)
        {
            islookn = false;
        }
        if (islookn)
        {
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
        //transform.rotation = Quaternion.LookRotation(newDirection);
        //transform.LookAt(rlookpos);
        DelayHelper.DelayAction(this, sdstrct, 3f);
        if (stp == true)
        {
            sdstrct();
        }
        //Rigidbody rbrc = this.GetComponent<Rigidbody>();
        //my nd dtd was fm.f 32 64f
        //Vector3 rlookrot = Quaternion.LookRotation(rlookpos);
        //rbrc.MoveRotation(Quaternion.RotateTowards(transform.rotation, rlookrot, 5f * Time.deltaTime));
        //rbrc.AddForce(transform.forward * Time.deltaTime * rcktspd, ForceMode.Force);
        //rbrc.AddForce(transform.forward * Time.deltaTime * rcktspd, ForceMode.Force);
    }
    public void sdstrct()
    {
        if (mtht == true)
        {
            AudioHelper.PlayClip2D(MthtS);
            mtht = false;
        }
        GameObject rprt = Instantiate(eexpl, this.transform.position, this.transform.rotation);
        Destroy(rprt, .5f);
        Destroy(this.gameObject);
        //GameObject.Destroy(gameObject);
    }
}
