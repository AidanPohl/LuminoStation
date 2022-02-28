/**
 * Created By: Aidan Pohl
 * Created: 02/23/2022
 * 
 * Last Edited By: N/A
 * Last Edited: N/A
 * 
 * Description: Game Managaer
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    /***VARIABLES***/
    #region GameManager Singleton
    static private GameManager gm; // reference to Game Manager
    static public GameManager GM  { get {   return gm;  }   }//public access to Game manager

    void CheckGameManagerIsInScene(){
        if (gm ==null){
            gm = this;
        }else{
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this); //Do not destroy the game manager when new scene is loaded
            }
    
    #endregion

[Header("General Settings")]
public string  gameTitle = "Lumino Station";
public string gameCredits = "Made by: Aidan Pohl";
public string copyrightDate = "Copyright " + thisDate;

[Header("Game Settings")]

[Tooltip("Is the level timed?")]
public bool isTimed = false;//
public int timeLimit = 0;

static private int time = 0;

[Header("Scene Settings")]
[Tooltip("Name of start scene")]
public string startString;

[Tooltip("Name of end Scene")]
public string endScene;

[Tooltip("Count and name of each scene")]
public string[] gameLevels;
private int gameLevelsCount;
[SerializeField]private bool nextLevel = false;//test for next level

public static int currentScene = 0; //the current level id

[HideInInspector] public enum gameStates {Idle,Playing,StartScreen,LevelWin,GameWin};//enum of game states
[HideInInspector] public static gameStates gameState = gameStates.Idle; //curent gamestate

private float currentTime;
private bool gameStarted = false;

private static string thisDate = System.DateTime.Now.ToString("yyyy"); //todays date as string

/***Methods***/
void Awake(){
    CheckGameManagerIsInScene();

    currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
    Debug.Log(currentScene);
        gameState = gameStates.Playing;
}//end Awake()

void Update(){
    if(Input.GetKey("escape")){ExitGame();} //esc key to exit game

    if(nextLevel){NextLevel();} // move to next level 

    //if we are playing the game
    if(gameState == gameStates.Playing){

    } else if (gameState == gameStates.LevelWin)
    {
            Invoke("NextLevel", 5);
            gameState = gameStates.Idle;
    }
}
public void StartGame(){
    gameLevelsCount = 0;
    SceneManager.LoadScene(gameLevels[gameLevelsCount]); //load first level
    gameState = gameStates.Playing;//playing game state
}//end StartGame();

public void ExitGame(){
    Application.Quit();
    Debug.Log("Exited Game");
}

public void GameEnd(){
    gameState = gameStates.GameWin;//game end state
    SceneManager.LoadScene(endScene);
    Debug.Log("Game End Scene");
}

public void NextLevel(){
        Debug.Log("level complete");
    nextLevel = false;
    if(gameLevelsCount <= gameLevels.Length){
        gameLevelsCount++;
        SceneManager.LoadScene(gameLevels[gameLevelsCount]);
    }
}
    public void EndLevel()
    {
        //GameObject.Find("LazerPointer").GetComponent<LaserBeam>().GreenLaser();
    }

}
