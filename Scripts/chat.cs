using System.Collections;
using System.Collections.Generic;
using models.dto;
using models.inputs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class chat : MonoBehaviour
{
    [SerializeField]
    public Button sendButton;
    [SerializeField]
    public TMP_InputField messageInput;
    
    // Start is called before the first frame update
    async void Start()
    {
        await DynamicPixels.Table.GetServices().Chats.Subscribe(new SubscribeParams
        {
            ConversationId = 0,
            ConversationName = "my-room"
        });
        
        sendButton.onClick.AddListener(async () =>
        {
            // await DynamicPixels.Table.GetServices().Chats.Send(new SendParams
            // {
            //     Type = ConversationType.Group,
            //     Message = "hello",
            //     TargetUserId = 
            // });
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
