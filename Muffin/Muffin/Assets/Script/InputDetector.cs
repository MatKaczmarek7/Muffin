using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputDetector : MonoBehaviour
{
    private bool shouldDetectInput=false;

    public static event Action OnDetectTap;

    public void SetActiveInputDetector(bool enabled)
    {
        shouldDetectInput = enabled;
    }

    private void Update()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Ended && OnDetectTap != null && shouldDetectInput)
        {
            OnDetectTap();
        }
    }
}
