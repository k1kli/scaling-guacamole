using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RectTransform pausePanel;
    public Player player;
    public TimeController timeController;
    private bool paused = false;
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
}
