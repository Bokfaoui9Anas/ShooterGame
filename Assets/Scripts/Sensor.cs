using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

[System.Serializable]
public class Sensor : MonoBehaviour
{

     public  List<BaseEnemy> _allenemey = new List<BaseEnemy>();
     private PlayerContoller _playerContoller;
     private SphereCollider _collider;
     


    
    
    void Start()
    {
      //  _allenemey.AddRange(FindObjectsOfType<EnemyController>());$
      _collider = this.GetComponent<SphereCollider>();
      _playerContoller = FindObjectOfType<PlayerContoller>();
      
       
    }

    void Update()
    {
        
        // var close = Closest(this.transform, _allenemey);
        // close.canMoveToPlayer = true;
        // // if (Vector3.Distance(close.gameObject.transform.position,_playerContoller.transform.position)<1f)
        // // {
        // //     close.canMoveToPlayer = true;
        // // }
        // Debug.Log(close.name);
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            BaseEnemy enemy = other.GetComponent<BaseEnemy>();
            _allenemey.Add(enemy);
            Debug.Log(_allenemey.Count);
          

           
        }

        Debug.Log(_allenemey.Count);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            
        }
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
