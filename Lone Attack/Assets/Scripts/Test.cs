using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform target;
    public float speed;
    public Vector3 a;
    public Vector3 b;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativepos = (target.position + new Vector3(0, .5f, 0)) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativepos);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, speed*Time.deltaTime);
        //transform.Translate(0, 0, 3 * Time.deltaTime);

        //Vector3 relativePos = target.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(relativePos, a);


    }
}
