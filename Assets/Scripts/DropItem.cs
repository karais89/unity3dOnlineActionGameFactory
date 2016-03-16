﻿using UnityEngine;
using System.Collections;

public class DropItem : MonoBehaviour 
{
    public enum ItemKind
    {
        Attack,
        Heal,
    };
    
    public ItemKind kind;
    
    void Start()
    {
        Vector3 velocity = Random.insideUnitSphere * 2.0f + Vector3.up * 8.0f;
        GetComponent<Rigidbody>().velocity = velocity;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CharacterStatus aStatus = other.GetComponent<CharacterStatus>();
            aStatus.GetItem(kind);
            
            Destroy(gameObject);
        }
    }
}
