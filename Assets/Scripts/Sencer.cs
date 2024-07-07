using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sencer : MonoBehaviour
{

     public   List<EnemeyController> _allenemey = new List<EnemeyController>();


    
    
    void Start()
    {
        _allenemey.AddRange(FindObjectsOfType<EnemeyController>());
       
    }

    void Update()
    {
        
        var close = Closest(this.transform, _allenemey);
        Debug.Log(close.name);
        
       
    }

 


    public static T Closest<T>( Transform from, List<T> to) where T: Component
    {
        float minDistance = float.MaxValue;
        var closest = to[0];
            
        for (var i = 0; i < to.Count; i++)
        {
            var d = (from.position - to[i].transform.position).sqrMagnitude;
            if (d < minDistance)
            {
                minDistance = d;
                closest = to[i];
            }
        }

        return closest;
    }
}
