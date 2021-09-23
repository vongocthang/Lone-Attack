using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public float hitPoints;
    public float maxHP = 500;
    public HealthBar health;
    protected float damgeBullet;

    // Start is called before the first frame update
    void Start()
    {
        UpdateInformation();

        hitPoints = maxHP;
        health.SetHealth(hitPoints, maxHP);
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInformation();

        TargetDie();
    }

    //Cập nhật thông tin
    void UpdateInformation()
    {
        damgeBullet = PlayerPrefs.GetFloat("DamgeBulletTank01");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            hitPoints -= damgeBullet;
        }
    }

    void TargetDie()
    {
        health.SetHealth(hitPoints, maxHP);

        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }


}
