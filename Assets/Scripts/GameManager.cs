using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public RectTransform pausePanel;
    public Player player;
    public TimeController timeController;
    private bool paused = false;
    public int[] levelsBuildIndexes;
    private int currentLevelIndexInArray = -1;
    public void Awake()
    {
        LoadLevel(0);
    }

    public void LoadLevel(int levelId)
    {
        if (currentLevelIndexInArray != -1)
        {
            SceneManager.UnloadSceneAsync(levelsBuildIndexes[currentLevelIndexInArray]);
        }
        currentLevelIndexInArray = levelId;

        SceneManager.LoadSceneAsync(levelsBuildIndexes[currentLevelIndexInArray], LoadSceneMode.Additive)
            .completed += a=>
            {
                GameObject[] rootObjects = SceneManager
                .GetSceneByBuildIndex(levelsBuildIndexes[currentLevelIndexInArray])
                .GetRootGameObjects();
                
                var spawnObject = Array.Find(rootObjects, go => go.CompareTag("PlayerSpawn"));
                Vector3 position;
                Quaternion rotation;
                if (spawnObject == null)
                {
                    position = Vector3.zero;
                    rotation = Quaternion.identity;
                }
                else
                {
                    position = spawnObject.transform.position;
                    rotation = spawnObject.transform.rotation;
                }
                player.MovePlayer(position, rotation);
                if (paused)
                {
                    PauseUnpauseGame();
                }
            };

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpauseGame();
        }
    }
    private void PauseUnpauseGame()
    {
        if(paused)
        {
            paused = false;
            timeController.Enable();
            timeController.SetTimescale(1.0f);
            player.enabled = true;
            pausePanel.gameObject.SetActive(false);
        }
        else
        {
            paused = true;
            timeController.SetTimescale(0.0f);
            timeController.Disable();
            player.enabled = false;
            pausePanel.gameObject.SetActive(true);
        }
    }
    public void RestartGame()
    {
        PauseUnpauseGame();
        SceneManager.LoadScene(0);
        SceneManager.LoadScene(currentLevelIndexInArray);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
