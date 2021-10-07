using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    
    public Button escape;
    public Button Respawn;
    public bool EscapeMenuOpen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (EscapeMenuOpen == false)
            {
                EscapeMenuOpen = true;
                escape.gameObject.SetActive(true);
                Respawn.gameObject.SetActive(true);
            }
            else
            {
                EscapeMenuOpen = false;
                escape.gameObject.SetActive(false);
                Respawn.gameObject.SetActive(false);
            }
        }

    }

    public void respawn()
    {
        SceneManager.LoadScene(0);
    }

    public void Escape()
    {
        Application.Quit();
    }
 }
    
    
