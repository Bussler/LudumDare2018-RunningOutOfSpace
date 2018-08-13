using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour {

    public float speed;
    public int dmg;

    public bool detonated = false;

    private void Awake()
    {
        MyGameManager.bombActive = true;
    }

    // Update is called once per frame
    void Update()//movement
    {
        float amtToMove = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * amtToMove);

        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

    private void LateUpdate()//destroy after collision
    {
        if (detonated==true)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        MyGameManager.bombActive = false;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
