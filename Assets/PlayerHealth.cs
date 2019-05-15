﻿using UnityEngine;

using UnityEngine.UI;



public class PlayerHealth : MonoBehaviour

{
    [SerializeField] Text GameOver;
    public Slider HealthBar;
    public float Health = 500;
    Image[] images;
    Color32[] Colors;

    private float currentHealth;
    [SerializeField] Text Lives;
    private GameObject Bloodsplatter;
    public GameObject BloodsplatterPrefab;

    void Start()

    {

        currentHealth = Health;
        GameObject fill = HealthBar.transform.GetChild(1).GetChild(0).gameObject;
        if (GameOver != null)
        {
            GameOver.gameObject.SetActive(false);
        }

        Image fillImageLife4 = fill.GetComponent<Image>();
        Color newColor = Color.green;
        fillImageLife4.color = newColor;
        BloodsplatterPrefab.SetActive(false);

    }



    public void TakeDamage(float damage)

    {

        currentHealth -= damage;

        HealthBar.value = currentHealth;
        GameObject fill = HealthBar.transform.GetChild(1).GetChild(0).gameObject;

        Image fillImageLife1 = fill.GetComponent<Image>();
        Image fillImageLife2 = fill.GetComponent<Image>();
        Image fillImageLife3 = fill.GetComponent<Image>();


        if (HealthBar.value >= 200)
        {
            Lives.text = "Lives: 3/3" ;
            Color newColour = Color.green;
            fillImageLife1.color = newColour;

        }
        else if (HealthBar.value >= 100)
        {
            Lives.text = "Lives: 2/3";
            Color newColour = Color.yellow;
            fillImageLife2.color = newColour;


        }
        else if(HealthBar.value >= 2)
       { 
           Lives.text = "Lives: 1/3";
            Color newColour = Color.red;
            fillImageLife3.color = newColour;


        }

        else
        {
            Lives.text = "Lives: 0/3";
            Color newColour = Color.white;
            fillImageLife3.color = newColour;
            GameOver.gameObject.SetActive(false);
        }




    }
   



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Reward")
        {
            TakeDamage(5);
            BloodsplatterPrefab.SetActive(true);
            Bloodsplatter = GameObject.Instantiate(BloodsplatterPrefab, collision.contacts[0].point, Quaternion.identity);
            Destroy(Bloodsplatter, 2.5f);

        }
    }
}