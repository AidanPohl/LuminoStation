using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reciever : MonoBehaviour
{
    public bool Islit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Islit = true;
            GameManager.gameState = GameManager.gameStates.LevelWin;
            GameManager.timer.Stop();
        }
    }
}
