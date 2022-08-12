using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public static bool shtrest = false;
    int mxeshield = 100;
    float eshield = 100;
    public static float pleshield = 100;
    float shldlsmlt = 1;
    bool abeshieldloss = false;
    bool beshieldloss = true;
    bool eshieldloss = false;
    public static float Deshield;
    public static float reamnt = 0;
    public static bool gunua = false;
    //100
    int mxreamnt = 200;
    public static float mesamnt = 0;
    int mxmesamnt = 250;
    public static int expldamnt = 0;
    public static float lightamnt = 5;
    bool twepmesa = true;
    bool rpess = false;
    [SerializeField] Transform gspn;
    [SerializeField] Camera cmrf;
    [SerializeField] GameObject gnde;
    public static bool bldua = false;
    [SerializeField] GameObject bldth;
    bool bldres = false;
    public static bool shootatr = false;
    public static bool isbswing = false;
    float stopbswing = 0;
    RaycastHit objectHitt;
    [SerializeField] LayerMask Groundedt;
    public static GameObject targets;
    //35
    int mxstopbswing = 55;
    float swingrot2 = 45;
    float swingrot3 = 0;
    float swingrot = 10;
    int mxswingrot = 25;
    int mxswingrot2 = 65;
    Quaternion swrdstrro;
    Vector3 swrdstrrov;

    public static bool pispry = false; 

    [SerializeField] AudioClip glnch = null;
    [SerializeField] AudioClip scb = null;
    [SerializeField] AudioClip tswp = null;

    [SerializeField] GameObject spwnflsf;
    [SerializeField] AudioClip spwfls = null;

    [SerializeField] Camera cameracontrollerb;
    [SerializeField] GameObject swrdo;
    [SerializeField] Transform swrdstr;
    [SerializeField] Transform swrdout;
    [SerializeField] Transform swrdspn;
    [SerializeField] GameObject shld;
    [SerializeField] GameObject shldv;
    [SerializeField] GameObject pshld;
    [SerializeField] GameObject pshldv;
    [SerializeField] GameObject bldv;
    [SerializeField] GameObject gnclv;
    [SerializeField] GameObject gncll;
    [SerializeField] GameObject rinstsld;
    [SerializeField] GameObject TrespM;
    [SerializeField] AudioClip ShupS = null;
    // Start is called before the first frame update
    void Start()
    {
        eshield = 100;
        pleshield = 100;
        reamnt = 0;
        mesamnt = 0;
        shootatr = false;
        bldres = false;
        gunua = false;
        bldua = false;
        expldamnt = 0;
        swrdstrro = swrdo.transform.localRotation;
        //swrdstrrov = swrdstrro;
    }

    // Update is called once per frame
    void Update()
    {
        if (PMovement.isdead == false)
        {
            //if (Input.GetKeyD(KeyCode.C))
            //{
                //beshieldloss = true;
            //}
            if (Input.GetKey(KeyCode.C))
            {
                if (Level01Controller.pgpaused == false)
                {
                    //abeshieldloss = true;
                    if (eshield > 0)
                    {
                        DelayHelper.DelayAction(this, beshieldlossf, .25f);
                        eshieldloss = true;
                        if (beshieldloss == false)
                        {
                            shld.SetActive(true);
                            shldv.SetActive(true);
                        }
                        //pshld.SetActive(true);
                        //pshldv.SetActive(true);
                        shtrest = true;
                    }
                }
            }
            if (!Input.GetKey(KeyCode.C))
            {
                if (Level01Controller.pgpaused == false)
                {
                    abeshieldloss = false;
                    beshieldloss = true;
                    eshieldloss = false;
                    shld.SetActive(false);
                    shldv.SetActive(false);
                    pshld.SetActive(false);
                    pshldv.SetActive(false);
                    pispry = false;
                    shtrest = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (Level01Controller.pgpaused == false)
                {
                    if (eshield > 0)
                    {
                        AudioHelper.PlayClip2D(ShupS);
                    }
                }
            }
            if (eshield <= 0)
            {
                shld.SetActive(false);
                shldv.SetActive(false);
                pshld.SetActive(false);
                pshldv.SetActive(false);
                pispry = false;
            }
            if (abeshieldloss == true)
            {
                //beshieldloss = true;
                //DelayHelper.DelayAction(this, beshieldlossf, .25f);
            }
            if (beshieldloss == true)
            {
                if (Input.GetKey(KeyCode.C))
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        shldlsmlt = 5;
                        pshld.SetActive(true);
                        pshldv.SetActive(true);
                        pispry = true;
                    }
                }
            }
            if (beshieldloss == false)
            {
                if (Input.GetKey(KeyCode.C))
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        shldlsmlt = .25f;
                        pshld.SetActive(false);
                        pshldv.SetActive(false);
                        pispry = false;
                    }
                }
            }
            if (eshieldloss == true)
            {
                if (eshield > 0)
                {
                    eshield = Mathf.Clamp(eshield - (60 * shldlsmlt * Time.deltaTime), 0.0f, mxeshield);
                }
            }
            if (eshieldloss == false)
            {
                if (eshield < mxeshield)
                {
                    eshield = Mathf.Clamp(eshield + (30 * Time.deltaTime), 0.0f, mxeshield);
                }
            }
            Deshield = Mathf.Round(eshield);
            pleshield = Mathf.Round(eshield);
            //Debug.Log(shtrest);
            if (gunua == true || bldua == true)
            {
                if(reamnt >0)
                {
                    rinstsld.SetActive(true);
                }
                if (reamnt <= 0)
                {
                    rinstsld.SetActive(false);
                }
                if (twepmesa == true)
                {
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        if (Level01Controller.pgpaused == false)
                        {
                            if (rpess == false)
                            {
                                rpess = true;
                                trespamt();
                            }
                        }
                    }
                    if (rpess == false)
                    {
                        //DelayHelper.DelayAction(this, trespamt, 5f);
                        if (mesamnt < mxmesamnt)
                        {
                            mesamnt = Mathf.Clamp(mesamnt + (60 * Time.deltaTime), 0.0f, mxmesamnt);
                        }
                    }
                    if(mesamnt == mxmesamnt)
                    {
                        trespamt();
                    }
                }
                if (Input.GetKey(KeyCode.T))
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        if (reamnt < mxreamnt)
                        {
                            reamnt = Mathf.Clamp(reamnt + (60 * Time.deltaTime), 0.0f, mxreamnt);
                        }
                    }
                }
                if (!Input.GetKey(KeyCode.T))
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        if (reamnt > 0)
                        {
                            reamnt = Mathf.Clamp(reamnt - (60 * Time.deltaTime), 0.0f, mxreamnt);
                        }
                    }
                }
            }
            if (gunua == false && bldua == false)
            {
                rinstsld.SetActive(false);
                rpess = false;
                twepmesa = true;
                TrespM.SetActive(false);
            }
            //if (bldua == false)
            //{

            //}
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (Level01Controller.pgpaused == false)
                {
                    if (shtrest == false)
                    {
                        if (Shooting.preloading == false)
                        {
                            if (gunua == false)
                            {

                                AudioHelper.PlayClip2D(glnch);

                                expldamnt = Shooting.clip;
                                lightamnt = 5;
                                lightamnt = lightamnt / Shooting.mclip * (expldamnt + 1.5f);
                                Shooting.clip = 0;
                                gnclv.SetActive(false);
                                gncll.SetActive(false);

                                Vector3 gpos = gspn.transform.position;
                                Vector3 gdir = cmrf.transform.forward;
                                Quaternion grrot = cmrf.transform.rotation;
                                Vector3 grpsn = gpos + gdir * 1.1f;
                                Rigidbody rbpb = Instantiate(gnde, grpsn, grrot).GetComponent<Rigidbody>();
                                //was 12f
                                rbpb.AddForce(gspn.transform.forward * 24f, ForceMode.Impulse);

                                gunua = true;
                            }
                        }
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                if (Level01Controller.pgpaused == false)
                {
                    if (shtrest == false)
                    {
                        if (bldua == false)
                        {
                            bldv.SetActive(false);

                            AudioHelper.PlayClip2D(tswp);

                            Vector3 bpos = swrdspn.transform.position;
                            Vector3 bdir = cmrf.transform.forward;
                            Quaternion brrot = cmrf.transform.rotation;
                            Vector3 brpsn = bpos + bdir * 1.1f;
                            Rigidbody rbpbbl = Instantiate(bldth, brpsn, brrot).GetComponent<Rigidbody>();
                            //swrdspn.trnsfm.frd 12f 1f
                            rbpbbl.AddForce(cmrf.transform.forward * 8f, ForceMode.Impulse);

                            //bldua lst
                            bldua = true;
                        }
                    }
                }
            }
            //100
            if (reamnt == 200)
            {
                shootatr = true;
                bldres = false;
                //shootatr = false;
                gunua = false;
                bldua = false;
                Shooting.clip = 6;
                gnclv.SetActive(true);
                gncll.SetActive(true);
                bldv.SetActive(true);

                GameObject flshr = Instantiate(spwnflsf, swrdspn.transform.position, swrdspn.transform.rotation);
                Destroy(flshr, .5f);
                GameObject flshrb = Instantiate(spwnflsf, gspn.transform.position, gspn.transform.rotation);
                Destroy(flshrb, .5f);
                AudioHelper.PlayClip2D(spwfls);

                mesamnt = 0;
                reamnt = 0;
            }
            //100
            if (reamnt < 200)
            {
                if (gunua == true)
                {
                    shootatr = false;
                }
                if (bldua == true)
                {
                    bldres = true;
                }
            }

            if (isbswing == false && Vector3.Distance(swrdo.transform.position, swrdstr.position) < .01f)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        if (shtrest == false)
                        {
                            if (bldres == false)
                            {
                                AudioHelper.PlayClip2D(scb);

                                targets = null;
                                findtarget();

                                isbswing = true;
                                stopbswing = 0;
                            }
                        }
                    }
                }
            }
            if (isbswing == true)
            {
                swrdo.transform.localRotation = Quaternion.Euler(swingrot2, swingrot, swingrot3);
                swrdo.transform.position = Vector3.Lerp(swrdo.transform.position, swrdout.position, Time.deltaTime * 20f);
                if (swingrot < mxswingrot)
                {
                    swingrot = Mathf.Clamp(swingrot + (120 * Time.deltaTime), 0.0f, mxswingrot);
                }
                if (swingrot2 < mxswingrot2)
                {
                    swingrot2 = Mathf.Clamp(swingrot2 + (120 * Time.deltaTime), 0.0f, mxswingrot2);
                }
                stopbswing = Mathf.Clamp(stopbswing + (60 * Time.deltaTime), 0.0f, mxstopbswing);
            }
            if (isbswing == false)
            {
                swrdo.transform.localRotation = Quaternion.Euler(swingrot2, swingrot, swingrot3);
                if (swingrot > 10)
                {
                    swingrot = Mathf.Clamp(swingrot - (120 * Time.deltaTime), 0.0f, mxswingrot);
                }
                if (swingrot2 > 45)
                {
                    swingrot2 = Mathf.Clamp(swingrot2 - (120 * Time.deltaTime), 0.0f, mxswingrot2);
                }
                //swrdo.transform.localRotation = swrdstr.transform.localRotation;
                swrdo.transform.position = Vector3.Lerp(swrdo.transform.position, swrdstr.position, Time.deltaTime * 20f);
            }
            if (stopbswing >= mxstopbswing)
            {
                isbswing = false;
                stopbswing = 0;
            }
        }
    }
    void beshieldlossf ()
    {
        beshieldloss = false;
    }
    void trespamt()
    {
        if (gunua == true || bldres == true)
        {
            TrespM.SetActive(true);
            twepmesa = false;
        }
    }
    void findtarget()
    {
        //Vector3 rayDirectionb = (cameracontrollerb.transform.forward + cameracontrollerb.transform.right).normalized;
        //Vector3 rayDirectionc = (cameracontrollerb.transform.forward - cameracontrollerb.transform.right).normalized;
        //Vector3 rayDirectiond = Vector3.Angle (rayDirectionc, rayDirectionb);
        //if (Physics.Raycast(cameracontrollerb.transform.position, rayDirectiond, out objectHitt, 3.5f, Groundedt))
        //targets = null;
        //2f 8f 
        if (Physics.SphereCast(cameracontrollerb.transform.position, 4f, cameracontrollerb.transform.forward, out objectHitt, 8f, Groundedt))
        {
            if (objectHitt.transform.tag == "Enemyt")
            {
                //targets = gameObject.objectHitt;
                targets = objectHitt.collider.gameObject;
            }
        }
        //Debug.Log(targets);
    }
}
