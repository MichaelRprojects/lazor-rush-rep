using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyS : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] LayerMask Playerl;
    [SerializeField] GameObject ehand;
    [SerializeField] GameObject egun;
    Transform Pl;
    bool grndc;
    int ehealth = 100;
    float pdetr = 20;
    bool pdet;
    bool pcls;
    bool phit;
    bool hitm = false;
    bool movea = true;
    bool attacka = true;
    float zt = 0;
    float offsetyb = 0;
    float offsetxb = 0;

    [SerializeField] LayerMask grounded;
    bool blockc;
    public static bool blockb = false;

    [SerializeField] AudioClip LlS = null;
    [SerializeField] AudioClip ThdS = null;
    [SerializeField] AudioClip ExploS = null;
    [SerializeField] AudioClip AlrS = null;
    bool plthd = true;
    bool plalr2 = true;
    [SerializeField] GameObject opartc;
    // Start is called before the first frame update
    void Start()
    {
        Pl = GameObject.Find("Player").transform;
        zt = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "reflectb")
        {
            //if (Bullet.isreflct == true)
            //{
            //25
                TDamage(50);
                //ehealth = ehealth - 50;
            //}
            //EnemyS enemyS = objectHit.transform.gameObject.GetComponent<EnemyS>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hitm == false)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.z, 0, 0);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.y, 0, 0);
        }
        if (PMovement.isdead == false)
        {
            if (pdet == false)
            {
                Rigidbody rbe = this.GetComponent<Rigidbody>();
                //rbe.velocity = Vector3.zero;
                grndc = Physics.CheckSphere(this.transform.position, 3, grounded);
                if (grndc == false)
                {
                    //-1
                    rbe.velocity = new Vector3(0, -4, 0);
                }
                rbe.angularVelocity = Vector3.zero;
                //rbe.useGravity = true;
                plalr2 = true;
                zt = 0;
                attacka = true;
            }

            if (movea == false)
            {
                Rigidbody rbe4 = this.GetComponent<Rigidbody>();
                rbe4.velocity = new Vector3(0, -1, 0);
                rbe4.angularVelocity = Vector3.zero;
            }

            //Gizmos.DrawWireSphere(egun.transform.position, .25f);
            //Vector3 upoff2 = new Vector3(.1f, 0, 0);
            //Vector3 dwnoff2 = new Vector3(-2, 0, 0);
            //Vector3 upoff3 = new Vector3(0, 0, 2);
            //Vector3 dwnoff3 = new Vector3(0, 0, -2);
            blockc = Physics.CheckCapsule(egun.transform.position, ehand.transform.position, .5f, grounded);
            //blockc = Physics.CheckCapsule(egun.transform.position +upoff2, egun.transform.position, .2f, grounded);
            //blockc = Physics.CheckSphere(egun.transform.position, 1f, grounded);
            if (blockc == true)
            {
                //hopefully wont cause problem
                //blockb = true;
            }
            if (blockc == false)
            {
                blockb = false;
            }


            phit = Physics.CheckSphere(transform.position, 1f, Playerl);
            if (phit == true)
            {
                if (PMovement.pBStamloss)
                {
                    hitm = true;
                }
                //phit = false;
                //Rigidbody rben3 = this.GetComponent<Rigidbody>();
                //my nd dtd was fm.f
                //rben3.AddForce(transform.forward * Time.deltaTime * -164f, ForceMode.Force);
            }


            if (hitm == true)
            {
                Rigidbody rben3 = this.GetComponent<Rigidbody>();
                //my nd dtd was fm.f 564 -300
                //rben3.AddForce(transform.forward * Time.deltaTime * -700f, ForceMode.Force);
                //700 2800
                rben3.AddForce(Pl.transform.forward * Time.deltaTime * 2100f, ForceMode.Force);

                if (plthd == true)
                {
                    AudioHelper.PlayClip2D(ThdS);
                    plthd = false;
                }
                DelayHelper.DelayAction(this, plthdt, .5f);

                DelayHelper.DelayAction(this, hitmf, .5f);
            }


            //pcls = Physics.CheckSphere(transform.position, 3, Playerl);
            //total 20 like pdetr
            Vector3 upoff = new Vector3(0, 10, 0);
            Vector3 dwnoff = new Vector3(0, -10, 0);
            pcls = Physics.CheckCapsule(transform.position + upoff, transform.position + dwnoff, 3, Playerl);

            pdet = Physics.CheckSphere(transform.position, pdetr, Playerl);
            if (pdet == true)
            {
                //Vector3 lookVector = Pl.transform.position - transform.position;

                //-3 -2.8
                //lookVector.y = transform.position.y - 0f;
                //Quaternion rot = Quaternion.LookRotation(lookVector);
                //my nd tdt
                //transform.rotation = Quaternion.Slerp(transform.rotation, rot, zt += Time.deltaTime / .25f);

                //Vector3 lookVector2 = Vector3.RotateTowards(transform.forward, lookVector, 30f * Time.deltaTime,0.0f);
                //transform.rotation = Quaternion.LookRotation(lookVector2);
                //if (hitm == false)
                //{
                    Vector3 lookpos = Pl.transform.position;
                    lookpos.y = transform.position.y;
                    transform.LookAt(lookpos);

                if (plalr2 == true)
                {
                    AudioHelper.PlayClip2D(AlrS);
                    plalr2 = false;
                }
                //}

                //egun.blb flse
                if (attacka == true && blockb == false)
                {
                    if (hitm == false)
                    {
                        attck();
                        DelayHelper.DelayAction(this, attackat, .5f);
                    }
                }

                if (pcls == false)
                {
                    //moven = true;
                    //DelayHelper.DelayAction(this, movenf, 3f);
                    if (movea == true)
                    {
                        if (hitm == false)
                        {
                            eMove();
                        }
                    }
                }
                if (pcls == true)
                {
                    if (hitm == false)
                    {
                        Rigidbody rben2 = this.GetComponent<Rigidbody>();
                        rben2.velocity = Vector3.zero;
                        rben2.angularVelocity = Vector3.zero;
                    }
                    //rben2.constraints = RigidbodyConstraints.FreezeRotationY;
                    //zt = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                attck();
            }
            if (ehealth <= 0)
            {
                Level01Controller.currentScore += 20;
                offsetyb = Random.Range(-1.0f, 1.0f);
                offsetxb = Random.Range(-1.0f, 1.0f);
                Vector3 upoff5 = new Vector3(offsetyb, offsetyb, offsetyb);
                Vector3 dwnoff5 = new Vector3(offsetxb, offsetxb, offsetxb);
                GameObject oprt3 = Instantiate(opartc, this.transform.position +upoff5, this.transform.rotation);
                GameObject oprt2 = Instantiate(opartc, this.transform.position +dwnoff5, this.transform.rotation);
                GameObject oprt = Instantiate(opartc, this.transform.position, this.transform.rotation);
                Destroy(oprt, .5f);
                Destroy(oprt3, .5f);
                Destroy(oprt2, .5f); 
                AudioHelper.PlayClip2D(ExploS);
                Destroy(this.gameObject);
            }
        }
        
    }
    public void TDamage(int damagetoTake)
    {
        ehealth -= damagetoTake;
        movea = false; 
        //.5
        DelayHelper.DelayAction(this, moveat, .5f);
        //Debug.Log(ehealth + "lll");
    }
    void attck()
    {
            //c0 

            //Vector3 epos = this.transform.position;
            //Vector3 edir = this.transform.forward;
            //Quaternion erot = this.transform.rotation *=Quaternion.Euler(new Vector3(0,offsetyb,0));

            Vector3 epos = egun.transform.position;

            Quaternion offang = Quaternion.identity;
            //offang.eulerAngles = new Vector3(offsetxb, 0, 0);
            offang.eulerAngles = new Vector3(0, 0, 0);

            //Vector3 edir = ehand.transform.forward;
            Vector3 edir = ehand.transform.forward;

            //Quaternion erot = ehand.transform.rotation *= Quaternion.Euler(new Vector3(0, 0, 0));
            Quaternion erot = ehand.transform.rotation;

            Vector3 ebspn = epos + edir * 1.1f;
            //Vector3 ebspn = epos + edir * 1.1f;
            Rigidbody rb = Instantiate(projectile, ebspn, erot).GetComponent<Rigidbody>();
            rb.velocity = transform.TransformDirection(offang.eulerAngles);
            //rb.transform.eulerAngles = offang.eulerAngles;
            //my nd tdt
            //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //32 96
            rb.AddForce(ehand.transform.forward * 32f, ForceMode.Impulse);

            AudioHelper.PlayClip2D(LlS);

            attacka = false;
    }
    void eMove()
    {
        Rigidbody rben = this.GetComponent<Rigidbody>();
        //my nd dtd was fm.f 32
        rben.AddForce(transform.forward * Time.deltaTime * 64f, ForceMode.Force);
        //moven = false;
    }
    void moveat()
    {
        movea = true;
    }
    void attackat()
    {
        if (pdet == true)
        {
            attacka = true;
        }
    }
    void hitmf()
    {
        hitm = false;
    }
    void plthdt()
    {
        plthd = true;
    }
}
