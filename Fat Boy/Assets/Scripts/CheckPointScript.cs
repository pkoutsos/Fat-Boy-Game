using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{

    public Sprite redFlag;
    public Sprite greenFlag;
    private SpriteRenderer spriteRenderer;
    public bool checkpointReached;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            spriteRenderer.sprite = greenFlag;
            checkpointReached = true;
        }
    }
}
