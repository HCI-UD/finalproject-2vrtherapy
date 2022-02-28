using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exportHits : MonoBehaviour
{

    public string filePath, coordinates, task;
    public void startCollection()
    {
        Debug.Log("Export Hits started");
        filePath = "D:dataCollection/exportHits_" + task + "_" + System.DateTime.Now.ToString("yyyy-MM-dd_hh-mm") + ".csv";
        coordinates = "Cylinder #, Time Hit, Date" + System.Environment.NewLine;
    }

    public void stopCollection()
    {
        Debug.Log("Export Hits stopped");
        System.IO.File.WriteAllText(filePath, coordinates);
    }
}
