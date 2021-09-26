using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ConnectBody();
    }

    public GameObject bodyTank;
    //Kết nối với thân xe
    void ConnectBody()
    {
        if(Input.GetMouseButton(0) == true)
        {
            transform.position = bodyTank.transform.position;
        }
    }
}
