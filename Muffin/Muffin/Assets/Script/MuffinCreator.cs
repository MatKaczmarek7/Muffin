using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuffinCreator : MonoBehaviour {

    public GameObject muffinPrefab;
    public Transform parent;

    private void OnEnable()
    {
        InputDetector.OnDetectTap += CreateMuffin;
    }

    private void OnDisable()
    {
        InputDetector.OnDetectTap -= CreateMuffin;
    }

    [ContextMenu("Create")]
    private void CreateMuffin()
    {
        GameObject g=Instantiate(muffinPrefab, Vector3.zero, Quaternion.identity,parent);
        g.transform.localPosition = parent.localPosition;
    }
}
