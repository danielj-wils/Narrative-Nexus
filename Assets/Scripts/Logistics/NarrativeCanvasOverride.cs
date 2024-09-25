using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeCanvasOverride : MonoBehaviour
{
    public Canvas narrativeCanvas;
    public string canvasTag = "NarrativeCanvas";

    // public GameObject gameMenu;
    public GameObject enemyObjectsToActivate;
    public GameObject coinObjectsToActivate;
    public GameObject playerObjectsToActivate;
    //public GameObject ManagersToActivate;
    //public GameObject TimeManagerToActivate;
    //public GameObject ProfileManagerToActivate;
    //public GameObject UIElementsToActivate;

    private void Awake() 
    {
        // If the canvas is null, find it by its tag in the scene
        if (narrativeCanvas == null)
        {
            GameObject foundCanvasObject = GameObject.FindWithTag(canvasTag);
            if (foundCanvasObject != null)
            {
                narrativeCanvas = foundCanvasObject.GetComponent<Canvas>();
            }
            else
            {
                Debug.LogWarning($"Canvas with the tag '{canvasTag}' not found in the scene!");
            }
        }  
        
        if (narrativeCanvas.gameObject.activeSelf == false)
        {
            narrativeCanvas.gameObject.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (enemyObjectsToActivate != null)
        {
            enemyObjectsToActivate.SetActive(false);
        }

        if (coinObjectsToActivate != null)
        {
            coinObjectsToActivate.SetActive(false);
        }

      //if (gameMenu != null)
      //{
      //    gameMenu.SetActive(false);
      //}

        //if (playerObjectsToActivate != null)
        //{
        //    playerObjectsToActivate.SetActive(false);
        //}
        //
        //if (ManagersToActivate != null)
        //{
        //    ManagersToActivate.SetActive(false);
        //}

        //if (TimeManagerToActivate != null)
        //{
        //    TimeManagerToActivate.SetActive(false);
        //}

        //if (ProfileManagerToActivate != null)
        //{
        //    ProfileManagerToActivate.SetActive(false);
        //}

        //if (UIElementsToActivate != null)
        //{
        //    UIElementsToActivate.SetActive(false);
        //}
        //
    }

    // Update is called once per frame
    void Update()
    {
        if (!narrativeCanvas.gameObject.activeSelf)
        {
            enemyObjectsToActivate.SetActive(true);
            coinObjectsToActivate.SetActive(true);
            //playerObjectsToActivate.SetActive(true);
            //ManagersToActivate.SetActive(true);
            //TimeManagerToActivate.SetActive(true);
            //ProfileManagerToActivate.SetActive(true);
            //UIElementsToActivate.SetActive(true);

        }
        
        FindObjectOfType<GameMenu>();

        if (GameMenu.instance.gameObject.activeSelf)
        {
            enemyObjectsToActivate.SetActive(false);
            //playerObjectsToActivate.SetActive(false);
            StartCoroutine(DelayCoins());
        }
    }

    private IEnumerator DelayCoins()
    {
        yield return new WaitForSeconds(0.01f);
        coinObjectsToActivate.SetActive(false);
    }
}
