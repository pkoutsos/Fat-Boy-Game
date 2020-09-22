using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics;
using Debug = UnityEngine.Debug ;

public class BurgerScript : MonoBehaviour
{
    private LevelScript levelScript;
    public int burgerValue;

    // Start is called before the first frame update
    void Start()
    {
        levelScript = FindObjectOfType<LevelScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Player")
        {
            levelScript.AddBurgers(burgerValue);
            Destroy(gameObject);
        }
       
    }


}
