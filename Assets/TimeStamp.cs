using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TimeStamp : MonoBehaviour {
    
    private float frameTime;
    private int counter;

    private TextMeshProUGUI tmp;
    // Use this for initialization
    private void Start () {
        tmp = this.GetComponent<TextMeshProUGUI>();
        tmp.text = "1234";
    }

    // Update is called once per frame
    
    
    private void FixedUpdate ()
    {
        if (Time.frameCount % 12 != 0) return;
        tmp.text = RecordTrackedAlias.GameMillisToString();
    }
}