using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioClip startSong;
    [SerializeField] Slider VolumeBar;
    [SerializeField] Slider SFXBar;
    [SerializeField] Slider MsentBar;
    [SerializeField] GameObject lv1cntbtn;
    [SerializeField] GameObject lv2cntbtn;
    [SerializeField] GameObject lv3cntbtn;
    [SerializeField] GameObject lv4cntbtn;
    [SerializeField] GameObject lv5cntbtn;
    [SerializeField] GameObject lvtutcntbtn;
    [SerializeField] GameObject lvm1cntbtn;
    [SerializeField] GameObject lvm2cntbtn;
    [SerializeField] GameObject lvm3cntbtn;
    [SerializeField] GameObject lv2grp;
    [SerializeField] GameObject lv3grp;
    [SerializeField] GameObject lv4grp;
    [SerializeField] GameObject lv5grp;
    [SerializeField] GameObject lvcgrp;
    //[SerializeField] GameObject lvm1grp;
    [SerializeField] GameObject lvm2grp;
    [SerializeField] GameObject lvm3grp;
    [SerializeField] Text highScoreTextView;
    [SerializeField] Text tracknumTextView;
    int testc = 1;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        int highScore = PlayerPrefs.GetInt("HighScore");
        //highScoreTextView.text = highScore.ToString();
        //highScoreTextView.text = testc.ToString();
        //if (startSong != null)
        //{
            //AudioManager.Instance.PlaySong(startSong);
        //}
        //VolumeBar.value = AudioManager.pvol;
        //next two had no ,1
        VolumeBar.value = PlayerPrefs.GetFloat("pvolsv", 1f);
        SFXBar.value = PlayerPrefs.GetFloat("svolsv", 1f);
        MsentBar.value = PlayerPrefs.GetFloat("msenstsv", 5f);
        if (PlayerPrefs.GetFloat("songnum") == 0)
        {
            PlayerPrefs.SetFloat("songnum", 1); 
        }

        //MIGHT FIX 0 VOLUME on 1st build ISSSUE
        //VolumeBar.value = PlayerPrefs.GetFloat("pvolsv", 1f);
        //SFXBar.value = PlayerPrefs.GetFloat("svolsv", 1f);
        //OLD if (PlayerPrefs.GetFloat("svolsv") == 0){SFXBar.value = 1;}
        //OLD if (PlayerPrefs.GetFloat("pvolsv") == 0){VolumeBar.value = 1;}
    }

    // Update is called once per frame
    void Update()
    {
        //tracknumTextView.text = AudioManager.sngnum.ToString();
        tracknumTextView.text = PlayerPrefs.GetFloat("songnum").ToString();
        //VolumeBar.value = AudioManager.pvol;
        AudioManager.pvol = VolumeBar.value;
        //AudioHelper.svol = SFXBar.value;
        PlayerPrefs.SetFloat("pvolsv", AudioManager.pvol);
        //PlayerPrefs.SetFloat("svolsv", AudioHelper.svol);
        PlayerPrefs.SetFloat("svolsv", SFXBar.value);
        PlayerPrefs.SetFloat("msenstsv", MsentBar.value);
        if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.P) && Input.GetKey(KeyCode.R))
        {
            //all should be 0
            PlayerPrefs.SetFloat("lv1c", 0);
            PlayerPrefs.SetFloat("lv1tm", 0);
            PlayerPrefs.SetFloat("lv1klnm", 0);

            PlayerPrefs.SetFloat("lv2c", 0);
            PlayerPrefs.SetFloat("lv2tm", 0);
            PlayerPrefs.SetFloat("lv2klnm", 0);

            PlayerPrefs.SetFloat("lv3c", 0);
            PlayerPrefs.SetFloat("lv3tm", 0);
            PlayerPrefs.SetFloat("lv3klnm", 0);

            PlayerPrefs.SetFloat("lv4c", 0);
            PlayerPrefs.SetFloat("lv4tm", 0);
            PlayerPrefs.SetFloat("lv4klnm", 0);

            PlayerPrefs.SetFloat("lv5c", 0);
            PlayerPrefs.SetFloat("lv5tm", 0);
            PlayerPrefs.SetFloat("lv5klnm", 0);

            PlayerPrefs.SetFloat("lvc1c", 0);
            PlayerPrefs.SetFloat("lvc1tm", 0);
            PlayerPrefs.SetFloat("lvc1klnm", 0);

            PlayerPrefs.SetFloat("lvc2c", 0);
            PlayerPrefs.SetFloat("lvc2tm", 0);
            PlayerPrefs.SetFloat("lvc2klnm", 0);

            PlayerPrefs.SetFloat("lvc3c", 0);
            PlayerPrefs.SetFloat("lvc3tm", 0);
            PlayerPrefs.SetFloat("lvc3klnm", 0);

            PlayerPrefs.SetFloat("lvtutc", 0);
            PlayerPrefs.SetFloat("lvtuttm", 0);
            PlayerPrefs.SetFloat("lvtutklnm", 0);

            PlayerPrefs.SetFloat("lvm1c", 0);
            PlayerPrefs.SetFloat("lvm1tm", 0);
            PlayerPrefs.SetFloat("lvm1klnm", 0);

            PlayerPrefs.SetFloat("lvm2c", 0);
            PlayerPrefs.SetFloat("lvm2tm", 0);
            PlayerPrefs.SetFloat("lvm2klnm", 0);

            PlayerPrefs.SetFloat("lvm3c", 0);
            PlayerPrefs.SetFloat("lvm3tm", 0);
            PlayerPrefs.SetFloat("lvm3klnm", 0);
        }
        if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.R))
        {
            PlayerPrefs.SetInt("lv2ul", 0);
            PlayerPrefs.SetInt("lv3ul", 0);
            PlayerPrefs.SetInt("lv4ul", 0);
            PlayerPrefs.SetInt("lv5ul", 0);
            PlayerPrefs.SetInt("lvchul", 0);
            PlayerPrefs.SetInt("lvm2ul", 0);
            PlayerPrefs.SetInt("lvm3ul", 0);
        }
        if (Input.GetKeyDown(KeyCode.U) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.R))
        {
            PlayerPrefs.SetInt("lv2ul", 1);
            PlayerPrefs.SetInt("lv3ul", 1);
            PlayerPrefs.SetInt("lv4ul", 1);
            PlayerPrefs.SetInt("lv5ul", 1);
            PlayerPrefs.SetInt("lvchul", 1);
            PlayerPrefs.SetInt("lvm2ul", 1);
            PlayerPrefs.SetInt("lvm3ul", 1);
        }

        if (PlayerPrefs.GetFloat("lv1c") == 0 || PlayerPrefs.GetFloat("lv1c") > 90)
        {
            lv1cntbtn.SetActive(false);
        }
        if (PlayerPrefs.GetFloat("lv1c") > 0 && PlayerPrefs.GetFloat("lv1c") < 90)
        //if (PlayerPrefs.GetFloat("lv1c") > 0 && PlayerPrefs.GetFloat("lv1c") != 0)
        {
            lv1cntbtn.SetActive(true);
        }

        if (PlayerPrefs.GetFloat("lv2c") == 0 || PlayerPrefs.GetFloat("lv2c") > 90)
        {
            lv2cntbtn.SetActive(false);
        }
        if (PlayerPrefs.GetFloat("lv2c") > 0 && PlayerPrefs.GetFloat("lv2c") < 90)
        { 
            lv2cntbtn.SetActive(true);
         }

        if (PlayerPrefs.GetFloat("lv3c") == 0 || PlayerPrefs.GetFloat("lv3c") > 90)
        {
            lv3cntbtn.SetActive(false);
        }
        if (PlayerPrefs.GetFloat("lv3c") > 0 && PlayerPrefs.GetFloat("lv3c") < 90)
        {
            lv3cntbtn.SetActive(true);
        }

        if (PlayerPrefs.GetFloat("lv4c") == 0 || PlayerPrefs.GetFloat("lv4c") > 90)
        {
            lv4cntbtn.SetActive(false);
        }
        if (PlayerPrefs.GetFloat("lv4c") > 0 && PlayerPrefs.GetFloat("lv4c") < 90)
        {
            lv4cntbtn.SetActive(true);
        }

        if (PlayerPrefs.GetFloat("lv5c") == 0 || PlayerPrefs.GetFloat("lv5c") > 90)
        {
            lv5cntbtn.SetActive(false);
        }
        if (PlayerPrefs.GetFloat("lv5c") > 0 && PlayerPrefs.GetFloat("lv5c") < 90)
        {
            lv5cntbtn.SetActive(true);
        }

        if (PlayerPrefs.GetFloat("lvtutc") == 0 || PlayerPrefs.GetFloat("lvtutc") > 90)
        {
            lvtutcntbtn.SetActive(false);
        }
        if (PlayerPrefs.GetFloat("lvtutc") > 0 && PlayerPrefs.GetFloat("lvtutc") < 90)
        {
            lvtutcntbtn.SetActive(true);
        }

        if (PlayerPrefs.GetFloat("lvm1c") == 0 || PlayerPrefs.GetFloat("lvm1c") > 90)
        {
            lvm1cntbtn.SetActive(false);
        }
        if (PlayerPrefs.GetFloat("lvm1c") > 0 && PlayerPrefs.GetFloat("lvm1c") < 90)
        {
            lvm1cntbtn.SetActive(true);
        }

        if (PlayerPrefs.GetFloat("lvm2c") == 0 || PlayerPrefs.GetFloat("lvm2c") > 90)
        {
            lvm2cntbtn.SetActive(false);
        }
        if (PlayerPrefs.GetFloat("lvm2c") > 0 && PlayerPrefs.GetFloat("lvm2c") < 90)
        {
            lvm2cntbtn.SetActive(true);
        }

        if (PlayerPrefs.GetFloat("lvm3c") == 0 || PlayerPrefs.GetFloat("lvm3c") > 90)
        {
            lvm3cntbtn.SetActive(false);
        }
        if (PlayerPrefs.GetFloat("lvm3c") > 0 && PlayerPrefs.GetFloat("lvm3c") < 90)
        {
            lvm3cntbtn.SetActive(true);
        }

        if (PlayerPrefs.GetInt("lv2ul") == 1)
        {
            lv2grp.SetActive(true);
        }
        if (PlayerPrefs.GetInt("lv2ul") != 1)
        {
            lv2grp.SetActive(false);
        }

        if (PlayerPrefs.GetInt("lv3ul") == 1)
        {
            lv3grp.SetActive(true);
        }
        if (PlayerPrefs.GetInt("lv3ul") != 1)
        {
            lv3grp.SetActive(false);
        }
        if (PlayerPrefs.GetInt("lv4ul") == 1)
        {
            lv4grp.SetActive(true);
        }
        if (PlayerPrefs.GetInt("lv4ul") != 1)
        {
            lv4grp.SetActive(false);
        }
        if (PlayerPrefs.GetInt("lv5ul") == 1)
        {
            lv5grp.SetActive(true);
        }
        if (PlayerPrefs.GetInt("lv5ul") != 1)
        {
            lv5grp.SetActive(false);
        }
        if (PlayerPrefs.GetInt("lvchul") == 1)
        {
            lvcgrp.SetActive(true);
        }
        if (PlayerPrefs.GetInt("lvchul") != 1)
        {
            lvcgrp.SetActive(false);
        }
        if (PlayerPrefs.GetInt("lvm2ul") == 1)
        {
            lvm2grp.SetActive(true);
        }
        if (PlayerPrefs.GetInt("lvm2ul") != 1)
        {
            lvm2grp.SetActive(false);
        }
        if (PlayerPrefs.GetInt("lvm3ul") == 1)
        {
            lvm3grp.SetActive(true);
        }
        if (PlayerPrefs.GetInt("lvm3ul") != 1)
        {
            lvm3grp.SetActive(false);
        }
        //Debug.Log(PlayerPrefs.GetFloat("lv1c"));
    }
    public void sngnumup()
    {
        //if (AudioManager.sngnum < 4)
        if (PlayerPrefs.GetFloat("songnum") < 10)
        {
            AudioManager.nlld = false;
            //AudioManager.sngnum += 1;
            PlayerPrefs.SetFloat("songnum", PlayerPrefs.GetFloat("songnum") + 1);
        }
        //if (AudioManager.sngnum == 4)
        if (PlayerPrefs.GetFloat("songnum") == 10)
        {
            AudioManager.nlld = false;
            //AudioManager.sngnum = 1;
            PlayerPrefs.SetFloat("songnum", 1);
        }
        //AudioManager.pvol = .2f;
        //testc = 500;
    }
    public void sngnumdwn()
    {
        //if (AudioManager.sngnum > 0)
        if (PlayerPrefs.GetFloat("songnum") > 0)
        {
            AudioManager.nlld = false;
            //AudioManager.sngnum -= 1;
            PlayerPrefs.SetFloat("songnum", PlayerPrefs.GetFloat("songnum") - 1);
        }
        //if (AudioManager.sngnum == 0)
        if (PlayerPrefs.GetFloat("songnum") == 0)
        {
            AudioManager.nlld = false;
            //AudioManager.sngnum = 3;
            PlayerPrefs.SetFloat("songnum", 9);
        }
        //AudioManager.pvol = .2f;
        //testc = 500;
    }
    //public void golev(int levnum)
    //{
    //if (levnum == 0)
    //{
    //LoadScene("Level01");
    //SceneLoader.Load
    //}

    //}
    public void resetdata()
    {
        PlayerPrefs.DeleteAll();
    }
    public void maxscreentoglle()
    {
        if (Screen.fullScreen == true)
        {
            Screen.fullScreen = false;
        }
        if (Screen.fullScreen == false)
        {
            Screen.fullScreen = true;
        }
    }
    public void exitg()
    {
        Application.Quit();
    }
}
