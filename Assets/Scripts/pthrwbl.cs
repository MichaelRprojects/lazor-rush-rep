using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pthrwbl : MonoBehaviour
{
    GameObject[] enemiestr;
    GameObject[] enemiestrb;
    Vector3 etargs;
    [SerializeField] GameObject bldprt;
    [SerializeField] AudioClip bldths = null;
    bool targfound = false;
    bool movetotar = true;
    // Start is called before the first frame update
    void Start()
    {
        enemiestr = GameObject.FindGameObjectsWithTag("Enemyt");
        DelayHelper.DelayAction(this, plybtsn, .4f);
        DelayHelper.DelayAction(this, tswrslfdst, 1.4f);
        //levelrt = this.transform.localRotation.x;
        //levelrta = this.transform.localRotation.y;
        //levelrtb = this.transform.localRotation.z;

    }

    // Update is called once per frame
    void Update()
    {
        //l
        for (int i = 0; i < enemiestr.Length; i++)
        {
            //Debug.Log(i);
            if (enemiestr[i] != null)
            {
                //was<=10
                if (Vector3.Distance(this.transform.position, enemiestr[i].transform.position) <= 20)
                {
                    //Debug.Log(i);
                    etargs = enemiestr[i].transform.position;
                    transform.LookAt(etargs);
                    //transform.RotateAround(this.transform.position, this.transform.right, 500 * Time.deltaTime);
                    //Debug.Log(etargs);
                    //this.transform.localRotation = Quaternion.Euler(etargs);
                    //if (this.transform.position != etargs)
                    //if (enemiestr[i] != null)
                    //{
                    //Debug.Log(i + "b");
                    Rigidbody rbpbblm = this.GetComponent<Rigidbody>();
                    //if (rbpbblm.velocity.magnitude < 1f)
                    //{
                    rbpbblm.velocity = (etargs - this.transform.position) * 8f;
                    //}
                    //}
                }
            }
            if (enemiestr[i] == null)
            {
                Rigidbody rbpbblmn = this.GetComponent<Rigidbody>();
                rbpbblmn.velocity = transform.forward * 8f;
            }
        }

        //Rigidbody rbpbblmsp = this.GetComponent<Rigidbody>();
        //rbpbblmsp.AddTorque(700, 0, 0);

        //transform.Rotate(500 * Time.deltaTime, 0, 0);

        transform.RotateAround(this.transform.position, this.transform.right, 500 * Time.deltaTime);

        //this.transform.localRotation = Quaternion.Euler(levelrt, levelrta, levelrtb);
        //levelrta = this.transform.localRotation.x;
        //levelrta = 90;
        //levelrt = 90;
        //levelrtb = this.transform.localRotation.z;

        //levelrt = 45;
        //if (levelrt < mxlevelrt)
        //{
        //levelrt = Mathf.Clamp(levelrt + (120 * Time.deltaTime), 0.0f, mxlevelrt);
        //}
        //this.transform.localRotation = Quaternion.Euler(levelrt, levelrta, levelrtb);


    }

    void tswrslfdst()
    {
        GameObject bprtsw = Instantiate(bldprt, this.transform.position, this.transform.rotation);
        Destroy(bprtsw, .5f);
        Destroy(this.gameObject);
    }
    void plybtsn()
    {
        AudioHelper.PlayClip2D(bldths);
    }
}
