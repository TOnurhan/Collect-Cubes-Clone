using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager = default;
    void Initiliazed()
    {
        MagneticField.CubeEntered += HandleLevel;
    }
    void Awake()
    {
        Initiliazed();
    }

    public void HandleLevel()
    {
        gameManager.currentCubeCount++;
        gameManager.ProgressBar();
        //if(GameManager.Instance.levelCube+Count == GameManager.Instance.currentCubeCount)
        //{
            gameManager.LevelCompleted();
        //}
    }
}
