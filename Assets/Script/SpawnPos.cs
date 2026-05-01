using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPos : MonoBehaviour
{
    [SerializeField] private float[] posX;
    [SerializeField] private float[] posY;
    private Transform obstacle;
    

    private void Awake()
    {
        DoPos();
    }

    private void DoPos()
    {
        int indexX;
        indexX = Random.Range(0, posX.Length);
        transform.position=new Vector3(posX[indexX],transform.position.y,transform.position.z);

    }
}
