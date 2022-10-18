using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsPopup : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider speedSlider;

    public void OnSubmitName(string name)
    {
        Debug.Log(name);
    }

    public void OnSpeedValue(float speed)
    {
        Debug.Log("speed:" + speed);
    }
    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        speedSlider.value = PlayerPrefs.GetFloat("speed", 1);
        
    }

    // Update is called once per frame
    void Update()
    {

            
    }
}
