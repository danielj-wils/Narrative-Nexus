using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPromptActiveness : MonoBehaviour
{
    public static ControlPromptActiveness instance;
    public Canvas canvas;
    public GameMenu gameMenu;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (canvas.gameObject.activeSelf || gameMenu.gameObject.activeSelf)
            {
                this.gameObject.SetActive(true);
            } 

        else
            {
                this.gameObject.SetActive(false);
            }           
    }
}
