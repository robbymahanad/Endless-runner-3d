using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour,IDestroyable
{
    //[SerializeField] public float speed = 5f;//Platform movement speed
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private Vector3 destroyPosition = new Vector3(0, 0, -300);
    [SerializeField] private GameManager gameManager;
    void Awake()
    {
        gameManager= FindObjectOfType<GameManager>();
    }

    void Update()
    {
        PlatformMove();
        DestroyObject(destroyPosition);
    }
    private void PlatformMove()//Make Platform Move
    {
        Vector3 direction = new Vector3(0, 0, -1);//Platform moving direction
        transform.Translate(direction * gameManager.objectSpeed * Time.deltaTime);
    }

    public void DestroyObject(Vector3 position)
    {
        if (gameObject.transform.position.z < position.z)
        {
            Destroy(gameObject);
        }
    }
}
