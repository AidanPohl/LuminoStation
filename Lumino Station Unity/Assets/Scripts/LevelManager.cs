using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script assigned to each Level to manage it
public class LevelManager : MonoBehaviour
{
    public GameObject SelectionPoolPrefab;
    public WinCheck[] winChecks;
    // Start is called before the first frame update
    void Start()
    {
        StartLevel();
    }
    
    private void StartLevel()
    {
        //Instantiate(SelectionPoolPrefab);
        GameManager.gameState = GameManager.gameStates.Playing;
    }
    // Update is called once per frame

    public bool CheckWinConditions()
    {
        foreach (WinCheck check in winChecks)
        {
            if(check.fulfilled == false)
            {
                return false;
            }
        }
        return true;
    }
    private void EndLevel()
    {
        GameManager.gameState = GameManager.gameStates.LevelWin;
    }
    void Update()
    {
        if (CheckWinConditions())
        {
            EndLevel();
        }
    }
}
