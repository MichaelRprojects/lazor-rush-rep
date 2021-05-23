using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float runspeed = 24f;
    public float BSprintsp = 48f;

    public float gravity = -9.8f;
    public float jumphieght = 3f;

    //int2
    public static float Health = 1000;
    public static float DHealth = 1000;
    public static int MaxHealth = 1000;
    //2
    public static int Hdamage = 525;
    public static bool thvol = false;
    bool ebdmgd = false;
    public bool healing = false;
    public float HregTimer = 0.0f;
    public const float Htimetreg = 2.0f;

    //int2
    public static float Stamina = 4000;
    public static float DStamina = 4000;
    public static int MaxStamina = 4000;

    //3200
    public static int JumpSc = 1900;
    int jumpnum = 2;
    public bool Stamloss = false;
    public bool BSprint = true;
    public bool BStamloss = false;
    public static bool pBStamloss = false;
    public bool JStamloss = false;
    public bool LUStamloss = false;
    public bool HStamloss = false;
    public static bool NEStamMes = false;
    //3200
    int DodgeSc = 1900;
    bool DStamloss = false;

    float slopeang;
    Vector3 slpvec;
    Vector3 slpvec2;
    bool isslope = false;
    RaycastHit gout;

    float airslow = 1f;
    bool dasha = false;
    //float lspeed;

    public static bool isdead = false;
    public static bool isladder = false;
    public static bool isladdera = false;
    public bool isHang = false;
    public bool grab = false;
    public bool graba = false;
    public static bool pissprnt = false;

    int djunlock = 0;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [SerializeField] AudioClip HrtSpm = null;
    [SerializeField] AudioClip MtgrS = null;
    [SerializeField] AudioClip LdupS = null;
    [SerializeField] AudioClip LddwnS = null;
    [SerializeField] AudioClip djumpS = null;
    [SerializeField] AudioClip dgeS = null;

    Vector3 velocity;
    bool isGrounded;
    void Awake()
    {
        isdead = false;
        Health = 1000;
        thvol = false;
        Stamina = 4000;
        pissprnt = false;

        airslow = 1f;
        jumpnum = 2;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ladder")
        {
            isladdera = true;
        }
        if (other.tag == "HangS")
        {
            isHang = true;
        }
        if (other.tag == "Ebl")
        {
            ebdmgd = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Slope")
        {
            isslope = true;
            //sldrot = other.localRotatoin.y;
            sliden();
            //airslow = 2f;
            //Debug.Log("slp");
        }
        if (other.tag != "Slope")
        {
            DelayHelper.DelayAction(this, isldf, .25f);
            //airslow =1
            //isslope = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ladder")
        {
            isladder = false;
            isladdera = false;
        }
        if (other.tag == "HangS")
        {
            isHang = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isdead == true)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
            Health = 0;
            if (Level01Controller.respawn == true)
            {
                isdead = false;
            }
        }
        if (Health <= 0)
        {
            isdead = true;
        }
        if (isdead == false)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                if (isladder == false)
                {
                    velocity.y = -2f;
                }
            }


            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            if (isladder == false)
            {
                if (Level01Controller.pgpaused == false)
                {
                    Vector3 move = transform.right * x + transform.forward * z;

                    controller.Move(move * (speed / airslow) * Time.deltaTime);
                }
            }

            if (isGrounded)
            {
                airslow = 1f;
                jumpnum = 2;
            }

            if (!isGrounded)
            {
                airslow = 1.4f;
            }
            if (isladder == true)
            {
                jumpnum = 2;
                velocity.y = 0f;
                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        AudioHelper.PlayClip2D(LdupS);
                    }
                }
                if (Input.GetKey(KeyCode.W))
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        velocity.y = 2f;
                        LUStamloss = true;
                    }
                }
                if (Input.GetKeyUp(KeyCode.W))
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        velocity.y = 0f;
                        LUStamloss = false;
                    }
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        AudioHelper.PlayClip2D(LddwnS);
                    }
                }
                if (Input.GetKey(KeyCode.S))
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        velocity.y = -6f;
                    }
                }
                if (Input.GetKeyUp(KeyCode.S))
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        velocity.y = 0f;
                    }
                }
                if (Level01Controller.pgpaused == false)
                {
                    Vector3 move = transform.right * x;
                    controller.Move(move * speed * Time.deltaTime);
                }
            }
            if (isladdera == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        AudioHelper.PlayClip2D(MtgrS);
                        Grabstate();
                    }
                }
            }

            int djunlock = PlayerPrefs.GetInt("Djunlock");
            if (Input.GetKeyDown(KeyCode.I))
            {
                PlayerPrefs.SetInt("Djunlock", 1);
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                PlayerPrefs.SetInt("Djunlock", 0);
            }

            if (djunlock == 0)
            {
                if (Stamina >= JumpSc)
                {
                    if (Input.GetButtonDown("Jump") && isGrounded)
                    {
                        if (Level01Controller.pgpaused == false)
                        {
                            AudioHelper.PlayClip2D(djumpS);
                            JStamloss = true;
                            JumpStam();
                            velocity.y = Mathf.Sqrt(jumphieght * -2f * gravity);
                        }
                    }
                }
                if (Stamina <= JumpSc)
                {
                    if (Input.GetButtonUp("Jump") && isGrounded)
                    {
                        if (Level01Controller.pgpaused == false)
                        {
                            NEStamMes = true;
                            DelayHelper.DelayAction(this, NEStamF, 1f);
                        }
                    }
                }
                if (Input.GetButtonDown("Jump") && isladder)
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        AudioHelper.PlayClip2D(djumpS);
                        isladder = false;
                        JStamloss = true;
                        JumpStam();
                        velocity.y = Mathf.Sqrt(jumphieght * -2f * gravity);
                    }
                }
            }

            if (djunlock == 1)
            {
                if (Stamina >= JumpSc)
                {
                    if (Input.GetButtonDown("Jump") && isGrounded)
                    {
                        if (Level01Controller.pgpaused == false)
                        {
                            AudioHelper.PlayClip2D(djumpS);
                            JStamloss = true;
                            JumpStam();
                            velocity.y = Mathf.Sqrt(jumphieght * -2f * gravity);
                            jumpnum = 1;
                        }
                    }
                    if (Input.GetButtonDown("Jump") && !isGrounded)
                    {
                        if (Level01Controller.pgpaused == false)
                        {
                            if (jumpnum >= 1)
                            {
                                AudioHelper.PlayClip2D(djumpS);
                                velocity.y = 0;
                                JStamloss = true;
                                JumpStam();
                                velocity.y = Mathf.Sqrt(jumphieght * -2f * gravity);
                                jumpnum = 0;
                            }
                        }
                    }
                }
                if (Stamina <= JumpSc)
                {
                    if (Input.GetButtonUp("Jump") && velocity.y < 0)
                    {
                        if (Level01Controller.pgpaused == false)
                        {
                            NEStamMes = true;
                            DelayHelper.DelayAction(this, NEStamF, 1f);
                        }
                    }
                }
                if (Input.GetButtonDown("Jump") && isladder)
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        AudioHelper.PlayClip2D(djumpS);
                        isladder = false;
                        JStamloss = true;
                        JumpStam();
                        velocity.y = Mathf.Sqrt(jumphieght * -2f * gravity);
                        jumpnum = 1;
                    }
                }
            }



            if (isladder == false)
            {
                LUStamloss = false;
                velocity.y += gravity * Time.deltaTime;
            }

            if (Level01Controller.pgpaused == false)
            {
                controller.Move(velocity * Time.deltaTime);
            }

            if (isGrounded && velocity.y < 0)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        if (Input.GetAxis("Vertical") > 0)
                        {
                            Stamloss = true;
                            pissprnt = true;
                            SetSpeed();
                            DelayHelper.DelayAction(this, BSprintfalse, .25f);
                        }
                        if (Input.GetAxis("Vertical") < 0)
                        {
                            BSprinttrue();
                            Stamloss = false;
                            pissprnt = false;
                            BStamloss = false;
                            pBStamloss = false;
                            speed = 12f;
                        }
                    }
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                BSprinttrue();
                Stamloss = false;
                pissprnt = false;
                BStamloss = false;
                pBStamloss = false;
                speed = 12f;
            }

            if (Stamina >= DodgeSc)
            {
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
                        {
                            AudioHelper.PlayClip2D(dgeS);
                            DStamloss = true;
                            Dstam();
                            dasha = true;
                            DelayHelper.DelayAction(this, dashaf, .1f);
                            //controller.Move(transform.forward * 50f * Time.deltaTime);
                        }
                    }
                }
            }

            if (dasha == true)
            {
                speed = 60;
            }

            if (Stamina <= DodgeSc && dasha == false)
            {
                //keyup
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    if (Level01Controller.pgpaused == false)
                    {
                        NEStamMes = true;
                        DelayHelper.DelayAction(this, NEStamF, 1f);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftControl) && isladder)
            {
                if (Level01Controller.pgpaused == false)
                {
                    AudioHelper.PlayClip2D(dgeS);
                    isladder = false;
                    DStamloss = true;
                    Dstam();
                    dasha = true;
                    DelayHelper.DelayAction(this, dashaf, .1f);
                    //controller.Move(transform.forward * 50f * Time.deltaTime);
                }
            }

            if (Stamloss == true && BStamloss == false)
            {
                if (isladder == false)
                {
                    if (Stamina > 0)
                    {
                        //Stamina -= 2;
                        //was1300
                        Stamina = Mathf.Clamp(Stamina - (650 * Time.deltaTime), 0.0f, MaxStamina);
                    }
                }
            }
            if (Stamloss == false)
            {
                if (Stamina < MaxStamina)
                {
                    //Stamina += 2;
                    Stamina = Mathf.Clamp(Stamina + (1300 * Time.deltaTime), 0.0f, MaxStamina);
                    //Stamina = Mathf.RoundToInt(Stamina);
                }
            }
            if (BStamloss == true)
            {
                if (isladder == false)
                {
                    if (Stamina > 0)
                    {
                        //Stamina -= 8;
                        Stamina = Mathf.Clamp(Stamina - (5200 * Time.deltaTime), 0.0f, MaxStamina);
                    }
                }
            }
            if (LUStamloss == true)
            {
                if (isladder == true)
                {
                    if (isHang == false)
                    {
                        if (Stamina > 0)
                        {
                            //Stamina -= 4;
                            Stamina = Mathf.Clamp(Stamina - (2600 * Time.deltaTime), 0.0f, MaxStamina);
                        }
                    }
                }
            }
            if (isHang == true)
            {
                if (isladder == true)
                {
                    HStamloss = true;
                }
            }
            if (isHang == false)
            {
                if (isladder == true)
                {
                    HStamloss = false;
                }
            }
            if (HStamloss == true)
            {
                if (isHang == true)
                {
                    if (isladder == true)
                    {
                        if (Stamina > 0)
                        {
                            //Stamina -= 3;
                            Stamina = Mathf.Clamp(Stamina - (2000 * Time.deltaTime), 0.0f, MaxStamina);
                        }
                    }
                }
            }
            if (Stamina < 0)
            {
                Stamina = 0;
            }
            if (Stamina < 1)
            {
                if (isladder == true)
                {
                    isladder = false;
                }
            }
            DStamina = Mathf.Round(Stamina / 40);
            DHealth = Mathf.Round(Health / 10);
            if (thvol == false)
            {
                Level01Controller.Haud = false;
                //MH
                if (Health <= MaxHealth)
                {
                    HregTimer += Time.deltaTime;
                    healing = true;
                }
            }
            if (healing == true)
            {
                if (HregTimer >= Htimetreg)
                {
                    Health = Mathf.Clamp(Health + (215 * Time.deltaTime), 0.0f, MaxHealth);
                }
            }
            if (Health == MaxHealth)
            {
                healing = false;
                HregTimer = 0;
                //heala = false;
            }
            if (thvol == true)
            {
                HVdamage();
                healing = false;
                HregTimer = 0;
            }
            if (ebdmgd == true)
            {
                Bdmged();
            }

            if (isslope == true)
            {
                if (slopeang > 45)
                {
                    //velocity.y = Mathf.Lerp(velocity.y, -50, .25f);
                    //slpvec = new Vector3(slopeang, 0, 0);
                    //100f in editor speed similar to walk or run speed in build
                    controller.Move(slpvec2 * 100f * Time.deltaTime);
                    isslope = false;
                }
            }
        }

    }
    public void SetSpeed()
    {
        if (BSprint == true)
        {
            SetBSpeed();
        }
        if (Stamina > 0 && BSprint == false)
        {
            SetRSpeed();
        }
        if (Stamina == 0 && BSprint == false)
        {
            SetWSpeed();
        }
    }
    public void SetBSpeed()
    {
        speed = BSprintsp;
        BStamloss = true;
        pBStamloss = true;
    }
    public void SetRSpeed()
    {
        speed = runspeed;
        BStamloss = false;
        pBStamloss = false;
    }
    public void SetWSpeed()
    {
        speed = 12f;
        BStamloss = false;
        pBStamloss = false;
    }
    public void BSprintfalse()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Level01Controller.pgpaused == false)
            {
                BSprint = false;
            }
        }
    }
    public void BSprinttrue()
    {
        BSprint = true;
    }
    public void HVdamage()
    {
        if (Health > 0)
        {
            if (thvol == true)
            {
                Level01Controller.Hvis = true;
                Level01Controller.Haud = true;
                healing = false;
                //Health -= Hdamage;
                //Health = 500;
                Health = Mathf.Clamp(Health - (Hdamage * Time.deltaTime), 0.0f, MaxHealth);
            }
        }
    }
    public void Bdmged()
    {
        if (Health > 0)
        {
            Level01Controller.Hvis = true;
            AudioHelper.PlayClip2D(HrtSpm);
            Health = Health - 100;
        }
        ebdmgd = false;
    }
    public void heal()
    {
        //if (Health <= MaxHealth)
        //{
        //Health += 1;
        //Health = Mathf.Clamp(Health + (2325 * Time.deltaTime), 0.0f, MaxHealth);
        healing = true;
        //}
    }
    public void JumpStam()
    {
        if (JStamloss == true)
        {
            Stamina = Stamina - JumpSc;
            JStamloss = false;
        }
    }
    public void Grabstate()
    {
        isladder = !isladder;
    }
    public void NEStamF()
    {
        NEStamMes = false;
    }
    public void Dstam()
    {
        if (DStamloss == true)
        {
            Stamina = Stamina - DodgeSc;
            DStamloss = false;
        }
    }

    public void dashaf()
    {
        dasha = false;
        speed = 12f;
    }

    void sliden()
    {
        Vector3 graydir = Vector3.down;
        if (Physics.Raycast(groundCheck.position, graydir, out gout, 3f, groundMask))
        {
            slopeang = Vector3.Angle(transform.up, gout.normal);
            //vector3 .righy worked on way
            slpvec = Vector3.Cross(Vector3.up, gout.normal);
            slpvec2 = Vector3.Cross(slpvec, gout.normal);
            //slpvec = (gout.normal);
            //Debug.Log(slpvec);
            //grnddir.eulerAngles 
        }
    }
    void isldf()
    {
        isslope = false;
    }

    }
