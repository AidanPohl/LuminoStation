/**
 * Created By: Aidan Pohl
 * Created: 03/06/2022
 * 
 * Last Edited By: N/A
 * Last Edited: N/A
 * 
 * Description: Update global text in start canvas
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Reference to user interface

public class StartCanvas : MonoBehaviour
{   
/***VARIABLES***/
    GameManager gm; //reference to the game manager

    [Header("Canvas Settings")]
    public Text titleTextBox;
    public Text creditsTextBox;
    public Text copyrightTextBox;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GM;
        titleTextBox.text = gm.gameTitle;
        creditsTextBox.text = gm.gameCredits;
        copyrightTextBox.text = gm.copywriteDate;
    }

    public void StartGame(){
        gm.StartGame();
    }

    public void ExitGame(){
        gm.ExitGame();
    }
}
