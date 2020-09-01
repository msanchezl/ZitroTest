using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class WorldTime
{
    public string abbreviation;
    public string client_ip;
    public string datetime;
    public string day_of_week;
    public string day_of_year;
    public string dst;
    public string dst_from;
    public string dst_offset;
    public string dst_until;
    public string raw_offset;
    public string timezone;
    public string unixtime;
    public string utc_datetime;
    public string utc_offset;
    public string week_number;
}

public class LobbyManager : MonoBehaviour
{
    static public int gameSelected = 0;

    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetTime());
    }

    public IEnumerator GetTime()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://worldtimeapi.org/api/ip");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            timeText.text = www.error;
        }
        else
        {
            WorldTime myWordTime = new WorldTime();
            myWordTime = JsonUtility.FromJson<WorldTime>(www.downloadHandler.text);
            timeText.text = myWordTime.datetime.Substring(0,10).Replace('-', '/') + " " + myWordTime.datetime.Substring(11, 8);
        }
    }

    public void GameSelection(int a_game)
    {
        gameSelected = a_game;
        SceneManager.LoadScene(2);
    }
}
