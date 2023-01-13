using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform pointa;
    [SerializeField] Transform pointb;
    [SerializeField] Transform pointc;
    [SerializeField] Transform pointd;
    [SerializeField] Transform pointe;
    [SerializeField] Transform pointr;
    [SerializeField] GameObject aswtch;
    [SerializeField] GameObject btnlghtl;
    [SerializeField] GameObject btnlghtd;
    [SerializeField] GameObject rswtch;
    [SerializeField] Light sflshevr;
    [SerializeField] AudioClip tpplt = null;
    [SerializeField] AudioClip bzzsn = null;
    [SerializeField] AudioClip drsn = null;
    GameObject Pl;
    bool crryplr = false;
    public bool isbcfr = false;
    public bool isoactve = true;
    public bool isotm = false;
    public bool isotmb = false;
    public bool isupdwn = false;
    public bool istp = false;
    public bool isendl = false;

    bool bzsna = true;

    Vector3 kpscl;
    bool nrswtch = false;
    bool nrrswtch = false;
    //.1
    public bool aisax1 = false;
    public bool bisax1 = false;
    public bool cisax1 = false;
    public float omovspd = .1f;
    public float omovspdb;
    public float trnspd =5f;
    int mvnum = 1;

    Transform mytransform;
    // Start is called before the first frame update
    void Start()
    {
        //pointa.position = this.transform.localPosition;
        //nn.transfor
        Pl = GameObject.Find("Player");
        //mytansforms were this.transform.whatever
        mytransform = transform;
        crryplr = false;
        omovspdb = omovspd;
        bzsna = true;
        if (aswtch != null)
        {
            aswtch.SetActive(true);
        }
        if (rswtch != null)
        {
            rswtch.SetActive(true);
        }
        nrswtch = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Pl)
        {
            //other.transform.parent = transform;
            crryplr = true;
            //Debug.Log("hit");
        }
        //if (other.tag == "Enemyt")
        //{
                //kpscl = other.transform.localScale;
            //Debug.Log("ots" + other.transform.localScale);
            //Debug.Log("kps" + kpscl);
        //}
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemyt")
        {
            if (mvnum == 1)
            {
                other.transform.position = Vector3.MoveTowards(other.transform.position, pointb.transform.position, omovspd * Time.deltaTime);
            }
            if (mvnum == 2)
            {
                other.transform.position = Vector3.MoveTowards(other.transform.position, pointc.transform.position, omovspd * Time.deltaTime);
            }
            if (mvnum == 3)
            {
                other.transform.position = Vector3.MoveTowards(other.transform.position, pointd.transform.position, omovspd * Time.deltaTime);
            }
            if (mvnum == 4)
            {
                if (pointe == null)
                {
                    other.transform.position = Vector3.MoveTowards(other.transform.position, pointa.transform.position, omovspd * Time.deltaTime);
                }
                if (pointe != null)
                {
                    other.transform.position = Vector3.MoveTowards(other.transform.position, pointe.transform.position, omovspd * Time.deltaTime);
                }
            }
            if (mvnum == 5)
            {
                other.transform.position = Vector3.MoveTowards(other.transform.position, pointa.transform.position, omovspd * Time.deltaTime);
            }
            //worked1dwn
            //other.transform.parent = transform;
            //other.transform.localPosition = this.transform.position;
            //other.transform.SetParent(transform);
            //other.transform.localScale = (new Vector3((kpscl.x/ this.transform.localScale.x), (kpscl.y / this.transform.localScale.y), (kpscl.z / this.transform.localScale.z)));
            //Debug.Log(other.transform.localScale);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Pl)
        {
            //other.transform.parent = transform;
            crryplr = false;
            //Debug.Log("hit");
        }
        if (other.tag == "Enemyt")
        {
            //other.transform.parent = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(mvnum);
        //Debug.Log(isotm);
        if (isotm == true)
        {
            omovspd = 0f;
        }
        if (isoactve == true)
        {
            omovspd = omovspdb;
        }
        //if (isotm == false)
        //{
            if (isoactve == false)
            {
                    omovspd = 0f;
            }
        //}
        if (omovspd > 0)
        {
            if (btnlghtl != null)
            {
                btnlghtl.SetActive(true);
            }
            if (btnlghtd != null)
            {
                btnlghtd.SetActive(false);
            }
        }
        if (omovspd == 0)
        {
            if (btnlghtl != null)
            {
                btnlghtl.SetActive(false);
            }
            if (btnlghtd != null)
            {
                btnlghtd.SetActive(true);
            }
        }
        if (aswtch != null)
        {
            //Vector3.Distance
            if (Vector3.Distance(Pl.transform.position, aswtch.transform.position) <= 4f)
            {
                if (PMovement.isdead == false)
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        if (nrswtch == false)
                        {
                            if (isotmb == false)
                            {
                                Level01Controller.eusepr = true;
                            }
                            nrswtch = true;
                        }
                        //Level01Controller.eusepr = true;
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            if (bzzsn != null)
                            {
                                if (bzsna == true)
                                {
                                    if (isotmb == false)
                                    {
                                        AudioHelper.PlayClip2D(bzzsn);
                                        if (drsn != null)
                                        {
                                            AudioHelper.PlayClip2D(drsn);
                                        }
                                        bzsna = false;
                                        DelayHelper.DelayAction(this, bzsnat, .75f);
                                    }
                                }
                            }
                            chngeactv();
                        }
                    }
                }
            }
        }
        if (nrswtch == true)
        {
            if (aswtch != null)
            {
                if (Vector3.Distance(Pl.transform.position, aswtch.transform.position) > 4f)
                {
                    Level01Controller.eusepr = false;
                    nrswtch = false;
                }
            }
        }
        if (nrrswtch == true)
        {
            if (rswtch != null)
            {
                if (Vector3.Distance(Pl.transform.position, rswtch.transform.position) > 4f)
                {
                    Level01Controller.eusepr = false;
                    nrrswtch = false;
                }
            }
        }
        if (rswtch != null)
        {
            if (Vector3.Distance(Pl.transform.position, rswtch.transform.position) <= 4f)
            {
                if (PMovement.isdead == false)
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        if (nrrswtch == false)
                        {
                            Level01Controller.eusepr = true;
                            nrrswtch = true;
                        }
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            rcll();
                        }
                    }
                }
            }
        }
        if (mvnum == 1)
        {
            //local pos
            if (Vector3.Distance(pointb.transform.position, mytransform.position) > 1f)
            {
                //lerp
                mytransform.position = Vector3.MoveTowards(mytransform.position, pointb.position, Time.deltaTime * omovspd);
                //Debug.Log(Vector3.Angle((this.transform.position - pointb.transform.position), this.transform.forward));
                if (isupdwn == false)
                {
                    if (Vector3.Angle((mytransform.position - pointb.transform.position), mytransform.forward) != 0)
                    {
                        //this.transform.RotateAround(this.transform.position, this.transform.up, -50f * Time.deltaTime);
                        Quaternion frot = Quaternion.LookRotation((mytransform.position - pointb.transform.position));
                        //was tdt* 5f
                        mytransform.rotation = Quaternion.Slerp(transform.rotation, frot, Time.deltaTime * trnspd);
                    }
                }
                //Rigidbody rbomv = this.GetComponent<Rigidbody>();
                //my nd dtd was fm.f 32 64f
                //rbomv.AddForce(pointb.position * Time.deltaTime * omovspd, ForceMode.Force);
                if (crryplr == true)
                {
                    //Lerp
                    //Debug.Log("hit2");
                    //Pl.transform.position = Vector3.MoveTowards(Pl.transform.position, pointb.position, Time.deltaTime * omovspd);
                    //Pl.transform.position = pointa.transform.position;
                    //goodish
                    //if (aisax1 == false)
                    //{
                    if (isupdwn == false)
                    {
                        Pl.GetComponent<CharacterController>().Move(-this.transform.forward * omovspd * Time.deltaTime);
                    }
                    if (isupdwn == true)
                    {
                        Pl.GetComponent<CharacterController>().Move(this.transform.up * omovspd * Time.deltaTime);
                    }
                    //}
                    //if (aisax1 == true)
                    //{
                    //Pl.GetComponent<CharacterController>().Move(-this.transform.right * omovspd * Time.deltaTime);
                    //}
                    //Pl.GetComponent<CharacterController>().Move((pointb.position - this.transform.position) * (omovspd/20) * Time.deltaTime);
                }
            }
            if (Vector3.Distance(pointb.transform.position, mytransform.position) < 2f)
            {
                if (istp == false)
                {
                    if (isbcfr == false)
                    {
                        mvnum = 2;
                    }
                    if (isbcfr == true)
                    {
                        mvnum = 4;
                    }
                }
                if (istp == true && isbcfr == true)
                {
                    rcll();
                }
                if (istp == true && isbcfr == false)
                {
                    mvnum = 2;
                }
            }
        }
        if (mvnum == 2)
        {
            if (Vector3.Distance(pointc.transform.position, mytransform.position) > 1f)
            {
                //lerp
                mytransform.position = Vector3.MoveTowards(mytransform.position, pointc.position, Time.deltaTime * omovspd);
                //Debug.Log(Vector3.Angle((this.transform.position - pointc.transform.position), this.transform.forward));
                if (Vector3.Angle((mytransform.position - pointc.transform.position), mytransform.forward) != 0)
                {
                    //this.transform.RotateAround(this.transform.position, this.transform.up, -50f * Time.deltaTime);
                    Quaternion frot = Quaternion.LookRotation((mytransform.position - pointc.transform.position));
                    //was tdt* 5f
                    mytransform.rotation = Quaternion.Slerp(transform.rotation, frot, Time.deltaTime * trnspd);
                }
                //Rigidbody rbomvb = this.GetComponent<Rigidbody>();
                //my nd dtd was fm.f 32 64f
                //rbomvb.AddForce(pointa.position* Time.deltaTime * omovspd, ForceMode.Force);
                if (crryplr == true)
                {
                    //lerp
                    //Debug.Log("hit2");
                    //Pl.transform.position = Vector3.MoveTowards(Pl.transform.position, pointb.position, Time.deltaTime * omovspd);
                    //Pl.transform.position = pointa.transform.position;
                    //goodish
                    //Pl.GetComponent<CharacterController>().Move(this.transform.right * omovspd * Time.deltaTime);
                    //if (bisax1 == false)
                    //{
                        Pl.GetComponent<CharacterController>().Move(-this.transform.forward * omovspd * Time.deltaTime);
                    //}
                    //if (bisax1 == true)
                    //{
                        //Pl.GetComponent<CharacterController>().Move(-this.transform.right * omovspd * Time.deltaTime);
                    //}
                    //Pl.GetComponent<CharacterController>().Move((pointa.position - this.transform.position) * (omovspd/20) * Time.deltaTime);
                }
            }
            if (Vector3.Distance(pointc.transform.position, mytransform.position) < 2f)
            {
                mvnum = 3;
            }
        }
        if (mvnum == 3)
        {
            //float platdistancemn3 = Vector3.Distance(pointd.transform.position, mytransform.position);
            if (Vector3.Distance(pointd.transform.position, mytransform.position) > 1f)
            //if (platdistancemn3 > 1f)
            {
                //lerp
                mytransform.position = Vector3.MoveTowards(mytransform.position, pointd.position, Time.deltaTime * omovspd);
                //Debug.Log(Vector3.Angle((this.transform.position - pointa.transform.position), this.transform.forward));
                if (Vector3.Angle((mytransform.position - pointd.transform.position), mytransform.forward) != 0)
                //float anglemn3 = Vector3.Angle((mytransform.position - pointd.transform.position), mytransform.forward);
                //if (anglemn3 != 0)
                {
                    //this.transform.RotateAround(this.transform.position, this.transform.up, -50f * Time.deltaTime);
                    Quaternion frot = Quaternion.LookRotation((mytransform.position - pointd.transform.position));
                    //was tdt *5f was
                    mytransform.rotation = Quaternion.Slerp(transform.rotation, frot, Time.deltaTime * trnspd);
                }
                //Rigidbody rbomvb = this.GetComponent<Rigidbody>();
                //my nd dtd was fm.f 32 64f
                //rbomvb.AddForce(pointa.position* Time.deltaTime * omovspd, ForceMode.Force);
                if (crryplr == true)
                {
                    //lerp
                    //Debug.Log("hit2");
                    //Pl.transform.position = Vector3.MoveTowards(Pl.transform.position, pointb.position, Time.deltaTime * omovspd);
                    //Pl.transform.position = pointa.transform.position;
                    //goodish
                    //Pl.GetComponent<CharacterController>().Move(this.transform.right * omovspd * Time.deltaTime);
                    //if (cisax1 == false)
                    //{
                        Pl.GetComponent<CharacterController>().Move(-this.transform.forward * omovspd * Time.deltaTime);
                    //}
                    //if (cisax1 == true)
                    //{
                        //Pl.GetComponent<CharacterController>().Move(-this.transform.right * omovspd * Time.deltaTime);
                    //}
                    //Pl.GetComponent<CharacterController>().Move((pointa.position - this.transform.position) * (omovspd/20) * Time.deltaTime);
                }
            }
            if (Vector3.Distance(pointd.transform.position, mytransform.position) < 2f)
            //if (platdistancemn3 < 2f)
            {
                mvnum = 4;
            }
        }
        if (mvnum == 4)
        {
            if (pointe == null)
            {
                if (Vector3.Distance(pointa.transform.position, mytransform.position) > 1f)
                {
                    //if (istp == true && isbcfr == false)
                    //{
                    //rcll();
                    //}

                    //lerp
                    mytransform.position = Vector3.MoveTowards(mytransform.position, pointa.position, Time.deltaTime * omovspd);
                    //Debug.Log(Vector3.Angle((this.transform.position - pointa.transform.position), this.transform.forward));
                    if (isupdwn == false)
                    {
                        if (Vector3.Angle((mytransform.position - pointa.transform.position), mytransform.forward) != 0)
                        {
                            //this.transform.RotateAround(this.transform.position, this.transform.up, -50f * Time.deltaTime);
                            Quaternion frot = Quaternion.LookRotation((mytransform.position - pointa.transform.position));
                            //was tdt*5f
                            mytransform.rotation = Quaternion.Slerp(transform.rotation, frot, Time.deltaTime * trnspd);
                        }
                    }
                    //Rigidbody rbomvb = this.GetComponent<Rigidbody>();
                    //my nd dtd was fm.f 32 64f
                    //rbomvb.AddForce(pointa.position* Time.deltaTime * omovspd, ForceMode.Force);
                    if (crryplr == true)
                    {
                        //lerp
                        //Debug.Log("hit2");
                        //Pl.transform.position = Vector3.MoveTowards(Pl.transform.position, pointb.position, Time.deltaTime * omovspd);
                        //Pl.transform.position = pointa.transform.position;
                        //goodish
                        //Pl.GetComponent<CharacterController>().Move(this.transform.right * omovspd * Time.deltaTime);
                        //if (cisax1 == false)
                        //{
                        if (isupdwn == false)
                        {
                            Pl.GetComponent<CharacterController>().Move(-this.transform.forward * omovspd * Time.deltaTime);
                        }
                        if (isupdwn == true)
                        {
                            Pl.GetComponent<CharacterController>().Move(-this.transform.up * omovspd * Time.deltaTime);
                        }
                        //}
                        //if (cisax1 == true)
                        //{
                        //Pl.GetComponent<CharacterController>().Move(-this.transform.right * omovspd * Time.deltaTime);
                        //}
                        //Pl.GetComponent<CharacterController>().Move((pointa.position - this.transform.position) * (omovspd/20) * Time.deltaTime);
                    }
                }
            }
            if (pointe != null)
            {
                if (Vector3.Distance(pointe.transform.position, mytransform.position) > 1f)
                {
                    //if (istp == true && isbcfr == false)
                    //{
                    //rcll();
                    //}

                    //lerp
                    mytransform.position = Vector3.MoveTowards(mytransform.position, pointe.position, Time.deltaTime * omovspd);
                    //Debug.Log(Vector3.Angle((this.transform.position - pointa.transform.position), this.transform.forward));
                    if (isupdwn == false)
                    {
                        if (Vector3.Angle((mytransform.position - pointe.transform.position), mytransform.forward) != 0)
                        {
                            //this.transform.RotateAround(this.transform.position, this.transform.up, -50f * Time.deltaTime);
                            Quaternion frot = Quaternion.LookRotation((mytransform.position - pointe.transform.position));
                            //was tdt* 5f
                            mytransform.rotation = Quaternion.Slerp(transform.rotation, frot, Time.deltaTime * trnspd);
                        }
                    }
                    if (crryplr == true)
                    {

                        if (isupdwn == false)
                        {
                            Pl.GetComponent<CharacterController>().Move(-this.transform.forward * omovspd * Time.deltaTime);
                        }
                        if (isupdwn == true)
                        {
                            Pl.GetComponent<CharacterController>().Move(-this.transform.up * omovspd * Time.deltaTime);
                        }
                    }
                }
            }
            if (pointe == null)
            {
                if (Vector3.Distance(pointa.transform.position, mytransform.position) < 2f)
                {
                        mvnum = 1;
                }
            }
            if (pointe != null)
            {
                if (Vector3.Distance(pointe.transform.position, mytransform.position) < 2f)
                {
                        mvnum = 5;
                }
            }
        }
        if (mvnum == 5)
        {
            if (Vector3.Distance(pointa.transform.position, mytransform.position) > 1f)
            {
                //lerp
                mytransform.position = Vector3.MoveTowards(mytransform.position, pointa.position, Time.deltaTime * omovspd);
                //Debug.Log(Vector3.Angle((this.transform.position - pointa.transform.position), this.transform.forward));
                if (Vector3.Angle((mytransform.position - pointa.transform.position), mytransform.forward) != 0)
                {
                    //this.transform.RotateAround(this.transform.position, this.transform.up, -50f * Time.deltaTime);
                    Quaternion frot = Quaternion.LookRotation((mytransform.position - pointa.transform.position));
                    //was tdt*5f
                    mytransform.rotation = Quaternion.Slerp(transform.rotation, frot, Time.deltaTime * trnspd);
                }
                //Rigidbody rbomvb = this.GetComponent<Rigidbody>();
                //my nd dtd was fm.f 32 64f
                //rbomvb.AddForce(pointa.position* Time.deltaTime * omovspd, ForceMode.Force);
                if (crryplr == true)
                {
                    //lerp
                    //Debug.Log("hit2");
                    //Pl.transform.position = Vector3.MoveTowards(Pl.transform.position, pointb.position, Time.deltaTime * omovspd);
                    //Pl.transform.position = pointa.transform.position;
                    //goodish
                    //Pl.GetComponent<CharacterController>().Move(this.transform.right * omovspd * Time.deltaTime);
                    //if (cisax1 == false)
                    //{
                    Pl.GetComponent<CharacterController>().Move(-this.transform.forward * omovspd * Time.deltaTime);
                    //}
                    //if (cisax1 == true)
                    //{
                    //Pl.GetComponent<CharacterController>().Move(-this.transform.right * omovspd * Time.deltaTime);
                    //}
                    //Pl.GetComponent<CharacterController>().Move((pointa.position - this.transform.position) * (omovspd/20) * Time.deltaTime);
                }
            }
            if (Vector3.Distance(pointa.transform.position, mytransform.position) < 2f)
            {
                if (isendl == false)
                {
                    mvnum = 1;
                }
                if (isendl == true)
                {
                    isoactve = false;
                }
            }
        }
    }
    public void chngeactv()
    {
        if (isotm == false)
        {
            if (isotmb == false)
            {
                isoactve = !isoactve;
            }
        }
        if (isotm == true)
        {
            if (isotmb == false)
            {
                isoactve = !isoactve;
                isotmb = true;
            }
        }

    }
    public void rcll()
    {
        if (istp == false)
        {
            isoactve = false;
        }
        if (sflshevr != null)
        {
            Light flshrev = Instantiate(sflshevr, mytransform.position, mytransform.rotation);
            flshrev.range = 3;
            Destroy(flshrev, .5f);
            Light flshrevb = Instantiate(sflshevr, pointa.transform.position, pointa.transform.rotation);
            flshrevb.range = 3;
            Destroy(flshrevb, .5f);
        }
        if (tpplt != null)
        {
            AudioHelper.PlayClip2D(tpplt);
        }
        if (isendl == false)
        {
            mytransform.position = pointa.transform.position;
        }
        if (isendl == true)
        {
            if (pointr != null)
            {
                mvnum = 1;
                mytransform.position = pointr.transform.position;
            }
        }
    }
    void bzsnat()
    {
        bzsna = true;
    }
}
