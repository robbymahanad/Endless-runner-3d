using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour,ISpawnable
{
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject currentPlatform;
    [SerializeField] private Vector3 platformLenght = new Vector3(0,0,100);
    [SerializeField] private GameObject[] item;
    [SerializeField] private float obstacleInterval;
    [SerializeField] private PlatformScript[] platformScripts;
    [SerializeField] private Vector3 obstaclePos = new Vector3(2, 2, 100);
    [SerializeField] private float spawnInterval = 5f;
    public float objectSpeed = 5f;
    [SerializeField] Animator animator;
    [SerializeField] private float interval = 5f;
    [SerializeField] private float increment = 1f;
    [SerializeField] private float animationIncrement = 0.1f;
    [SerializeField] private float animationSpeed = 1f;
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(IncreaseSpeed), interval, interval);
        InvokeRepeating(nameof(SpawnObstacle), 0f, spawnInterval);
        currentPlatform = FindObjectOfType<PlatformScript>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("RunSpeed", animationSpeed);
        platformScripts = FindObjectsOfType<PlatformScript>();
        
    }
    public void SpawnObject()
    {
        Vector3 nextPos = currentPlatform.transform.position + (platformLenght * 2);
        currentPlatform = Instantiate(platform, nextPos, Quaternion.identity);
    }
    private void SpawnObstacle()
    {
        Vector3[] spawnPoint = 
        { 
            new Vector3
            (3f, obstaclePos.y, obstaclePos.z), 
            new Vector3(0f, obstaclePos.y, obstaclePos.z), 
            new Vector3(-3f, obstaclePos.y, obstaclePos.z) 
        };
        int index = Random.Range(0, spawnPoint.Length);
        int itemIndex = Random.Range(0, item.Length);
        GameObject itemSpawn = item[itemIndex];
        Vector3 spawnPos= spawnPoint[index];
        Instantiate(itemSpawn, spawnPos, Quaternion.identity);

    }
    public void StopMoving()
    {
        foreach(PlatformScript move in  platformScripts)
        {
            objectSpeed = 0f;
            CancelInvoke(nameof(SpawnObstacle));
        }
    }
    private void IncreaseSpeed()
    {
        if(objectSpeed>0)
        {
            objectSpeed += increment;
            animationSpeed += animationIncrement;
            Debug.Log("New Speed: " + objectSpeed);
        }
        
    }
}
