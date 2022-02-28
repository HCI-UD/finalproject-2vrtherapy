using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskCounter : MonoBehaviour
{
    private TaskController taskControllerScript;
    private exportController exportControllerScript;
    private collectCoordinates collectCoordsScript;
    private TextMeshProUGUI tmp;
    private string totalCount;
    private int totalInt;

    public GameObject victoryObj;
    private ParticleSystem victory;
    public GameObject victoryFish;
    public GameObject victoryChick;
    public GameObject victorySquare;
    public GameObject fishDots;
    public GameObject chickDots;
    public GameObject squareDots;
    public GameObject threeDfishDots;
    
    private int success;
    public bool unlockVictory; 

    public GameObject afterMenu1;
    public GameObject afterMenu2;

    public string currentTask;

    // Start is called before the first frame update
    public void Start()
    {
        tmp = this.GetComponent<TextMeshProUGUI>();
        victory= victoryObj.GetComponent<ParticleSystem>();
        victory.Stop(true);
        taskControllerScript = null;
        unlockVictory = true;
        exportControllerScript = GameObject.Find("RightControllerAlias").GetComponent<exportController>();
        Debug.Log("Task Counter Started");
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
    }

    // Update is called once per frame
    private void Update()
    {

       //Debug.Log("TC UPDATE " + currentTask);
        if (taskControllerScript == null)
        {
            //Debug.Log("TC IF");
            if (currentTask == "ChickenTask")
            {
                taskControllerScript = GameObject.Find("ChickenTask").GetComponent<TaskController>();
                Debug.Log("TC CHICK");
                totalCount = "/150";
                totalInt = 150;
                taskControllerScript.totalTasks = totalInt;
                taskControllerScript.task = currentTask;
            }
            else if (currentTask == "FishTask")
            {
                taskControllerScript = GameObject.Find("FishTask").GetComponent<TaskController>();
                Debug.Log("TC FISH");
                totalCount = "/69";
                totalInt = 69;
                taskControllerScript.totalTasks = totalInt;
                taskControllerScript.task = currentTask;
            }
            else if (currentTask == "SquareTask")
            {
                taskControllerScript = GameObject.Find("SquareTask").GetComponent<TaskController>();
                Debug.Log("TC SQUARE");
                totalCount = "/40";
                totalInt = 40;
                taskControllerScript.totalTasks = totalInt;
                taskControllerScript.task = currentTask;
            }
            else if (currentTask == "ThreeDFishTask")
            {
                taskControllerScript = GameObject.Find("ThreeDFishTask").GetComponent<TaskController>();
                Debug.Log("TC 3D Fish");
                totalCount = "/90";
                totalInt = 90;
                taskControllerScript.totalTasks = totalInt;
                taskControllerScript.task = currentTask;
            }
        }
        else
        {
            //once they commit to starting the task, the location of the model is locked in for the data collection
            if (taskControllerScript.tasksAchieved == 1)
            {
                collectCoordsScript = GameObject.Find(currentTask).GetComponent<collectCoordinates>();
                collectCoordsScript.task = currentTask;
                collectCoordsScript.collect();
            }

            //Debug.Log("TC ELSE " + taskControllerScript.tasksAchieved + "out of "+totalInt);
            if (Time.frameCount % 10 == 0)
            {
                tmp.text = taskControllerScript.tasksAchieved + totalCount;

                unlockVictory = true;
                
                if (taskControllerScript.tasksAchieved == totalInt && success == 0 && unlockVictory == true)
                {
                    Debug.Log("VICTORY");
                    victory.Play(true);
                    victoryObj.transform.position = new Vector3(0, 0, 0);

                    if (currentTask == "FishTask" || currentTask == "ThreeDFishTask")
                    {
                       // taskControllerScript.reset = true;
                       // taskControllerScript.HorizontalTransform();
                        victoryFish.SetActive(true);
                        fishDots.transform.position = new Vector3(0f, -50f, 0f);
                        threeDfishDots.transform.position = new Vector3(0f, -50f, 0f);
                    }
                    else if (currentTask == "ChickenTask")
                    {
                        //taskControllerScript.reset = true;
                        //taskControllerScript.HorizontalTransform();
                        victoryChick.SetActive(true);
                        chickDots.transform.position = new Vector3(0f, -50f, 0f);
                    }
                    else if (currentTask == "SquareTask")
                    {
                        //taskControllerScript.reset = true;
                        //taskControllerScript.HorizontalTransform();
                        victorySquare.SetActive(true);
                        victorySquare.transform.position = new Vector3(-0.038f, 1.38f, 1.33f);
                        Renderer[] childrenR = victorySquare.GetComponentsInChildren<Renderer>();
                        foreach (var ch in childrenR)
                        {
                            ch.material.color=Color.magenta;
                        }
                        squareDots.transform.position = new Vector3(0f, -50f, 0f);

                    }

                    if (success == 0)
                    {
                        Invoke("Stop", 5.0f);
                    }
                }
            }
        }
    }

    private void Stop()
    {
        //Stop() runs multiple times i.e. success counter keeps running up so ==0 ensures it only runs once
        if (success == 0)
        {
            exportControllerScript.Stop();
            victoryFish.SetActive(false);
            victoryChick.SetActive(false);
            victorySquare.SetActive(false);
            victory.Stop(true);
            afterMenu1.SetActive(true);
            afterMenu2.SetActive(true);
            afterMenu1.transform.position = new Vector3(0.064833f, 1.651885f, 0.394774f);
            afterMenu2.transform.position = new Vector3(0.064833f, 1.13798f, 0.394774f);
            taskControllerScript.tasksAchieved = 0;
            taskControllerScript = null;
        }
        unlockVictory = false;
        success += 1;
    }
}
