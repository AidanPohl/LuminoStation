/**
 * Created By: Aidan Pohl
 * Created: 03/06/2022
 * 
 * Last Edited By: N/A
 * Last Edited: N/A
 * 
 * Description: Update global text in end screen canvas
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Reference to user interface

public class EndCanvas : MonoBehaviour
{       /***VARIABLES***/
    GameManager gm; //reference to the game manager

    [Header("Canvas Settings")]
    public Text timer;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GM;
        timer.text ="Game Won in "+GameManager.timer.Elapsed.Duration().ToString(@"hh\:mm\:ss");
    }

    public void StartScreen(){
        gm.StartScreen();
    }

    public void ExitGame(){
        gm.ExitGame();
    }
}
