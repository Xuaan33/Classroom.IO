using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public FixedJoystick movementJoystick;
    public FixedJoystick rotationJoystick;
    public GameObject grabButton;

    [SerializeField] private GameObject loginPanel;

    [SerializeField] private GameObject registrationPanel;

    [SerializeField] private GameObject resetPassPanel;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Find the UI elements in the scene and assign them to the variables
        FindUIElements();
    }

    private void FindUIElements()
    {
        // You may need to adjust the names or tags of your UI elements
        movementJoystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        rotationJoystick = GameObject.Find("Fixed Joystick (1)").GetComponent<FixedJoystick>();
        grabButton = GameObject.Find("Button");
    }

    private void CreateInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void OpenLoginPanel()
    {
        loginPanel.SetActive(true);
        registrationPanel.SetActive(false);
        resetPassPanel.SetActive(false);
    }

    public void OpenRegistrationPanel()
    {
        registrationPanel.SetActive(true);
        loginPanel.SetActive(false);
       resetPassPanel.SetActive(false);
    }

    public void OpenResetPassPanel()
    {
        resetPassPanel.SetActive(true);
        registrationPanel.SetActive(false);
        loginPanel.SetActive(false);
        
    }

    public void BackLoginPanel()
    {
        loginPanel.SetActive(true);
        resetPassPanel.SetActive(false);
       registrationPanel.SetActive(false);
    }
}
