using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    //public void LoadScene(string sceneName, bool iscountin)
    {
        //PlayerPrefs.SetFloat("songnum", 1);
        if (sceneName == "Level01")
        {
            PlayerPrefs.SetFloat("songnum", 2);
            PlayerPrefs.SetFloat("tstlvc", 0);
            //if (iscountin == false)
            //{
            PlayerPrefs.SetFloat("tstlvtm", 0);
                PlayerPrefs.SetFloat("tstlvklnm", 0);
            //}
        }
        if (sceneName == "Level01A")
        {
            PlayerPrefs.SetFloat("songnum", 3);
            PlayerPrefs.SetFloat("lv1c", 0);
            //if (iscountin == false)
            //{
            PlayerPrefs.SetFloat("lv1tm", 0);
                PlayerPrefs.SetFloat("lv1klnm", 0);
            //}
        }
        if (sceneName == "Level01B")
        {
            PlayerPrefs.SetFloat("songnum", 4);
            PlayerPrefs.SetFloat("lv2c", 0);
            //if (iscountin == false)
            //{
            PlayerPrefs.SetFloat("lv2tm", 0);
            PlayerPrefs.SetFloat("lv2klnm", 0);
            //}
        }
        if (sceneName == "Level01C")
        {
            PlayerPrefs.SetFloat("songnum", 2);
            PlayerPrefs.SetFloat("lv3c", 0);
            PlayerPrefs.SetFloat("lv3tm", 0);
            PlayerPrefs.SetFloat("lv3klnm", 0);
        }
        SceneManager.LoadScene(sceneName);
        
    }
    //public void LoadScene(string sceneName)
    //public void LoadScene2(string sceneName, bool iscountin)
    public void LoadSceneC(string sceneName)
    {
        PlayerPrefs.SetFloat("songnum", 1);
        if (sceneName == "Level01")
        {
            PlayerPrefs.SetFloat("songnum", 2);
            //if (iscountin == false)
            //{
            //PlayerPrefs.SetFloat("tstlvtm", 0);
            //PlayerPrefs.SetFloat("tstlvklnm", 0);
            //}
        }
        if (sceneName == "Level01A")
        {
            PlayerPrefs.SetFloat("songnum", 3);
            //if (iscountin == false)
            //{
            //PlayerPrefs.SetFloat("lv1tm", 0);
            //PlayerPrefs.SetFloat("lv1klnm", 0);
            //}
        }
        if (sceneName == "Level01B")
        {
            PlayerPrefs.SetFloat("songnum", 4);
        }
        if (sceneName == "Level01C")
        {
            PlayerPrefs.SetFloat("songnum", 2);
        }
        SceneManager.LoadScene(sceneName);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
