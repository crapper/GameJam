﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepObjectDisable : MonoBehaviour
{
    public bool isenter = false;
    [SerializeField]
    float exitTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((isenter == true && this.gameObject.GetComponent<mixColorObj>().istrigger == true )|| this.gameObject.GetComponent<mixColorObj>().colorCorrect == true)
        {
            exitTime = Time.realtimeSinceStartup + 1f;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if(Time.realtimeSinceStartup > exitTime)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player") {
            isenter = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            isenter = false;
            this.gameObject.GetComponent<mixColorObj>().istrigger = false;
        }
    }
}
