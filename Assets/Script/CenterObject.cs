using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterObject : MonoBehaviour
{
    private Vector3 pos;
    [SerializeField] private float height = 0;
    
    private void Awake()
    {
        pos= transform.position;
        pos.x = 0;
        pos.y = height;
        transform.position = pos;
    }
}
