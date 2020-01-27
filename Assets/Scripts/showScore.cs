using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class showScore : MonoBehaviour {

    public Text showScores;
    private Scene mainScene;

    // Use this for initialization
    void Start()
    {
        mainScene = SceneManager.GetActiveScene();

        if (mainScene.name == "EndCredit")
        {
            showScores.text = "You Beat it! You Scored: " + PlayersController.myScore.ToString();
        }
        else if(mainScene.name != "EndCredi" || mainScene.name != "StartGame")
        {
            showScores.text = "Current Score: " + PlayersController.myScore.ToString();
        }
    }
}
