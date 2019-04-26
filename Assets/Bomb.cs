﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public float delay;
    public GameObject Target;
    public int hitCounter;
    public float explosionForce;
    public float explosionRadius;
    public float upModifier;
    public LayerMask interactionMask;
    public GameObject explosionEffectPrefab;
    public GameObject explosion;





    // Start is called before the first frame update
    void Start()
    {
        Invoke("explode",delay);
       
    }

    // Update is called once per frame
    void explode()
    {
        Collider [] hitColliders =Physics.OverlapSphere(transform.position, explosionRadius, interactionMask);

       
        foreach (Collider c in hitColliders) 
        {
          
            Rigidbody r = c.GetComponent<Rigidbody>();
            r.AddExplosionForce(explosionForce, transform.position, explosionRadius, upModifier);
            //var hit = Target.GetComponent<BoxCollider>();
            //hitCounter++;


            //if (hit == true)
            //{
            //    hitCounter++;
            //    Debug.Log("Contact was made:" + hitCounter);

            //}
            //else
            //{
            //    Debug.Log("No Contact was made");
            //}
           //c.gameObject.GetComponent<CubePhysics>();

        }



        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<AudioSource>().Play();

        explosion = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);

        Kill();
       
        //Invoke("Kill", 3f);

    }



    void Kill()
    {

        //Destroy(GameObject.Find("Cube(Clone)"), 1F);
        //Debug.Log("Cube Destroyed. Works from Bomb Script");
        //Destroy(explosion);



    }

   

}
