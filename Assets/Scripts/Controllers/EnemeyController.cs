using System.Collections;
using System.Collections.Generic;
using Controllers;
using DG.Tweening;
using Pattern.Extension;
using UnityEngine;

public class EnemeyController : MonoBehaviour
{

    [SerializeField] private bool canMoveToPlayer;
    [SerializeField] private PlayerContoller player;
    [SerializeField] private  float speed;
    [SerializeField] private float nearPos = 2f;
    
    
    
    
    void Start()
    {
        
    }

    void Update()
    {
        if (canMoveToPlayer)
        {
            if (Vector3.Distance(this.transform.position,player.transform.position)<nearPos)
            {
                speed = 0;
            }
            else
            {
                speed = 2;
            }
            this.transform.LookAt(player.transform,Vector3.up);
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime).With(Axis.Y,1);
        }
    }
}
