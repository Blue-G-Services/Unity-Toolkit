using System;
using System.Collections;
using System.Collections.Generic;
using models.inputs;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class user : MonoBehaviour
{

    [SerializeField] public Button GetCurrentUserButtton;
    [SerializeField] public Button GetUserButtton;
    [SerializeField] public Button BackButton;
    [SerializeField] public TMP_InputField UserIdInput;
    [SerializeField] public TextMeshProUGUI Payload;
    
    // Start is called before the first frame update
    void Start()
    {
        GetCurrentUserButtton.onClick.AddListener(async () =>
        {
            var user = await DynamicPixels.Table.GetServices().Users.GetCurrentUser();
            Payload.text = $"ID: {user.Id}\nName:{user.Name}\n";
        }); 
        
        GetUserButtton.onClick.AddListener(async () =>
        {
            var userId = UserIdInput.text;
            var user = await DynamicPixels.Table.GetServices().Users.FindUserById(new FindUserByIdParams
            {
                UserId = Int32.Parse(userId)
            });
            Payload.text = $"ID: {user.Id}\nName:{user.Name}\n";
        });
        
        BackButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("mainMenu");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
