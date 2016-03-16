﻿using UnityEngine;
using System.Collections;

public class EnemyGeneratorCtrl : MonoBehaviour 
{
    // 생겨날 적 프리팹 
    public GameObject enemyPrefab;
    
    // 적을 저장한다.
    public GameObject[] existEnemys;
    
    // 액티브 최대 수
    public int maxEnemy = 2;
    
	// Use this for initialization
	void Start () 
    {
	    // 배열 확보
        existEnemys = new GameObject[maxEnemy];
        
        // 주기적으로 실행하고 싶을 때는 코루틴을 사용하면 쉽게 구현 가능.
        StartCoroutine(Exec());
	}
	
    IEnumerator Exec()
    {
        while (true)
        {
            Generator();
            yield return new WaitForSeconds(3.0f);
        }
    }
    
    void Generator()
    {
        for (int enemyCount = 0; enemyCount < existEnemys.Length; enemyCount++)
        {
            if(existEnemys[enemyCount] == null)
            {
                // 적 생성.
                existEnemys[enemyCount] = Instantiate(enemyPrefab, transform.position,
                transform.rotation) as GameObject;
                
                return;
            }
        }
    }
}
