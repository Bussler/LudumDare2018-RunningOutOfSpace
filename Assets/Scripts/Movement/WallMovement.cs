using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour {

    private bool onGround=false;
    public float speed;

    public float ItemPercent = 10;

    public List<Material> otherMeteoriten;
    public GameObject wall;
    public GameObject item;
    private Material wallMaterial;
    private GameObject currObj;


    private void Awake()
    {
        int rand = Random.Range(0, 100);//decide whether to spawn item or boundary
        if (rand <= ItemPercent)
        {
            currObj = item;
            int farbe = Random.Range(0, 2) % 3;
            GetComponent<Renderer>().material = otherMeteoriten[farbe];
            GetComponentInChildren<ParticleSystem>().gameObject.GetComponent<ParticleSystemRenderer>().material =
                otherMeteoriten[farbe + 3];
        }
        else
        {
            currObj = wall;
        }
    }

    // Update is called once per frame
    void LateUpdate () {
        if (onGround == false)
        {
            float amtToMove = speed * Time.deltaTime;
            transform.Translate(Vector3.down * amtToMove);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("HI");
        if (collision.gameObject.tag=="Ground") {

            Instantiate(currObj, new Vector3(transform.position.x, 1f, transform.position.z), Quaternion.identity);

            onGround = true;
            GetComponent<Rigidbody>().isKinematic = true;
            Destroy(gameObject);
        }

        if (onGround==false&&collision.gameObject.tag=="Player")
        {
            MyGameManager.p_health -= 1;
            Destroy(gameObject);
        }

        if (onGround==false&&collision.gameObject.tag=="Enemy")
        {
            collision.gameObject.GetComponent<EnemyHandle>().e_health -= 60;
            Destroy(gameObject);
        }

    }
}
