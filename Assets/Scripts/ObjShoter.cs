using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjShoter : MonoBehaviour
{

    public GameObject Obj;
    GameObject Objcopy;
    private float nt, bt;

    Vector3 shoterPos;

    public Vector3 Upvector;
    public float Xvector;
    // Start is called before the first frame update
    void Start()
    {
        shoterPos = transform.position;
        nt = Time.time;
        bt = nt;
    }

    // Update is called once per frame
    void Update()
    {
        nt = Time.time;
        shoterPos = transform.position;
        if ((nt - bt) >= 0.5)
        {
            bt = nt;
            shoterPos.x = Random.Range(shoterPos.x - 1.5f, shoterPos.x +1.5f);
            //shoterPos.y = Random.Range(shoterPos.y - 1.5f, shoterPos.y + 1.5f);
            //shoterPos.z = Random.Range(shoterPos.z - 1.5f, shoterPos.z + 1.5f);
            Objcopy = GameObject.Instantiate(Obj, shoterPos, Quaternion.identity);
            Objcopy.GetComponent<Rigidbody>().isKinematic = false;
            Upvector.x = Random.Range(-60f, 60f);
            Upvector.y = Random.Range(380f, 420f);
            Upvector.z = 500;
            Objcopy.GetComponent<Rigidbody>().AddForce(Upvector);
            Objcopy.GetComponent<Rigidbody>().AddTorque(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));

        }

    }
}
