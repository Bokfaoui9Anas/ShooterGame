using Controllers;
using UnityEngine;

public  interface BaseEnemy
{
    /*[SerializeField] public GameObject enemyPrefab;
    [SerializeField] private string name;
        
    [SerializeField] public bool canMoveToPlayer;
    [SerializeField] private PlayerContoller player;
    [SerializeField] private  float speed;
    [SerializeField] private float nearPos = 2f;

    [SerializeField] public Transform parent;
    



    private void Awake()
    {
        canMoveToPlayer = false;
        player.Sensor._allenemey.Add(this);
    }


    void Start()
    {
       
    }

    void Update()
    {
        /*if (canMoveToPlayer)
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
        }#1#
    }*/
}