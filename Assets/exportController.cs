using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exportController : MonoBehaviour
{
    public string filePath, coordinates, task;

    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log("export controller start");
    }

    public void restartCollection()
    {
        Debug.Log("export controller restart" + task);
        filePath = "D:dataCollection/exportController_" + task + "_" + System.DateTime.Now.ToString("yyyy-MM-dd_hh-mm") + ".csv"; //new name everytime played so file doesn't get overwritten
        //pitch is the rotation angle around the x axis, yaw is for y axis, and roll is for z axis
        //https://dcnpy7o9bh2w4.cloudfront.net/wp-content/uploads/sites/8/2018/04/02032821/HTC-Vive-Tracker-2018-Developer-Guidelines_v1.4.pdf
        coordinates = "Time, X, Y, Z, Pitch, Yaw, Roll" + System.Environment.NewLine;
    }

    // Update is called once per frame
    void Update()
    {
        coordinates+= System.DateTime.Now.ToString("hh:mm:ss") + "," + transform.localPosition.x + "," + transform.localPosition.y + "," + transform.localPosition.z + "," + transform.rotation.eulerAngles.x + "," + transform.rotation.eulerAngles.y +  "," + transform.rotation.eulerAngles.z + System.Environment.NewLine;
        //Debug.Log("export controller update");
    }

    public void Stop()
    {
        //Write the coords to a file
        System.IO.File.WriteAllText(filePath, coordinates);
        Debug.Log("export controller stop " + filePath);
    }
}
