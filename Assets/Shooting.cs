﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    float bulletSpeed = 1100;
    public GameObject bullet;

    AudioSource bulletAudio;

    // Use this for initialization
    void Start()
    {

        bulletAudio = GetComponent<AudioSource>();

    }

    void Fire()
    {
        //Shoot
        //GameObject tempBullet = Instantiate(bullet, transform.position, Quaternion.Euler(90, -90,0)) as GameObject;
        GameObject tempBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
        Destroy(tempBullet, 0.5f);

        //Play Audio
        bulletAudio.Play();

    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

    }
}
