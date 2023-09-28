using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text currentScoreTextView;
    [SerializeField] Text vrchckrTextView;
    [SerializeField] Slider HealthBar;
    [SerializeField] Slider StaminaBar;
    [SerializeField] Slider EshldBar;
    [SerializeField] Slider ReamntBar;
    [SerializeField] Text Healthnum;
    [SerializeField] Text Staminanum;
    [SerializeField] Text Eshldnum;
    [SerializeField] Text Clipnum;
    [SerializeField] Text Testtx;
    [SerializeField] GameObject Egprompt;
    [SerializeField] GameObject Elgprompt;
    [SerializeField] GameObject Eusprompt;
    [SerializeField] GameObject bladeaviableico;
    [SerializeField] GameObject nadeaviableico;
    [SerializeField] GameObject chcksvdnt;
    [SerializeField] GameObject NEStam;
    [SerializeField] GameObject Hud;
    [SerializeField] GameObject deadr;
    [SerializeField] GameObject hurtr;
    [SerializeField] GameObject PMenu;
    [SerializeField] Slider VolumeBarb;
    [SerializeField] Slider SFXBarb;
    [SerializeField] Slider MsentBarb;
    [SerializeField] Text tracknumTextView;
    [SerializeField] GameObject gpMenu;
    [SerializeField] GameObject gpMenuOP;
    [SerializeField] GameObject gpMenuOPCN;
    [SerializeField] GameObject gpbgrnd;
    [SerializeField] Transform Pl;
    [SerializeField] Transform chckpointaspwn;
    [SerializeField] Transform chckpointbspwn;
    [SerializeField] Transform chckpointcspwn;
    [SerializeField] Transform chckpointdspwn;
    [SerializeField] Transform chckpointespwn;
    [SerializeField] AudioClip HrtS = null;
    [SerializeField] AudioClip lsngS = null;
    [SerializeField] AudioClip DthS = null;
    [SerializeField] AudioClip PsmnS = null;
    public static int currentScore;
    public static bool respawn = true;
    public static bool Hvis = false;
    public static bool Haud = false;
    public static bool eusepr = false;
    public static bool offchcknt = true;
    public bool iststlv;
    public bool islv1;
    public bool islv2;
    public bool islv3;
    public bool islv4;
    public bool islv5;
    public bool islvc1;
    public bool islvc2;
    public static bool pstbislvc2;
    public bool islvc3;
    public bool islvtut;
    public bool islvm1;
    public bool islvm2;
    public bool islvm3;
    //public bool islv4;
    //public bool islv5;
    public static float chckpntcntr;
    public static int timrcnum;
    bool hauds = false;
    bool pdsin = true;
    public static bool pgpaused = false;
    public static bool youwin = false;

    public void Awake()
    {
        respawn = false;
        pgpaused = false;
        youwin = false;
        //Pl = GameObject.Find("Player").transform;
        //Pl.transform.position = chckpointaspwn.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        //Debug.Log(AudioManager.sngnum);
        //Debug.Log(PlayerPrefs.GetFloat("songnum"));
        //AudioManager.sngnum = 1;
        VolumeBarb.value = PlayerPrefs.GetFloat("pvolsv");
        SFXBarb.value = PlayerPrefs.GetFloat("svolsv");
        MsentBarb.value = PlayerPrefs.GetFloat("msenstsv", 5f);

        //Pl = GameObject.Find("Player").transform;
        pstbislvc2 = false;

        if (bladeaviableico != null)
        {
            bladeaviableico.SetActive(true);
        }
        if (nadeaviableico != null)
        {
            nadeaviableico.SetActive(true);
        }
        //Eusprompt.SetActive(false);

        if (iststlv)
        {
            chckpntcntr = PlayerPrefs.GetFloat("tstlvc");
            timrcnum = 0;
        }
        if (islv1)
        {
            chckpntcntr = PlayerPrefs.GetFloat("lv1c");
            timrcnum = 1;
        }
        if (islv2)
        {
            chckpntcntr = PlayerPrefs.GetFloat("lv2c");
            timrcnum = 2;
        }
        if (islv3)
        {
            chckpntcntr = PlayerPrefs.GetFloat("lv3c");
            timrcnum = 3;
        }
        if (islv4)
        {
            chckpntcntr = PlayerPrefs.GetFloat("lv4c");
            timrcnum = 4;
        }
        if (islv5)
        {
            chckpntcntr = PlayerPrefs.GetFloat("lv5c");
            timrcnum = 5;
        }
        if (islvc1)
        {
            chckpntcntr = PlayerPrefs.GetFloat("lvc1c");
            timrcnum = 6;
        }
        if (islvc2)
        {
            chckpntcntr = PlayerPrefs.GetFloat("lvc2c");
            pstbislvc2 = islvc2;
            timrcnum = 7;
        }
        if (islvc3)
        {
            chckpntcntr = PlayerPrefs.GetFloat("lvc3c");
            timrcnum = 8;
        }
        if (islvtut)
        {
            chckpntcntr = PlayerPrefs.GetFloat("lvtutc");
            timrcnum = 9;
        }
        if (islvm1)
        {
            chckpntcntr = PlayerPrefs.GetFloat("lvm1c");
            timrcnum = 10;
        }
        if (islvm2)
        {
            chckpntcntr = PlayerPrefs.GetFloat("lvm2c");
            timrcnum = 11;
        }
        if (islvm3)
        {
            chckpntcntr = PlayerPrefs.GetFloat("lvm3c");
            timrcnum = 12;
        }
        if (chckpntcntr == 1)
        {
            Pl = GameObject.Find("Player").transform;
        CharacterController ccp = Pl.GetComponent<CharacterController>();
        ccp.enabled = false;
            Pl.transform.position = chckpointaspwn.transform.position;
            Pl.transform.rotation = chckpointaspwn.transform.rotation;
            ccp.enabled = true;
        }
        if (chckpntcntr == 2)
        {
            Pl = GameObject.Find("Player").transform;
            CharacterController ccp = Pl.GetComponent<CharacterController>();
            ccp.enabled = false;
            Pl.transform.position = chckpointbspwn.transform.position;
            Pl.transform.rotation = chckpointbspwn.transform.rotation;
            ccp.enabled = true;
        }
        if (chckpntcntr == 3)
        {
            Pl = GameObject.Find("Player").transform;
            CharacterController ccp = Pl.GetComponent<CharacterController>();
            ccp.enabled = false;
            Pl.transform.position = chckpointcspwn.transform.position;
            Pl.transform.rotation = chckpointcspwn.transform.rotation;
            ccp.enabled = true;
        }
        if (chckpntcntr == 4)
        {
            Pl = GameObject.Find("Player").transform;
            CharacterController ccp = Pl.GetComponent<CharacterController>();
            ccp.enabled = false;
            Pl.transform.position = chckpointdspwn.transform.position;
            Pl.transform.rotation = chckpointdspwn.transform.rotation;
            ccp.enabled = true;
        }
        if (chckpntcntr == 5)
        {
            Pl = GameObject.Find("Player").transform;
            CharacterController ccp = Pl.GetComponent<CharacterController>();
            ccp.enabled = false;
            Pl.transform.position = chckpointespwn.transform.position;
            Pl.transform.rotation = chckpointespwn.transform.rotation;
            ccp.enabled = true;
        }

        //if (iststlv)
        //{
        //PlayerPrefs.SetFloat("songnum", 2);
        //}
        //if (islv1)
        //{
        //PlayerPrefs.SetFloat("songnum", 1);
        //}

        //AudioManager.sngnum = 1;
        //Debug.Log(PlayerPrefs.GetFloat("songnum"));
        //Debug.Log(AudioManager.sngnum);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //IncreaseScore(5);
            //currentScore += 5;
            //PlayerPrefs.SetFloat("songnum", 1);
            //Debug.Log(PlayerPrefs.GetFloat("songnum"));

            //PlayerPrefs.SetFloat("tstlvc", 0);
            //PlayerPrefs.SetFloat("lv1c", 0);
            //chckpntcntr = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //ExitLevel();
            if (youwin == false)
            {
                AudioHelper.PlayClip2D(PsmnS);
                pgpaused = !pgpaused;
            }
        }
        HealthBar.value = PMovement.Health;
        StaminaBar.value = PMovement.Stamina;
        EshldBar.value = Melee.Deshield;
        ReamntBar.value = Melee.reamnt;
        Healthnum.text =
            PMovement.DHealth.ToString();
        Staminanum.text =
            PMovement.DStamina.ToString();
        Eshldnum.text =
            Melee.Deshield.ToString();
        //Testtx.text =
            //EnemyS.attcamnt.ToString();
        Clipnum.text =
           Shooting.clip.ToString() + "/" + Shooting.mclip.ToString();

        //currentScoreTextView.text =
           //"Score: " + currentScore.ToString();
        //currentScoreTextView.text =
           //"chckc" + chckpntcntr.ToString();
        //vrchckrTextView.text =
           //"lvtc" + PlayerPrefs.GetFloat("tstlvc").ToString() + "lvc1" + PlayerPrefs.GetFloat("lv1c").ToString();

        if (PMovement.isladdera == true)
        {
                Egprompt.SetActive(true);
        }
        if (PMovement.isladder == true || PMovement.isladdera == false)
        {
            Egprompt.SetActive(false);
        }
        if (PMovement.NEStamMes == true)
        {
            NEStam.SetActive(true);
        }
        if (PMovement.NEStamMes == false)
        {
            NEStam.SetActive(false);
        }
        if (Melee.bldua == false)
        {
            if (bladeaviableico != null)
            {
                bladeaviableico.SetActive(true);
            }
        }
        if (Melee.gunua == false)
        {
            if (nadeaviableico != null)
            {
                nadeaviableico.SetActive(true);
            }
        }
        if (Melee.bldua == true)
        {
            if (bladeaviableico != null)
            {
                bladeaviableico.SetActive(false);
            }
        }
        if (Melee.gunua == true)
        {
            if (nadeaviableico != null)
            {
                nadeaviableico.SetActive(false);
            }
        }
            //Debug.Log(eusepr);
        if (eusepr == true)
        {
            Eusprompt.SetActive(true);
        }
        if (eusepr == false)
        {
            Eusprompt.SetActive(false);
        }
        if (Hvis == true)
        {
            hurtr.SetActive(true);
            DelayHelper.DelayAction(this, hvisoff, .25f);
        }
        if (PMovement.isdead == false)
        {
            if (Haud == true)
            {
                if (hauds == false)
                {
                    haudon();
                    DelayHelper.DelayAction(this, haudsf, .5f);
                }
                //DelayHelper.DelayAction(this, haudon, .01f);
                //haudon();
            }
        }
        if (PMovement.isdead == true)
        {
            Hud.SetActive(false);
            deadr.SetActive(true);
            PMenu.SetActive(true);
            if (pdsin == true)
            {
                AudioHelper.PlayClip2D(DthS);
                pdsin = false;
            }
        }
        if (PMovement.isdead == false)
        {
            Hud.SetActive(true);
            deadr.SetActive(false);
            PMenu.SetActive(false);
        }
        AudioManager.pvol = VolumeBarb.value;
        PlayerPrefs.SetFloat("pvolsv", AudioManager.pvol);
        PlayerPrefs.SetFloat("svolsv", SFXBarb.value);
        PlayerPrefs.SetFloat("msenstsv", MsentBarb.value);
        tracknumTextView.text = PlayerPrefs.GetFloat("songnum").ToString();
        if (pgpaused == true)
        {
            Time.timeScale = 0;
            gpbgrnd.SetActive(true);
            gpMenu.SetActive(true);
        }
        if (pgpaused == false)
        {
            Time.timeScale = 1;
            gpbgrnd.SetActive(false);
            gpMenu.SetActive(false);
            gpMenuOP.SetActive(false);
            gpMenuOPCN.SetActive(false);
        }

        if (iststlv)
        {
            PlayerPrefs.SetFloat("tstlvc", chckpntcntr);
        }
        if (islv1)
        {
            PlayerPrefs.SetFloat("lv1c", chckpntcntr);
        }
        if (islv2)
        {
            PlayerPrefs.SetFloat("lv2c", chckpntcntr);
        }
        if (islv3)
        {
            PlayerPrefs.SetFloat("lv3c", chckpntcntr);
        }
        if (islv4)
        {
            PlayerPrefs.SetFloat("lv4c", chckpntcntr);
        }
        if (islv5)
        {
            PlayerPrefs.SetFloat("lv5c", chckpntcntr);
        }
        if (islvc1)
        {
            PlayerPrefs.SetFloat("lvc1c", chckpntcntr);
        }
        if (islvc2)
        {
            PlayerPrefs.SetFloat("lvc2c", chckpntcntr);
        }
        if (islvc3)
        {
            PlayerPrefs.SetFloat("lvc3c", chckpntcntr);
        }
        if (islvtut)
        {
            PlayerPrefs.SetFloat("lvtutc", chckpntcntr);
        }
        if (islvm1)
        {
            PlayerPrefs.SetFloat("lvm1c", chckpntcntr);
        }
        if (islvm2)
        {
            PlayerPrefs.SetFloat("lvm2c", chckpntcntr);
        }
        if (islvm3)
        {
            PlayerPrefs.SetFloat("lvm3c", chckpntcntr);
        }
        if (offchcknt == true)
        {
            chcksvdnt.SetActive(false);
        }
        if (offchcknt == false)
        {
            chcksvdnt.SetActive(true);
            DelayHelper.DelayAction(this, rmvchcknt, 2f);
        }
        if (youwin == true)
        {
            pgpaused = true;
        }
    }
    //public void IncreaseScore(int scoreIncrease)
    //{
        //currentScore += scoreIncrease;
        //currentScoreTextView.text =
            //"Score: " + currentScore.ToString(); 
    //}
    public void hvisoff()
    {
        Hvis = false;
        hurtr.SetActive(false);
    }
    public void haudon()
    {
        AudioHelper.PlayClip2D(HrtS);
        if (PMovement.thvol == true)
        {
            AudioHelper.PlayClip2D(lsngS);
        }
        hauds = true;
    }
    public void haudsf()
    {
        hauds = false;
    }
    public void sngnumup()
    {
        if (PlayerPrefs.GetFloat("songnum") < 10)
        {
            AudioManager.nlld = false;
            PlayerPrefs.SetFloat("songnum", PlayerPrefs.GetFloat("songnum") + 1);
        }
        if (PlayerPrefs.GetFloat("songnum") == 10)
        {
            AudioManager.nlld = false;
            PlayerPrefs.SetFloat("songnum", 1);
        }
    }
    public void sngnumdwn()
    {
        if (PlayerPrefs.GetFloat("songnum") > 0)
        {
            AudioManager.nlld = false;
            PlayerPrefs.SetFloat("songnum", PlayerPrefs.GetFloat("songnum") - 1);
        }
        if (PlayerPrefs.GetFloat("songnum") == 0)
        {
            AudioManager.nlld = false;
            PlayerPrefs.SetFloat("songnum", 9);
        }
    }
    public void ExitLevel()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
        SceneManager.LoadScene("MainMenu");
    }
    public void RlLevel()
    {
        respawn = true;
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
        if (iststlv)
        {
           SceneManager.LoadScene("Level01");
        }
        if (islv1)
        {
            SceneManager.LoadScene("Level01A");
        }
        if (islv2)
        {
            SceneManager.LoadScene("Level01B");
        }
        if (islv3)
        {
            SceneManager.LoadScene("Level01C");
        }
        if (islv4)
        {
            SceneManager.LoadScene("Level01D");
        }
        if (islv5)
        {
            SceneManager.LoadScene("Level01E");
        }
        if (islvc1)
        {
            SceneManager.LoadScene("Level01FA");
        }
        if (islvc2)
        {
            SceneManager.LoadScene("Level01FB");
        }
        if (islvc3)
        {
            SceneManager.LoadScene("Level01FC");
        }
        if (islvtut)
        {
            SceneManager.LoadScene("Level01T");
        }
        if (islvm1)
        {
            SceneManager.LoadScene("Level01M1");
        }
        if (islvm2)
        {
            SceneManager.LoadScene("Level01M2");
        }
        if (islvm3)
        {
            SceneManager.LoadScene("Level01M3");
        }
    }
    public void Resume()
    {
        if (youwin == false)
        {
            AudioHelper.PlayClip2D(PsmnS);
            pgpaused = false;
        }
    }
    public void rmvchcknt()
    {
        offchcknt = true;
    }
    public static void timerc(float tmrcd, float curtm)
    {
        if (timrcnum == 0)
        {
            curtm = PlayerPrefs.GetFloat("tstlvtm");
            PlayerPrefs.SetFloat("tstlvtm", curtm += tmrcd);
        }
        if (timrcnum == 1)
        {
            curtm = PlayerPrefs.GetFloat("lv1tm");
            PlayerPrefs.SetFloat("lv1tm", curtm += tmrcd);
        }
        if (timrcnum == 2)
        {
            curtm = PlayerPrefs.GetFloat("lv2tm");
            PlayerPrefs.SetFloat("lv2tm", curtm += tmrcd);
        }
        if (timrcnum == 3)
        {
            curtm = PlayerPrefs.GetFloat("lv3tm");
            PlayerPrefs.SetFloat("lv3tm", curtm += tmrcd);
        }
        if (timrcnum == 4)
        {
            curtm = PlayerPrefs.GetFloat("lv4tm");
            PlayerPrefs.SetFloat("lv4tm", curtm += tmrcd);
        }
        if (timrcnum == 5)
        {
            curtm = PlayerPrefs.GetFloat("lv5tm");
            PlayerPrefs.SetFloat("lv5tm", curtm += tmrcd);
        }
        if (timrcnum == 6)
        {
            curtm = PlayerPrefs.GetFloat("lvc1tm");
            PlayerPrefs.SetFloat("lvc1tm", curtm += tmrcd);
        }
        if (timrcnum == 7)
        {
            curtm = PlayerPrefs.GetFloat("lvc2tm");
            PlayerPrefs.SetFloat("lvc2tm", curtm += tmrcd);
        }
        if (timrcnum == 8)
        {
            curtm = PlayerPrefs.GetFloat("lvc3tm");
            PlayerPrefs.SetFloat("lvc3tm", curtm += tmrcd);
        }
        if (timrcnum == 9)
        {
            curtm = PlayerPrefs.GetFloat("lvtuttm");
            PlayerPrefs.SetFloat("lvtuttm", curtm += tmrcd);
        }
        if (timrcnum == 10)
        {
            curtm = PlayerPrefs.GetFloat("lvm1tm");
            PlayerPrefs.SetFloat("lvm1tm", curtm += tmrcd);
        }
        if (timrcnum == 11)
        {
            curtm = PlayerPrefs.GetFloat("lvm2tm");
            PlayerPrefs.SetFloat("lvm2tm", curtm += tmrcd);
        }
        if (timrcnum == 12)
        {
            curtm = PlayerPrefs.GetFloat("lvm3tm");
            PlayerPrefs.SetFloat("lvm3tm", curtm += tmrcd);
        }
    }
    public static void distim()
    {
        if (timrcnum == 0)
        {
            Timer.minut = ((int)PlayerPrefs.GetFloat("tstlvtm") / 60).ToString();
            if (PlayerPrefs.GetFloat("tstlvtm") % 60 >= 10)
            {
                Timer.secon = (PlayerPrefs.GetFloat("tstlvtm") % 60).ToString("f2");
            }
            if (PlayerPrefs.GetFloat("tstlvtm") % 60 < 10)
            {
                Timer.secon = "0" + (PlayerPrefs.GetFloat("tstlvtm") % 60).ToString("f2");
            }
        }
        if (timrcnum == 1)
        {
            Timer.minut = ((int)PlayerPrefs.GetFloat("lv1tm") / 60).ToString();
            if (PlayerPrefs.GetFloat("lv1tm") % 60 >= 10)
            {
                Timer.secon = (PlayerPrefs.GetFloat("lv1tm") % 60).ToString("f2");
            }
            if (PlayerPrefs.GetFloat("lv1tm") % 60 < 10)
            {
                Timer.secon = "0" + (PlayerPrefs.GetFloat("lv1tm") % 60).ToString("f2");
            }
        }
        if (timrcnum == 2)
        {
            Timer.minut = ((int)PlayerPrefs.GetFloat("lv2tm") / 60).ToString();
            if (PlayerPrefs.GetFloat("lv2tm") % 60 >= 10)
            {
                Timer.secon = (PlayerPrefs.GetFloat("lv2tm") % 60).ToString("f2");
            }
            if (PlayerPrefs.GetFloat("lv2tm") % 60 < 10)
            {
                Timer.secon = "0" + (PlayerPrefs.GetFloat("lv2tm") % 60).ToString("f2");
            }
        }
        if (timrcnum == 3)
        {
            Timer.minut = ((int)PlayerPrefs.GetFloat("lv3tm") / 60).ToString();
            if (PlayerPrefs.GetFloat("lv3tm") % 60 >= 10)
            {
                Timer.secon = (PlayerPrefs.GetFloat("lv3tm") % 60).ToString("f2");
            }
            if (PlayerPrefs.GetFloat("lv3tm") % 60 < 10)
            {
                Timer.secon = "0" + (PlayerPrefs.GetFloat("lv3tm") % 60).ToString("f2");
            }
        }
        if (timrcnum == 4)
        {
            Timer.minut = ((int)PlayerPrefs.GetFloat("lv4tm") / 60).ToString();
            if (PlayerPrefs.GetFloat("lv4tm") % 60 >= 10)
            {
                Timer.secon = (PlayerPrefs.GetFloat("lv4tm") % 60).ToString("f2");
            }
            if (PlayerPrefs.GetFloat("lv4tm") % 60 < 10)
            {
                Timer.secon = "0" + (PlayerPrefs.GetFloat("lv4tm") % 60).ToString("f2");
            }
        }
        if (timrcnum == 5)
        {
            Timer.minut = ((int)PlayerPrefs.GetFloat("lv5tm") / 60).ToString();
            if (PlayerPrefs.GetFloat("lv5tm") % 60 >= 10)
            {
                Timer.secon = (PlayerPrefs.GetFloat("lv5tm") % 60).ToString("f2");
            }
            if (PlayerPrefs.GetFloat("lv5tm") % 60 < 10)
            {
                Timer.secon = "0" + (PlayerPrefs.GetFloat("lv5tm") % 60).ToString("f2");
            }
        }
        if (timrcnum == 6)
        {
            Timer.minut = ((int)PlayerPrefs.GetFloat("lvc1tm") / 60).ToString();
            if (PlayerPrefs.GetFloat("lvc1tm") % 60 >= 10)
            {
                Timer.secon = (PlayerPrefs.GetFloat("lvc1tm") % 60).ToString("f2");
            }
            if (PlayerPrefs.GetFloat("lvc1tm") % 60 < 10)
            {
                Timer.secon = "0" + (PlayerPrefs.GetFloat("lvc1tm") % 60).ToString("f2");
            }
        }
        if (timrcnum == 7)
        {
            Timer.minut = ((int)PlayerPrefs.GetFloat("lvc2tm") / 60).ToString();
            if (PlayerPrefs.GetFloat("lvc2tm") % 60 >= 10)
            {
                Timer.secon = (PlayerPrefs.GetFloat("lvc2tm") % 60).ToString("f2");
            }
            if (PlayerPrefs.GetFloat("lvc2tm") % 60 < 10)
            {
                Timer.secon = "0" + (PlayerPrefs.GetFloat("lvc2tm") % 60).ToString("f2");
            }
        }
        if (timrcnum == 8)
        {
            Timer.minut = ((int)PlayerPrefs.GetFloat("lvc3tm") / 60).ToString();
            if (PlayerPrefs.GetFloat("lvc3tm") % 60 >= 10)
            {
                Timer.secon = (PlayerPrefs.GetFloat("lvc3tm") % 60).ToString("f2");
            }
            if (PlayerPrefs.GetFloat("lvc3tm") % 60 < 10)
            {
                Timer.secon = "0" + (PlayerPrefs.GetFloat("lvc3tm") % 60).ToString("f2");
            }
        }
        if (timrcnum == 9)
        {
            Timer.minut = ((int)PlayerPrefs.GetFloat("lvtuttm") / 60).ToString();
            if (PlayerPrefs.GetFloat("lvtuttm") % 60 >= 10)
            {
                Timer.secon = (PlayerPrefs.GetFloat("lvtuttm") % 60).ToString("f2");
            }
            if (PlayerPrefs.GetFloat("lvtuttm") % 60 < 10)
            {
                Timer.secon = "0" + (PlayerPrefs.GetFloat("lvtuttm") % 60).ToString("f2");
            }
        }
        if (timrcnum == 10)
        {
            Timer.minut = ((int)PlayerPrefs.GetFloat("lvm1tm") / 60).ToString();
            if (PlayerPrefs.GetFloat("lvm1tm") % 60 >= 10)
            {
                Timer.secon = (PlayerPrefs.GetFloat("lvm1tm") % 60).ToString("f2");
            }
            if (PlayerPrefs.GetFloat("lvm1tm") % 60 < 10)
            {
                Timer.secon = "0" + (PlayerPrefs.GetFloat("lvm1tm") % 60).ToString("f2");
            }
        }
        if (timrcnum == 11)
        {
            Timer.minut = ((int)PlayerPrefs.GetFloat("lvm2tm") / 60).ToString();
            if (PlayerPrefs.GetFloat("lvm2tm") % 60 >= 10)
            {
                Timer.secon = (PlayerPrefs.GetFloat("lvm2tm") % 60).ToString("f2");
            }
            if (PlayerPrefs.GetFloat("lvm2tm") % 60 < 10)
            {
                Timer.secon = "0" + (PlayerPrefs.GetFloat("lvm2tm") % 60).ToString("f2");
            }
        }
        if (timrcnum == 12)
        {
            Timer.minut = ((int)PlayerPrefs.GetFloat("lvm3tm") / 60).ToString();
            if (PlayerPrefs.GetFloat("lvm3tm") % 60 >= 10)
            {
                Timer.secon = (PlayerPrefs.GetFloat("lvm3tm") % 60).ToString("f2");
            }
            if (PlayerPrefs.GetFloat("lvm3tm") % 60 < 10)
            {
                Timer.secon = "0" + (PlayerPrefs.GetFloat("lvm3tm") % 60).ToString("f2");
            }
        }
    }
    public static void klnmrc(float klnmrcd, float curklnm)
    {
        if (timrcnum == 0)
        {
            curklnm = PlayerPrefs.GetFloat("tstlvklnm");
            PlayerPrefs.SetFloat("tstlvklnm", curklnm += klnmrcd);
            Timer.klltl = PlayerPrefs.GetFloat("tstlvklnm");
        }
        if (timrcnum == 1)
        {
            curklnm = PlayerPrefs.GetFloat("lv1klnm");
            PlayerPrefs.SetFloat("lv1klnm", curklnm += klnmrcd);
            Timer.klltl = PlayerPrefs.GetFloat("lv1klnm");
        }
        if (timrcnum == 2)
        {
            curklnm = PlayerPrefs.GetFloat("lv2klnm");
            PlayerPrefs.SetFloat("lv2klnm", curklnm += klnmrcd);
            Timer.klltl = PlayerPrefs.GetFloat("lv2klnm");
        }
        if (timrcnum == 3)
        {
            curklnm = PlayerPrefs.GetFloat("lv3klnm");
            PlayerPrefs.SetFloat("lv3klnm", curklnm += klnmrcd);
            Timer.klltl = PlayerPrefs.GetFloat("lv3klnm");
        }
        if (timrcnum == 4)
        {
            curklnm = PlayerPrefs.GetFloat("lv4klnm");
            PlayerPrefs.SetFloat("lv4klnm", curklnm += klnmrcd);
            Timer.klltl = PlayerPrefs.GetFloat("lv4klnm");
        }
        if (timrcnum == 5)
        {
            curklnm = PlayerPrefs.GetFloat("lv5klnm");
            PlayerPrefs.SetFloat("lv5klnm", curklnm += klnmrcd);
            Timer.klltl = PlayerPrefs.GetFloat("lv5klnm");
        }
        if (timrcnum == 6)
        {
            curklnm = PlayerPrefs.GetFloat("lvc1klnm");
            PlayerPrefs.SetFloat("lvc1klnm", curklnm += klnmrcd);
            Timer.klltl = PlayerPrefs.GetFloat("lvc1klnm");
        }
        if (timrcnum == 7)
        {
            curklnm = PlayerPrefs.GetFloat("lvc2klnm");
            PlayerPrefs.SetFloat("lvc2klnm", curklnm += klnmrcd);
            Timer.klltl = PlayerPrefs.GetFloat("lvc2klnm");
        }
        if (timrcnum == 8)
        {
            curklnm = PlayerPrefs.GetFloat("lvc3klnm");
            PlayerPrefs.SetFloat("lvc3klnm", curklnm += klnmrcd);
            Timer.klltl = PlayerPrefs.GetFloat("lvc3klnm");
        }
        if (timrcnum == 9)
        {
            curklnm = PlayerPrefs.GetFloat("lvtutklnm");
            PlayerPrefs.SetFloat("lvtutklnm", curklnm += klnmrcd);
            Timer.klltl = PlayerPrefs.GetFloat("lvtutklnm");
        }
        if (timrcnum == 10)
        {
            curklnm = PlayerPrefs.GetFloat("lvm1klnm");
            PlayerPrefs.SetFloat("lvm1klnm", curklnm += klnmrcd);
            Timer.klltl = PlayerPrefs.GetFloat("lvm1klnm");
        }
        if (timrcnum == 11)
        {
            curklnm = PlayerPrefs.GetFloat("lvm2klnm");
            PlayerPrefs.SetFloat("lvm2klnm", curklnm += klnmrcd);
            Timer.klltl = PlayerPrefs.GetFloat("lvm2klnm");
        }
        if (timrcnum == 12)
        {
            curklnm = PlayerPrefs.GetFloat("lvm3klnm");
            PlayerPrefs.SetFloat("lvm3klnm", curklnm += klnmrcd);
            Timer.klltl = PlayerPrefs.GetFloat("lvm3klnm");
        }
    }
    public void golev()
    {
        if (islv1)
        {
            PlayerPrefs.SetFloat("songnum", 4);
            SceneManager.LoadScene("Level01B");
        }
        if (islv2)
        {
            PlayerPrefs.SetFloat("songnum", 2);
            SceneManager.LoadScene("Level01C");
        }
        if (islv3)
        {
            PlayerPrefs.SetFloat("songnum", 1);
            SceneManager.LoadScene("Level01D");
        }
        if (islv4)
        {
            PlayerPrefs.SetFloat("songnum", 5);
            SceneManager.LoadScene("Level01E");
        }
        if (islv5)
        {
            PlayerPrefs.SetFloat("songnum", 7);
            SceneManager.LoadScene("Level01M1");
        }
        if (islvtut)
        {
            PlayerPrefs.SetFloat("songnum", 3);
            SceneManager.LoadScene("Level01A");
        }
        if (islvm1)
        {
            PlayerPrefs.SetFloat("songnum", 8);
            SceneManager.LoadScene("Level01M2");
        }
        if (islvm2)
        {
            PlayerPrefs.SetFloat("songnum", 9);
            SceneManager.LoadScene("Level01M3");
        }
        if (islvm3)
        {
            PlayerPrefs.SetFloat("songnum", 6);
            SceneManager.LoadScene("Level01M1");
        }
    }
    public static void unlclev()
    {
        if (timrcnum == 1)
        {
            PlayerPrefs.SetInt("lv2ul", 1);
        }
        if (timrcnum == 2)
        {
            PlayerPrefs.SetInt("lv3ul", 1);
        }
        if (timrcnum == 3)
        {
            PlayerPrefs.SetInt("lv4ul", 1);
        }
        if (timrcnum == 4)
        {
            PlayerPrefs.SetInt("lv5ul", 1);
        }
        if (timrcnum == 5)
        {
            PlayerPrefs.SetInt("lvchul", 1);
        }
        if (timrcnum == 10)
        {
            PlayerPrefs.SetInt("lvm2ul", 1);
        }
        if (timrcnum == 11)
        {
            PlayerPrefs.SetInt("lvm3ul", 1);
        }
    }
        //public static void disklnm()
        //{
        //if (timrcnum == 0)
        //{
        //Timer.minut = ((int)PlayerPrefs.GetFloat("tstlvtm") / 60).ToString();
        //Timer.secon = (PlayerPrefs.GetFloat("tstlvtm") % 60).ToString("f2");
        //}
        //}
}
