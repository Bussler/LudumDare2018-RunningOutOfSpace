using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscores : MonoBehaviour {

    const string privateCode = "i8tw48WqcUugS34suFWqqwLHBFeqcQc0GpTyFDZENe_g";
    const string publicCode = "5b719728191a8b0bccc3ae5b";
    const string webURL = "http://dreamlo.com/lb/";

    static Highscores instance;

    public static string UserName="";

    DisplayLadder highscoresDisplay;

    public Highscore[] highscoresList; //all the highscores are stored in here, when downloading

    private void Awake()
    {
        //highscoresDisplay = GameObject.Find("HighscoreDisplayer").GetComponent<DisplayLadder>();

        if (instance == null)//only one instance active: singleton
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);//don't destroy when loading another scene

    }

    public static void AddNewHighscore(string username, int score)
    {
        instance.StartCoroutine(instance.UploadNewHighscore(username,score));
    }


    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            print("Upload Successful");
        }
        else
        {
            print("Error uploading " + www.error);
        }

    }

    public void Downloadighscores()
    {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }

    IEnumerator DownloadHighscoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        highscoresDisplay = GameObject.Find("HighscoreDisplayer").GetComponent<DisplayLadder>();

        if (string.IsNullOrEmpty(www.error))
        {
            //print(www.text);
            FormatHighscores(www.text);

            highscoresDisplay.OnHighscoresDownloaded(highscoresList);//display highscores if not trouble loading
        }
        else
        {
            print("Error downloading " + www.error);
        }

    }

    public void FormatHighscores(string text)
    {
        string[] entries = text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);//einträge unterteilen
        highscoresList = new Highscore[entries.Length];

        for(int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });//unterteilen in einzelne felder
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore (username, score);

            print(highscoresList[i].username + " : " + highscoresList[i].score);
        }
    }

}

public struct Highscore
{
    public string username;
    public int score; 

    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}
