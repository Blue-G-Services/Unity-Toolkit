using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Button leaderboardButton;
    [SerializeField]
    public Button achievementButton;
    [SerializeField]
    public Button friendsButton;
    [SerializeField]
    public Button chatButton;
    [SerializeField]
    public Button partiesButton;
    [SerializeField]
    public Button userButton;
    [SerializeField]
    public Button tableButton;
    [SerializeField]
    public Button devicesButton;

    [SerializeField]
    public Button logoutButton;
    
    void Start()
    {
        leaderboardButton.onClick.AddListener(() => SceneManager.LoadScene("leaderboard", LoadSceneMode.Single) );
        achievementButton.onClick.AddListener(() => SceneManager.LoadScene("achievement", LoadSceneMode.Single));
        friendsButton.onClick.AddListener(() => SceneManager.LoadScene("friends", LoadSceneMode.Single));
        chatButton.onClick.AddListener(() => SceneManager.LoadScene("chat", LoadSceneMode.Single));
        partiesButton.onClick.AddListener(() => SceneManager.LoadScene("party", LoadSceneMode.Single));
        userButton.onClick.AddListener(() => SceneManager.LoadScene("user", LoadSceneMode.Single));
        devicesButton.onClick.AddListener(() => SceneManager.LoadScene("devices", LoadSceneMode.Single));
        tableButton.onClick.AddListener(() => SceneManager.LoadScene("table", LoadSceneMode.Single));

        logoutButton.onClick.AddListener(() =>
        {
            DynamicPixels.Authentication.Logout();
            SceneManager.LoadScene("authentication", LoadSceneMode.Single);
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
