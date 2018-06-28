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
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        panelPausa.SetActive(false);
    }
	void Update ()
    {
        if (Input.GetButtonDown("Cancel") && !pause)
        {
            pause = true;
            panelPausa.SetActive(true);
            Cursor.visible = true;
        }
        else if (Input.GetButtonDown("Cancel") && pause)
        {
            pause = false;
            panelPausa.SetActive(false);
            Cursor.visible = false;
        }
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
