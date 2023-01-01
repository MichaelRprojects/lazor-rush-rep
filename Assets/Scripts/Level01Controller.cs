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
        if (PlayerPrefs.GetFloat("songnum") < 7)
        {
            AudioManager.nlld = false;
            PlayerPrefs.SetFloat("songnum", PlayerPrefs.GetFloat("songnum") + 1);
        }
        if (PlayerPrefs.GetFloat("songnum") == 7)
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
            PlayerPrefs.SetFloat("songnum", 6);
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
            PlayerPrefs.SetFloat("songnum", 3);
            SceneManager.LoadScene("Level01A");
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
