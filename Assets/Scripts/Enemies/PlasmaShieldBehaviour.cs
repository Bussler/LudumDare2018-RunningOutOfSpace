using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlasmaShieldBehaviour : MonoBehaviour {

    int shieldLives;
    Color color;

    private float voronoiSize;
    // Use this for initialization
    void Start()
    {
        shieldLives = 3;
//        color = GetComponent<Renderer>().material.GetColor("_BaseColor");
        color.a = 0.5f;
//        Debug.Log(ShaderUtil.GetPropertyName(GetComponent<Renderer>().material.shader, 1));
        voronoiSize = GetComponent<Renderer>().material.GetFloat("Vector1_743FDFC5");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerRocket")
        {
            Destroy(other.gameObject);
            shieldLives--;
            if (shieldLives < 1)
            {
                
                Destroy(gameObject);
            }
            voronoiSize -= 0.25f;
            GetComponent<Renderer>().material.SetFloat("Vector1_743FDFC5", voronoiSize);
        }

        if (other.tag=="PlayerShot")
        {
            Destroy(other.gameObject);
        }

    }
}
