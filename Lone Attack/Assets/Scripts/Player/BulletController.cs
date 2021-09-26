using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    protected float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveController();
        InformationUpdate();
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    void MoveController()
    {
        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void InformationUpdate()
    {
        speed = PlayerPrefs.GetFloat("SpeedBulletTank01");
    }
}
