using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCTools : MonoBehaviour
{

    public static string DeltaTimeString(float unixTimeStartMilliseconds)
    {
        return (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - unixTimeStartMilliseconds).ToString("F5");
    }
 
}
