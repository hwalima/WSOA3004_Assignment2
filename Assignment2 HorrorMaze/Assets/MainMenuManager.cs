using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject controlsPanel;
    bool toggleControlsButton = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Controls()
    {
        toggleControlsButton = !toggleControlsButton;
        controlsPanel.SetActive(toggleControlsButton);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
