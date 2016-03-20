using UnityEngine;
using System.Collections;

public class CharacterStatus : MonoBehaviour 
{
    //****** 공격 장에서 사용한다. ******
    // 체력.
    public int HP = 100;
    public int MaxHP = 100;
    
    // 공격력.
    public int Power = 10;
    
    // 마지막에 공격한 대상.
    public GameObject lastAttackTarget = null;
    
    // **** GUI 및 네트워크 장에서 사용한다. ********
    // 플레이어 이름.
    public string characterName = "Player";
    
    //******* 에니메이션 장에서 사용한다. ****
    // 상태.
    public bool attacking = false;
    public bool died = false;
    
    
    // 공격력 강화
    public bool powerBoost = false;
    
    // 공격력 강화 시간
    float powerBoostTime = 0.0f;
    
    ParticleSystem powerUpEffect;
    
    public void GetItem(DropItem.ItemKind itemKind)
    {
        switch (itemKind)
        {
            case DropItem.ItemKind.Attack:
            powerBoostTime = 5.0f;
            if(powerUpEffect)
                powerUpEffect.Play();
            break;
            case DropItem.ItemKind.Heal:
            HP = Mathf.Min(HP + MaxHP / 2, MaxHP);
            break;
        }
    }
    
    void Start()
    {
        if(gameObject.tag == "Player")
        {
            powerUpEffect = transform.Find("PowerUpEffect").GetComponent<ParticleSystem>();
        }
    }
    
    void Update()
    {
        powerBoost = false;
        if(powerBoostTime > 0.0f)
        {
            powerBoost = true;
            powerBoostTime = Mathf.Max(powerBoostTime - Time.deltaTime, 0.0f);
        }
        else
        {
            if(powerUpEffect)
                powerUpEffect.Stop();
        }
    }
    
}
