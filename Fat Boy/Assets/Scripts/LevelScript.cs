using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public float respawnDelay;
    public PlayerScript playerScript;
    public int burgers;
    public Text burgerText;
    public Text goburgerText;
    public GameObject winPanel;


    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<PlayerScript> ();
        winPanel.SetActive(false);
        burgerText.text = "Burgers: " + burgers;
        goburgerText.text = "Burgers : " + burgers;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }


    public IEnumerator RespawnCoroutine()
    {
        playerScript.gameObject.SetActive(false);
        yield return new WaitForSeconds (respawnDelay);
        playerScript.transform.position = playerScript.respawnPoint;
        playerScript.gameObject.SetActive(true);
    }

    public void AddBurgers(int numberOfBurgers)
    {
        this.burgers += numberOfBurgers;
        burgerText.text = "Burgers: " + burgers;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void GameCompleted()
    {
        goburgerText.text = "Burgers: " + this.burgers;
        winPanel.SetActive(true);
    }

}
