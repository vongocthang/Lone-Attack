using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    protected AudioSource fireAudio;
    protected Animator fireAnimator;

    // Start is called before the first frame update
    void Start()
    {
        fireAudio = GetComponent<AudioSource>();
        fireAnimator = tower.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InformationUpdate();

        NearestTarget();

        LookTarget(number);

        CheckComplete();

        Fire();

    }

    //Cập nhật thông tin
    void InformationUpdate()
    {
        fireRate = PlayerPrefs.GetFloat("FireRateTank01");
    }

    protected GameObject[] target;
    protected GameObject player;
    public GameObject tower;
    protected int number;
    //Xác định mục tiêu gần nhất
    void NearestTarget()
    {
        target = GameObject.FindGameObjectsWithTag("Target");
        player = GameObject.FindGameObjectWithTag("Player");

        float distance;
        float min = 1000;
        number = 0;

        
        for (int i = 0; i < target.Length; i++)
        {
            distance = Vector3.Distance(target[i].transform.position, player.transform.position);
            if (distance < min)
            {
                min = distance;
                number = i;
            }
        }
    }

    protected float speed = 4;
    protected string targetName;
    //Quay nòng pháo tới mục tiêu gần nhất
    void LookTarget(int number)
    {
        //if(target[number].name != targetName && Input.GetMouseButton(0) == true)
        //{
        //    Vector3 relativePos = (target[number].transform.position + new Vector3(0, .5f, 0))
        //    - tower.transform.position;
        //    Quaternion rotation = Quaternion.LookRotation(relativePos);
        //    Quaternion current = tower.transform.localRotation;

        //    tower.transform.localRotation = Quaternion.Slerp(current, rotation, speed * Time.deltaTime);
        //}

        Vector3 relativePos = (target[number].transform.position + new Vector3(0, .1f, 0))
            - tower.transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        Quaternion current = tower.transform.localRotation;

        tower.transform.localRotation = Quaternion.Slerp(current, rotation, speed * Time.deltaTime);
    }

    //Kiểm tra tất cả các mục tiêu đã được hoàn thành hay chưa
    bool CheckComplete()
    {
        bool complete = false;

        if (target.Length == 0)
        {
            complete = true;
        }

        return complete;
    }

    //Xác định có chạm vào màn hình hay không
    bool CheckTouch()
    {
        bool touch = false;


        return touch;
    }

    //public float speedAnimation;
    ////Animation Fire bullet
    //void FireAnimation()
    //{
    //    Vector3 a = tower.transform.position;

    //    tower.transform.position = Vector3.MoveTowards(tower.transform.position,
    //        tower.transform.position - new Vector3(0, 0, 0.1f), speedAnimation * Time.deltaTime);
    //    if(tower.transform.position)
    //    tower.transform.position = Vector3.MoveTowards(tower.transform.position,
    //        tower.transform.position + new Vector3(0, 0, 0.1f), speedAnimation * Time.deltaTime);
    //}

    public GameObject bullet;
    public GameObject firePosition;//Vị trí ra đạn
    protected float fireRate;//Tần suất ra đạn
    protected float timeNow = 0f;
    public GameObject effect;
    //Bắn đạn
    void Fire()
    {
        ////Điều khiển bằng cảm ứng - mobile
        ////Nếu đứng im và đến ngưỡng tốc độ bắn
        //if (Time.time > timeNow + fireRate && Input.touchCount == 0)
        //{
        //    GameObject a = Instantiate(bullet, firePosition.transform.position, firePosition.transform.rotation);
        //    a.SetActive(true);
        //    a.GetComponent<BulletController>().enabled = true;
        //    timeNow = Time.time;
        //}

        //Điều khiển bằng chuột
        //Tồn tại mục tiêu trên map
        if(CheckComplete() == false)
        {
            //Nếu đứng im và đến ngưỡng tốc độ bắn
            if (Time.time > timeNow + fireRate && Input.GetMouseButton(0) == false)
            {
                GameObject a = Instantiate(bullet, firePosition.transform.position, firePosition.transform.rotation);
                a.SetActive(true);
                a.GetComponent<BulletController>().enabled = true;
                fireAudio.Play();
                //FireAnimation();
                fireAnimator.Play("TankTower");
                //Chạy hiệu ứng bắn đạn
                effect.GetComponent<ParticleSystem>().Play();
                timeNow = Time.time;
            }
            
        }
    }
}
