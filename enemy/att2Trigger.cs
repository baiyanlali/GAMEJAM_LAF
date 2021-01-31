using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class att2Trigger : MonoBehaviour
{
    private GameObject father;
    public GameObject player;
    public void Start()
    {
        father = transform.parent.gameObject; //获取当前对象的父对象
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "fakeMain")
        {
            Debug.LogError("att2!!!!!!!");
            //player.hp--;
        }
    }
   
    
}
