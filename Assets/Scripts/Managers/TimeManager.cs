using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    [SerializeField] private float sceneStartTimer;
    [SerializeField] private float sceneEndTimer;
    [SerializeField] public float timeTaken = 0f;

    //private Canvas canvas;
    public GameObject gameMenu;
    [SerializeField] private bool allowStartTimerSet = true;
    [SerializeField] private bool allowEndTimerSet = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
          //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

    public void ResetTimers()
    {
        allowStartTimerSet = true;
        allowEndTimerSet = true;

        sceneStartTimer = 0f;
        sceneEndTimer = 0f;
    }


    private void Update()
    {
        FindObjectOfType<GameMenu>();

        if (allowStartTimerSet && !CanvasInstance.instance.gameObject.activeSelf)
        {
            SetStartTime();
        }

        if (allowEndTimerSet && gameMenu.gameObject.activeSelf)
        {
            SetEndTime();
        }

        if (!allowStartTimerSet && !allowEndTimerSet)
        {
            CalculateTimeTaken();
        }
    }

    public void SetStartTime()
    {
        sceneStartTimer = Time.time;
        allowStartTimerSet = false;
    }

    private void SetEndTime()
    {
        sceneEndTimer = Time.time;
        allowEndTimerSet = false;
    }

    public void CalculateTimeTaken()
    {
        timeTaken = sceneEndTimer - sceneStartTimer;
    }

    public float GetTimeTaken()
    {
        return timeTaken;
    }
}
