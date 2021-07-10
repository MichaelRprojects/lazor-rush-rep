using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text currentScoreTextView;
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
    [SerializeField] GameObject NEStam;
    [SerializeField] GameObject Hud;
    [SerializeField] GameObject deadr;
    [SerializeField] GameObject hurtr;
    [SerializeField] GameObject PMenu;
    [SerializeField] GameObject gpMenu;
    [SerializeField] GameObject gpbgrnd;
    [SerializeField] AudioClip HrtS = null;
    [SerializeField] AudioClip lsngS = null;
    [SerializeField] AudioClip DthS = null;
    [SerializeField] AudioClip PsmnS = null;
    public static int currentScore;
    public static bool respawn = true;
    public static bool Hvis = false;
    public static bool Haud = false;
    bool hauds = false;
    bool pdsin = true;
    public static bool pgpaused = false;

    public void Awake()
    {
        respawn = false;
        pgpaused = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //IncreaseScore(5);
            //currentScore += 5;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //ExitLevel();
            AudioHelper.PlayClip2D(PsmnS);
            pgpaused = !pgpaused;
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

        currentScoreTextView.text =
           "Score: " + currentScore.ToString();

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
        SceneManager.LoadScene("Level01");
    }
    public void Resume()
    {
        AudioHelper.PlayClip2D(PsmnS);
        pgpaused = false;
    }
}
