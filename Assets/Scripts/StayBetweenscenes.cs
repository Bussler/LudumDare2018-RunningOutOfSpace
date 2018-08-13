using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayBetweenscenes : MonoBehaviour {

    public static GameObject Canvasinstance = null;

    private void Awake()
    {
        if (Canvasinstance == null)//only one instance active: singleton
        {
            Canvasinstance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);//don't destroy when loading another scene
    }
}
