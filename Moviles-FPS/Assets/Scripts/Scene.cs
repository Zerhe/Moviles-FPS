using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

    [SerializeField]
    private GameObject panelPausa;
    private bool pause = false;

	void Start ()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        panelPausa.SetActive(false);
    }
	void Update ()
    {
        if (Input.GetButtonDown("Cancel") && !pause)
        {
            PauseGame();
        }
        else if (Input.GetButtonDown("Cancel") && pause)
        {
            ResumeGame();
        }
    }
    public void PauseGame()
    {
        pause = true;
        panelPausa.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
    }
    public void ResumeGame()
    {
        pause = false;
        panelPausa.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
    }
    public void ChangeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
    public void QuitGame()
    {
        Application.Quit();

    }
}
