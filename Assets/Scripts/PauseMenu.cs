using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject gameMenu; // Reference to the inventory panel UI
    private bool menuActivated; // 

    // Start is called before the first frame update
    void Start()
    {
        gameMenu.SetActive(false);
        menuActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)) && menuActivated)
        {
            Time.timeScale = 1;
            gameMenu.SetActive(false);
            menuActivated = false;
        }

        else if ((Input.GetKeyDown(KeyCode.Escape)) && !menuActivated)
        {
            Time.timeScale = 0;
            gameMenu.SetActive(true);
            menuActivated = true;
        }
    }

    public void ResumeGame()
    {
        gameMenu.SetActive(false);
    }


}


