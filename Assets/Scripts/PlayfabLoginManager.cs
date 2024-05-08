using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabLoginManager : MonoBehaviour
{
    const string emailKey = "Email", passKey = "Password";

    public Text messageText;
    public Text errorMessage;

    #region Register
    [Header("Register UI:")]
    [SerializeField] TMP_InputField userName;
    [SerializeField] TMP_InputField userEmail;
    [SerializeField] TMP_InputField userPassword;


   

    public void onRegisterPressed()
    {
        Register(userName.text, userEmail.text, userPassword.text);
    }

    private void Register(string name, string email, string password)
    {
        if(password.Length < 6)
        {
            errorMessage.text = "Password must longer than 6 words or digits!!!";
            return;
        }
        //register new user with email, name, and password
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest()
        {
            DisplayName = name,
            Email = email,
            Password = password,
            RequireBothUsernameAndEmail = false

        },
        //if sucess, login with email and password, else error
        successResult => 
        {

            Login(email, password);
            messageText.text = "Registered and Logged in sucessfull, Welcome!";
            SceneManager.LoadScene("CharacterMenu");

        },
        PlayFabFailure); 
    }

    #endregion

    


    #region Login
    [Header("Login UI:")]
    [SerializeField] TMP_InputField loginEmail;
    [SerializeField] TMP_InputField loginPassword;

    public void onLoginPressed()
    {
       
        Login(loginEmail.text, loginPassword.text);
        
    }

    private void Login(string email, string password)
    {
        if(password.Length < 6)
        {
            errorMessage.text = "This is not your password!!!";
            return;
        }
  
        PlayFabClientAPI.LoginWithEmailAddress(new LoginWithEmailAddressRequest()
        {
            Email = email,
            Password = password,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams()
            {
                //return information
                GetPlayerProfile = true
            }

        },
        successResult =>
        {
            // if true, able to log in with email and password
            PlayerPrefs.SetString(emailKey, email);
            PlayerPrefs.SetString(passKey, password);
            PlayerPrefs.SetString("Username", successResult.InfoResultPayload.PlayerProfile.DisplayName);

            messageText.text = "Sucessfully Logged";
            Debug.Log("Sucessfully Logged In User :" + PlayerPrefs.GetString("Username"));

            SceneManager.LoadScene("CharacterMenu");
        },
        PlayFabFailure);
    }



    #endregion



    #region ResetPassword
    [SerializeField] TMP_InputField resetEmailInput;

    public void OnSendPressed()
    {
        sendResetEmail(resetEmailInput.text);
    }

    public void sendResetEmail(string email)
    {
        PlayFabClientAPI.SendAccountRecoveryEmail(new SendAccountRecoveryEmailRequest()
        {
            Email = email,
            TitleId = PlayFabSettings.TitleId
        },
        sucessResult => 
        {
            messageText.text = "Please check your email for renewing the password!";
            print("Sent Reset Email!");

        },
        PlayFabFailure);
    }
    #endregion





    private void PlayFabFailure(PlayFabError error)
    {
        errorMessage.text = error.ErrorMessage + ", You have error in eiher email or password";
        Debug.Log(error.Error + ":" + error.GenerateErrorReport());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
}
