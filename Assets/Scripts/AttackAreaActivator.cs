using UnityEngine;
using System.Collections;

public class AttackAreaActivator : MonoBehaviour 
{
    // 공격 판정 컬라이더 배열.
    Collider[] attackAreaColliders;
    
	// Use this for initialization
	void Start () 
    {
        // 자식 오브젝트에서 AttackArea 스크립트가 추가된 오브젝트를 찾는다.
        AttackArea[] attackAreas = GetComponentsInChildren<AttackArea>();
        attackAreaColliders = new Collider[attackAreas.Length];
        
        for (int attackAreaCnt = 0; attackAreaCnt < attackAreas.Length; attackAreaCnt++)
        {
            // AttackArea 스크립트가 추가된 오브젝트의 컬라이더를 배열에 저장한다.
            attackAreaColliders[attackAreaCnt] = attackAreas[attackAreaCnt].GetComponent<Collider>();
            // 초기값을 false로 한다.
            attackAreaColliders[attackAreaCnt].enabled = false;
        }
	}
	
    void StartAttackHit()
    {
        foreach(Collider attackAreaCollider in attackAreaColliders)
            attackAreaCollider.enabled = true;
    }
    
    void EndAttackHit()
    {
         foreach(Collider attackAreaCollider in attackAreaColliders)
            attackAreaCollider.enabled = false;
    }
}
