using UnityEngine;
using System.Collections;

public class GameRuleCtrl : MonoBehaviour 
{
    public float timeRemaining = 5.0f * 60.0f;
    public bool gameOver = false;
    public bool gameClear = false;
    
    // 씬 이행 시간.
    public float sceneChangeTime = 3.0f;
    
	// Update is called once per frame
	void Update () 
    {
        
        // 게임 종료 조건 성립 후 씬 전환.
        if(gameOver || gameClear)
        {
            sceneChangeTime -= Time.deltaTime;
            if(sceneChangeTime <= 0.0f)
            {
                Application.LoadLevel("titleScene");
            }
            return;
        }
        
        timeRemaining -= Time.deltaTime;
        // 남는 시간이 없어지면 게임 오버.
        if(timeRemaining <= 0.0f)
        {
            GameOver();
        }	
	}
    
    public void GameOver()
    {
        gameOver = true;
        Debug.Log("GameOver");
    }
    
    public void GameClear()
    {
        gameClear = true;
        Debug.Log("GameClear");
    }
}
