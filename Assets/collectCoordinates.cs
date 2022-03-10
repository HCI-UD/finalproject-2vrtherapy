using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectCoordinates : MonoBehaviour
{
    public string task;

    //only done once per level, not continuously collecting
    public void collect()
    {
        string filePath = "D:dataCollection/exportModel_"  + task + "_" + System.DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".csv";
        string coordinates = "Time collected, Cylinder #, X, Y, Z, Pitch, Yaw, Roll" + System.Environment.NewLine;
        SphereCollider[] cylinders;

        if (task.Equals("ChickenTask"))
        {
            cylinders = transform.GetChild(0).GetChild(2).GetComponentsInChildren<SphereCollider>();
        }
        else if (task.Equals("FishTask"))
        {
            cylinders = transform.GetChild(1).GetComponentsInChildren<SphereCollider>();
        }
        else // 3d fish, square
        {
            cylinders = transform.GetChild(0).GetComponentsInChildren<SphereCollider>();
        }

        foreach (SphereCollider cylinder in cylinders)
        {
            coordinates += System.DateTime.Now.ToString("hh:mm:ss") + "," + cylinder.name.Substring(cylinder.name.Length - 3) + "," + cylinder.center.x + "," + cylinder.center.y + "," + cylinder.center.z + "," + cylinder.transform.rotation.eulerAngles.x + "," + cylinder.transform.rotation.eulerAngles.y + "," + cylinder.transform.rotation.eulerAngles.z + System.Environment.NewLine;
        }

            //Write the coords to a file
            System.IO.File.WriteAllText(filePath, coordinates);

        Debug.Log("collect coordinates done");
    }
}
