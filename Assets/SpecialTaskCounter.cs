using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecialTaskCounter : MonoBehaviour
{
    private TaskController taskControllerScript;
    private exportController exportControllerScript;
    private collectCoordinates collectCoordsScript;
    public ResetDots ResetDotsScript;
    private TextMeshProUGUI tmp;
    private string totalCount;
    private int totalInt;
    private bool calledAlready;

    public GameObject squareDots;

    private int success;
    public bool unlockVictory;

    public string currentTask;

    // Start is called before the first frame update
    public void Start()
    {
        tmp = this.GetComponent<TextMeshProUGUI>();
        taskControllerScript = null;
        unlockVictory = true;
        exportControllerScript = GameObject.Find("RightControllerAlias").GetComponent<exportController>();
        Debug.Log("Task Counter Started");
        calledAlready = false;
    }

    public void restart()
    {
        tmp.text = "Dots Completed: 0";
        success = 0;
        taskControllerScript = null;
        unlockVictory = true;
        exportControllerScript.task = currentTask;
        exportControllerScript.restartCollection();
        Debug.Log("Task Counter REStarted" + success + taskControllerScript);
        calledAlready = false;
    }

    // Update is called once per frame
    private void Update()
    {

        //Debug.Log("TC UPDATE " + currentTask);
        if (taskControllerScript == null)
        {
           if (currentTask == "SquareTask")
            {
                taskControllerScript = GameObject.Find("SquareTask").GetComponent<TaskController>();
                Debug.Log("TC SQUARE");
                totalCount = "/40";
                totalInt = 40;
                taskControllerScript.totalTasks = totalInt;
                taskControllerScript.task = currentTask;
            }
        }
        else
        {
            //once they commit to starting the task, the location of the model is locked in for the data collection
            if (taskControllerScript.tasksAchieved == 1 && calledAlready==false)
            {
                collectCoordsScript = GameObject.Find(currentTask).GetComponent<collectCoordinates>();
                collectCoordsScript.task = currentTask;
                collectCoordsScript.collect();
                calledAlready = true;
            }

            //Debug.Log("TC ELSE " + taskControllerScript.tasksAchieved + "out of "+totalInt);
            if (Time.frameCount % 10 == 0)
            {
                tmp.text = taskControllerScript.tasksAchieved + totalCount;

                unlockVictory = true;

                if (taskControllerScript.tasksAchieved == totalInt && success == 0 && unlockVictory == true)
                {
                    exportControllerScript.Stop();
                    //instead of victory playing, reset dots and data collection scripts
                    ResetDotsScript.task = currentTask;
                    ResetDotsScript.Start();
                    ResetDotsScript.ResetAllDots();
                    taskControllerScript.tasksAchieved = 0;
                    taskControllerScript = null;
                    restart();
                }
            }
        }
    }
}
