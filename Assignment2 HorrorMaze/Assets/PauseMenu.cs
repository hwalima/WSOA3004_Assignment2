using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject pausedUI;
    private bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        pausedUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            paused = !paused;
        }

        #region cursorControl
        if (paused)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else {
            Cursor.lockState = CursorLockMode.Locked;
        }
        #endregion

        if (paused)
        {
            pausedUI.SetActive(true);
            Time.timeScale = 0;

        }

        if (!paused)
        {
            pausedUI.SetActive(false);
            Time.timeScale = 1;

        }
    }

    public void PauseGame()
    {
        paused = true;
    }

    public void Resume()
    {
        paused = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
