using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
using Random = UnityEngine.Random;

public class Clone : MonoBehaviour
{
    [SerializeField] private Vector2 range;
    public Vector3 player;
    private void Awake()
    {
        player = FindObjectOfType<PlayerContoller>().transform.position;
    }

    public T Copy<T>() where T : Component
    {
        
        Clone clone = Instantiate<Clone>(this);
        GameObject spawner = GameObject.Find("Spawning Parent");
        clone.transform.SetParent(spawner.transform);
        Vector3 pos = new Vector3(Random.Range(-range.x,range.x),0,Random.Range(-range.y,range.y)) + player;
        clone.transform.localPosition = pos;
        return clone.GetComponent<T>();



    }

}
