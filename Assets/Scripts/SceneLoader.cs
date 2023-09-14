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
        if (sceneName == "Level01D")
        {
            PlayerPrefs.SetFloat("songnum", 1);
            PlayerPrefs.SetFloat("lv4c", 0);
            PlayerPrefs.SetFloat("lv4tm", 0);
            PlayerPrefs.SetFloat("lv4klnm", 0);
        }
        if (sceneName == "Level01E")
        {
            PlayerPrefs.SetFloat("songnum", 5);
            PlayerPrefs.SetFloat("lv5c", 0);
            PlayerPrefs.SetFloat("lv5tm", 0);
            PlayerPrefs.SetFloat("lv5klnm", 0);
        }
        if (sceneName == "Level01FA")
        {
            PlayerPrefs.SetFloat("songnum", 3);
            PlayerPrefs.SetFloat("lvc1c", 0);
            PlayerPrefs.SetFloat("lvc1tm", 0);
            PlayerPrefs.SetFloat("lvc1klnm", 0);
        }
        if (sceneName == "Level01FB")
        {
            PlayerPrefs.SetFloat("songnum", 3);
            PlayerPrefs.SetFloat("lvc2c", 0);
            PlayerPrefs.SetFloat("lvc2tm", 0);
            PlayerPrefs.SetFloat("lvc2klnm", 0);
        }
        if (sceneName == "Level01FC")
        {
            PlayerPrefs.SetFloat("songnum", 3);
            PlayerPrefs.SetFloat("lvc3c", 0);
            PlayerPrefs.SetFloat("lvc3tm", 0);
            PlayerPrefs.SetFloat("lvc3klnm", 0);
        }
        if (sceneName == "Level01T")
        {
            PlayerPrefs.SetFloat("songnum", 6);
            PlayerPrefs.SetFloat("lvtutc", 0);
            PlayerPrefs.SetFloat("lvtuttm", 0);
            PlayerPrefs.SetFloat("lvtutklnm", 0);
        }
        if (sceneName == "Level01M1")
        {
            PlayerPrefs.SetFloat("songnum", 7);
            PlayerPrefs.SetFloat("lvm1c", 0);
            PlayerPrefs.SetFloat("lvm1tm", 0);
            PlayerPrefs.SetFloat("lvm1klnm", 0);
        }
        if (sceneName == "Level01M2")
        {
            PlayerPrefs.SetFloat("songnum", 8);
            PlayerPrefs.SetFloat("lvm2c", 0);
            PlayerPrefs.SetFloat("lvm2tm", 0);
            PlayerPrefs.SetFloat("lvm2klnm", 0);
        }
        if (sceneName == "Level01M3")
        {
            PlayerPrefs.SetFloat("songnum", 9);
            PlayerPrefs.SetFloat("lvm3c", 0);
            PlayerPrefs.SetFloat("lvm3tm", 0);
            PlayerPrefs.SetFloat("lvm3klnm", 0);
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
        if (sceneName == "Level01D")
        {
            PlayerPrefs.SetFloat("songnum", 1);
        }
        if (sceneName == "Level01E")
        {
            PlayerPrefs.SetFloat("songnum", 5);
        }
        if (sceneName == "Level01FA")
        {
            PlayerPrefs.SetFloat("songnum", 3);
        }
        if (sceneName == "Level01FB")
        {
            PlayerPrefs.SetFloat("songnum", 3);
        }
        if (sceneName == "Level01FC")
        {
            PlayerPrefs.SetFloat("songnum", 3);
        }
        if (sceneName == "Level01T")
        {
            PlayerPrefs.SetFloat("songnum", 6);
        }
        if (sceneName == "Level01M1")
        {
            PlayerPrefs.SetFloat("songnum", 7);
        }
        if (sceneName == "Level01M2")
        {
            PlayerPrefs.SetFloat("songnum", 8);
        }
        if (sceneName == "Level01M3")
        {
            PlayerPrefs.SetFloat("songnum", 9);
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
