using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public Text lastScoreText;
    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetFloat("Time") !=0)
        {
            float minutes = Mathf.Floor(PlayerPrefs.GetFloat("Time") / 60);
            float seconds = Mathf.RoundToInt(PlayerPrefs.GetFloat("Time") % 60);
            string minText = "" + Mathf.Floor(PlayerPrefs.GetFloat("Time") / 60), secText = "" + Mathf.RoundToInt(PlayerPrefs.GetFloat("Time") % 60);
            if (minutes < 10)
            {
                minText = "0" + minutes.ToString() + ":";
            }
            if (seconds < 10)
            {
                secText = "0" + Mathf.RoundToInt(seconds).ToString();
            }
            lastScoreText.text = "Score:" + PlayerPrefs.GetInt("Score") + "  Shoot:" + PlayerPrefs.GetInt("ShootCount") + "  Time:" + minText + ":" + secText;
        } else {
			lastScoreText.text = "Wellcome to the pool game dear gamer...";
		}

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DisableMenu()
    {
        gameObject.SetActive(false);
    }
    public void EnableMenu()
    {
        gameObject.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
