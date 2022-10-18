using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUI : MonoBehaviour
{
    //GUI

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 40, 20), "test"))
            Debug.Log("test button");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
