using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    protected FloatingJoystick floatingJoystick;
    protected Rigidbody rigibody;
    protected float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigibody = gameObject.GetComponent<Rigidbody>();
        floatingJoystick = GameObject.FindObjectOfType<FloatingJoystick>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Controller();

        InformationUpdate();
    }

    void Controller()
    {
        Vector3 direction = Vector3.forward * floatingJoystick.Vertical
            + Vector3.right * floatingJoystick.Horizontal;
        rigibody.AddForce(direction * speed * Time.deltaTime, ForceMode.VelocityChange);
        //Đầu xe quay theo hướng di chuyển
        gameObject.transform.LookAt(direction + gameObject.transform.position);
    }

    void InformationUpdate()
    {
        speed = PlayerPrefs.GetFloat("SpeedTank01");
    }
}
