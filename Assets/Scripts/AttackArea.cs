﻿using UnityEngine;
using System.Collections;

public class AttackArea : MonoBehaviour 
{
    CharacterStatus status;
    
    public AudioClip hitSeClip;
    AudioSource hitSeAudio;

	// Use this for initialization
	void Start () 
    {
        status = transform.root.GetComponent<CharacterStatus>();	    
        
        hitSeAudio = gameObject.AddComponent<AudioSource>();
        hitSeAudio.clip = hitSeClip;
        hitSeAudio.loop = false;
	}
	
    public class AttackInfo
    {
        // 공격력.
        public int attackPower;
        // 공격자.
        public Transform attacker;
    }
    
    // 공격 정보를 가져온다.
    AttackInfo GetAttackInfo()
    {
        AttackInfo attackInfo = new AttackInfo();
        // 공격력 계산.
        attackInfo.attackPower = status.Power;
        
        // 공격 강화 중.
        if(status.powerBoost)
            attackInfo.attackPower += attackInfo.attackPower;
        
        attackInfo.attacker = transform.root;
        
        return attackInfo;
    }
    
    // 맞았다.
    void OnTriggerEnter(Collider other)
    {
        // 공격 당한 상태의 Damage 메시지를 보낸다.
        other.SendMessage("Damage", GetAttackInfo());
        // 공격한 대상을 저장한다.
        status.lastAttackTarget = other.transform.root.gameObject;
        
        hitSeAudio.Play();
    }
    
    // 공격 판정을 유효로 한다.
    void OnAttack()
    {
        Debug.Log("AttackArea OnAttack");
        GetComponent<Collider>().enabled = true;
    }
    
    // 공격 판정을 무효로 한다.
    void OnAttackTermination()
    {
        Debug.Log("AttackArea OnAttackTermination");
        GetComponent<Collider>().enabled = false;
    }
}
