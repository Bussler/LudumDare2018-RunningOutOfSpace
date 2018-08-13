using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MyGameManager : MonoBehaviour {

    public static MyGameManager instance = null;
    public static int level = 2;//0:rand, 1:1d, 2:tutorial 3:endlos

    public Canvas c;
    
    public static bool isAttackable = true;

    public static int p_health = 5;
    public static float lastHit=0;
    public static float downtime = 1f;
    public static int score;

    public static float lastDeath;
    
    public List<GameObject> hearts;//store the instantiated projectiles

    public GameObject bombe;

    public GameObject laser;
    
    //special weapons
    public static int bombCount=0;
    public static bool bombActive = false;

    public static float laserSeconds = 0;

    // Use this for initialization
    private void Awake()
    {
        level = 2;
        lastHit = 0;
        bombActive = false;
        bombCount = 0;
        laserSeconds = 0;

        if (instance==null)//only one instance active: singleton
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);//don't destroy when loading another scene

        if (SceneManager.GetActiveScene().name=="2DScene")
        {
            level = 0;
        }

        if (SceneManager.GetActiveScene().name=="2dEndlos")
        {
            level = 3;
        }

    }

    private void Update() {

        if (SceneManager.GetActiveScene().name=="StartMenu")//destroy when in the startmenu again for another round of fun
        {
            Destroy(gameObject);
        }

        if (Time.time-lastHit>downtime&&isAttackable==false)//downtime of 2 sec
        {
            isAttackable = true;
        }

        if (bombCount >= 1) {
            bombe.gameObject.SetActive(true);
        } else {
            bombe.gameObject.SetActive(false);
        }

        if (laserSeconds >= 1) {
            laser.gameObject.SetActive(true);
        } else {
            laser.gameObject.SetActive(false);
        }

        switch (p_health) {
                case 4: hearts[4].SetActive(false);//Debug.Log("4");
                    break;
                case 3: hearts[3].SetActive(false);
                    break;
                case 2: hearts[2].SetActive(false);
                    break;
                case 1: hearts[1].SetActive(false);
                    break;
                case 0: hearts[0].SetActive(false);
                    break;
                default:
                    break;
        }

    }

    private void FixedUpdate()
    {
        
        if (p_health < 5) {
            hearts[4].SetActive(false);
        }

        if (p_health < 4) {
            hearts[3].SetActive(false);
        }

        if (p_health < 3) {
            hearts[2].SetActive(false);
        }

        if (p_health < 2) {
            hearts[1].SetActive(false);
        }

        if (p_health < 1) {
            hearts[0].SetActive(false);
        }
        if(p_health<=0){
            //load loosing scene
            //Debug.Log("You loose kid");
            SceneManager.LoadScene("Loose");
            Destroy(c.gameObject);
            Destroy(gameObject);
        }

        if(score>=800&&level==2){ //loading levels
            level = 0;
            SceneManager.LoadScene("2DScene");
        }

        if (score>=1500&&level==0)
        {
            //go from 2d in 1d
            level = 1;
            SceneManager.LoadScene("1DScene");
        }

        if (score>=2000&&level==1)//variabel TODO vlt auf 2000 setzen
        {
            //load winning scene
            //Debug.Log("You win");
            SceneManager.LoadScene("Win");
            Destroy(c.gameObject);
            Destroy(gameObject);
        }
    }
}
