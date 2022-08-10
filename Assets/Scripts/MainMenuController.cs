using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioClip startSong;
    [SerializeField] Slider VolumeBar;
    [SerializeField] Slider SFXBar;
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
        VolumeBar.value = PlayerPrefs.GetFloat("pvolsv");
        SFXBar.value = PlayerPrefs.GetFloat("svolsv");
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
    }
    public void sngnumup()
    {
        //if (AudioManager.sngnum < 4)
        if (PlayerPrefs.GetFloat("songnum") < 7)
        {
            AudioManager.nlld = false;
            //AudioManager.sngnum += 1;
            PlayerPrefs.SetFloat("songnum", PlayerPrefs.GetFloat("songnum") + 1);
        }
        //if (AudioManager.sngnum == 4)
        if (PlayerPrefs.GetFloat("songnum") == 7)
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
            PlayerPrefs.SetFloat("songnum", 6);
        }
        //AudioManager.pvol = .2f;
        //testc = 500;
    }
    public void exitg()
    {
        Application.Quit();
    }
}
