using System.Collections;
using System.Collections.Generic;
using models;
using models.dto;
using models.inputs;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class auth : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI textMessage;

    [SerializeField]
    public TMP_InputField nameInput;

    [SerializeField]
    public TMP_InputField emailInput;

    [SerializeField]
    public TMP_InputField passwordInput;

    [SerializeField]
    public Button loginButton;

    [SerializeField]
    public Button registerButton;
    
    [SerializeField]
    public Button guestLoginButton;

    // Start is called before the first frame update
    void Start()
    {
        loginButton.onClick.AddListener(LoginHandle);
        registerButton.onClick.AddListener(RegisterHandle);
        guestLoginButton.onClick.AddListener(GuestHandle);
    }

    async void GuestHandle()
    {
        try
        {
            var result = await DynamicPixels.Authentication.LoginAsGuest(new LoginAsGuestParams
            {
                Device = new Device
                {
                    DeviceId = "12345"
                }
            });
            
            Debug.Log(result.Token);
        }
        catch (DynamicPixelsException e)
        {
            Debug.LogException(e);
        }
    }

    async void LoginHandle()
    {
        try
        {
            var input = new LoginWithEmailParams
            {
                email = emailInput.text,
                password = passwordInput.text
            };
            

            await DynamicPixels.Authentication.LoginWithEmail(input);

            SceneManager.LoadScene("mainMenu");
        }
        catch (DynamicPixelsException e)
        {
            Debug.LogException(e);
        }
    }
    
    async void RegisterHandle()
    {
        try
        {
            var input = new RegisterWithEmailParams
            {
                Name = nameInput.text,
                Email = emailInput.text,
                Password = passwordInput.text
            };
            

            var result = await DynamicPixels.Authentication.RegisterWithEmail(input);
           
            SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
        }
        catch (DynamicPixelsException e)
        {
            Debug.LogException(e);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
