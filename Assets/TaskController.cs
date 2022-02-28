  using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using VRTK;
using Zinnia.Haptics;

public class TaskController : MonoBehaviour
{
    public GameObject otherController;
    private int _framesSinceLastSave = 0;
    public int tasksAchieved = 0, totalTasks = 0;
    [HideInInspector]
    public List<string> taskObservations;
    private const string taskHeaderWithTime = "time_ms,pos_x,pos_y,pos_z,rot_x,rot_y,rot_z\n";
    //public bool reset = false;
    public string task = "";


    private void Start()
    {
        Debug.Log("TASK CONTROLLER START");
    }

    /*
    private void FixedUpdate()
    {
       //ebug.Log("TASK CONTROLLER FIXED");
        if (Input.GetKeyDown(KeyCode.Return) && _framesSinceLastSave >= 90)
        {
            SaveTasks();
            taskObservations.Clear();
            tasksAchieved = 0;
            _framesSinceLastSave = 0;
        }

        _framesSinceLastSave += 1;

        if (Input.GetKeyDown(KeyCode.L))
        {
            transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
        } 
        else if (Input.GetKeyDown(KeyCode.S))
        {
           transform.localScale -= new Vector3(0.1F, 0.1f, 0.1f);
        }
    }

    public void SaveTasks()
    {
        Debug.Log("TASK CONTROLLER SAVE");
        Debug.Log("attempting to save the tasks");
        Debug.Log("task len:" + taskObservations.Count);
        var startTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        RecordTrackedAlias.SavePositionsAndRotationsToDiskAndAnalyze(taskHeaderWithTime, taskObservations,
            $"recordingcoolbeans_{startTime}_taskTracking");
        
    }

    private void Update()
    {
        Debug.Log("Update " + _framesSinceLastSave);
        _framesSinceLastSave += 1;
    }

*/

    public void LockTransformToController()
    {
        // Debug.Log("TASK CONTROLLER LOCK");
        if (task.Equals("SquareTask"))
        {
            //offsets for square model (rotation is off)
            transform.eulerAngles = new Vector3(0, 90, 0);
            transform.position = new Vector3(otherController.transform.position.x-0.25f, otherController.transform.position.y-0.5f, otherController.transform.position.z);
            transform.eulerAngles = new Vector3(0, 90, 0);
            //Debug.Log("rotate square " + transform.position + transform.rotation+transform.eulerAngles+transform.rotation.eulerAngles);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.position = new Vector3(otherController.transform.position.x, otherController.transform.position.y, otherController.transform.position.z);

            //transform.SetPositionAndRotation(otherController.transform.position + otherController.transform.forward * 0.2f, otherController.transform.rotation);
            //Debug.Log("rotate not square " + transform.position + transform.rotation + transform.eulerAngles + transform.rotation.eulerAngles);

        }
    }

    public void HorizontalTransform()
    {
       // Debug.Log("HORIZONTAL " + transform.position + " / " + transform.rotation);

        /*when they finish the task make sure it is reverted back to vertical
            if (reset)
            {
            reset = false;
            /*
                if (task.Equals("SquareTask"))
                {
                    transform.eulerAngles = new Vector3(0, 90, 0);
                    reset = false;
                    Debug.Log("HORIZONTAL reset square" + transform.position + " / " + transform.rotation);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, otherController.transform.rotation.y, otherController.transform.rotation.z);
                    reset = false;
                     Debug.Log("HORIZONTAL reset not square" + transform.position + " / " + transform.rotation);
                }
            }
            else
            {
        */
                //pressed trackpad to go horizontal
                if (task.Equals("SquareTask"))
                {
                    transform.eulerAngles = new Vector3(0, 90, 90);
                    transform.position = new Vector3(otherController.transform.position.x-0.5f, otherController.transform.position.y + 0.2f, otherController.transform.position.z);
                    //Debug.Log("HORIZONTAL square" + transform.position + " / " + transform.rotation + transform.eulerAngles + transform.rotation.eulerAngles);
                }
                else
                {
                    transform.eulerAngles = new Vector3(90, 0, 0);
                    //Debug.Log("HORIZONTAL not square" + transform.position + " / " + transform.rotation + transform.eulerAngles + transform.rotation.eulerAngles);
                }
            //}
    }
} 
  