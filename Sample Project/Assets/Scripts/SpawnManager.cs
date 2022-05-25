using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject character;
    public TextMeshProUGUI player;
    
    public GameObject[] objectKind;
    private int xBound = 12;
    private int zBound = 6;
    
    void Start()
    {
        character = MenuController.character;
        string exa = MenuController.playerName;
        player.SetText(exa);
        
        Vector3 spawnPosition = new Vector3(0, 0, 0);
        Instantiate(character, spawnPosition, Quaternion.identity);
        StartCoroutine("ObjectCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.gameover == true)
        {
            StopAllCoroutines();
        }
    }

    //Spawn character
    public void SpawnObject()
    {
        int xRange = Random.Range(-xBound, xBound);
        int zRange = Random.Range(-zBound, zBound);
        Vector3 objectPosition = new Vector3(xRange, 0, zRange); //set object position 
        int index = Random.Range(0,objectKind.Length); // set kind of object
        Instantiate(objectKind[index], objectPosition, Quaternion.identity);
    }

    private IEnumerator ObjectCoroutine()
    {
        SpawnObject();
        yield return new WaitForSeconds(2);
        StartCoroutine("ObjectCoroutine");
    }
}
