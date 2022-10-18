using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scorelabel;
    [SerializeField] private SettingsPopup settingsPopup;
    // Start is called before the first frame update
    void Start()
    {
        settingsPopup.Close();
    }

    // Update is called once per frame
    void Update()
    {
        scorelabel.text = Time.realtimeSinceStartup.ToString();
    }
    public void OnOpenSettings()
    {
        settingsPopup.Open();

    }

    public void onClosingSettings()
    {
        settingsPopup.Close();
    }
}
