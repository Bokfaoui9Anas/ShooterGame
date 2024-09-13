using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using Pattern.Prototype;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    
    
    
    public Clone redEnemy;
    public Clone yEnemy;
    public Factory<Clone> factory = new Factory<Clone>();
    [SerializeField] private int numbSpawn;
    

    private void Awake()
    {
        factory[redEnemy.name] = redEnemy;
        factory[yEnemy.name] = yEnemy;
    }

    void Start()
    {

        for (int i = 0; i < numbSpawn; i++)
        {
            BaseEnemy enemy = null;
            var random = Random.Range(1, 3);
            switch (random)
            {
                case 1 :
                    enemy = factory[redEnemy.name].Copy<RedEnemy>();
                    break;
                case 2 :
                    enemy = factory[yEnemy.name].Copy<YellowEnemy>();
                    break;
            }

        }

    }

   
    void Update()
    {
        
    }
}