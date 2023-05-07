using System;
using System.Collections;
using System.Collections.Generic;
using models.inputs;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class friendship : MonoBehaviour
{
    [SerializeField] public Button BackButton;
    [SerializeField] public Button RequestButton;
    [SerializeField] public Button AcceptButton;
    [SerializeField] public Button RejectButton;
    [SerializeField] public Button RejectAllButton;
    [SerializeField] public Button DeleteButton;
    
    [SerializeField] public Button FriendsButton;
    [SerializeField] public Button RequestsButton;

    [SerializeField] public TMP_InputField IdInput;

    // Start is called before the first frame update
    void Start()
    {
        var id = IdInput.text;
        
        BackButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("mainMenu");
        });   
        
        FriendsButton.onClick.AddListener(async () =>
        {
            var friends = await DynamicPixels.Table.GetServices().Friendship.GetMyFriends(new GetMyFriendsParams { });
            foreach (var f in friends)
            {
                Debug.Log(f.ToString());
            }
        });
        
        RequestsButton.onClick.AddListener(async () =>
        {
            var requests = await DynamicPixels.Table.GetServices().Friendship.GetMyFriendshipRequests(new GetMyFriendshipRequestsParams { });
            foreach (var r in requests)
            {
                Debug.Log(r.ToString());
            }
        });
        
        RequestButton.onClick.AddListener(async () =>
        {
            var request = await DynamicPixels.Table.GetServices().Friendship.RequestFriendship(
                new RequestFriendshipParams
                {
                    UserId = Convert.ToInt32(id)
                });
        });
        
        AcceptButton.onClick.AddListener(async () =>
        {
            var request = await DynamicPixels.Table.GetServices().Friendship.AcceptRequest(
                new AcceptRequestParams()
                {
                    RequestId = Convert.ToInt32(id)
                });
        });
        
        RejectButton.onClick.AddListener(async () =>
        {
            var request = await DynamicPixels.Table.GetServices().Friendship.RejectRequest(
                new RejectRequestParams()
                {
                    RequestId = Convert.ToInt32(id)
                });
        });
        
        RejectAllButton.onClick.AddListener(async () =>
        {
            var request = await DynamicPixels.Table.GetServices().Friendship.RejectAllRequests(
                new RejectAllRequestsParams()
                {
                });
        });
        
        DeleteButton.onClick.AddListener(async () =>
        {
            var request = await DynamicPixels.Table.GetServices().Friendship.DeleteFriend(
                new DeleteFriendParams()
                {
                    UserId = Convert.ToInt32(id)
                });
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
