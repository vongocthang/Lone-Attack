using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataDefault : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("FireRateTank01", 0.5f);
        PlayerPrefs.SetFloat("SpeedTank01", 200f);
        PlayerPrefs.SetFloat("SpeedBulletTank01", 10f);
        PlayerPrefs.SetFloat("DamgeBulletTank01", 50f);
    }

    void Update()
    {
     
    }

}
