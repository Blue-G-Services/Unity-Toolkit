using System;
using System.Collections;
using System.Collections.Generic;
using models.dto;
using models.inputs;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class party : MonoBehaviour
{
    [SerializeField] public Button BackButton;
    [SerializeField] public Button GetPartiesButton;
    [SerializeField] public Button CreatePartyButton;
    
    // Start is called before the first frame update
    void Start()
    {

        BackButton.onClick.AddListener(() => { SceneManager.LoadScene("mainMenu"); });

        GetPartiesButton.onClick.AddListener(async () =>
        {
            var parties = await DynamicPixels.Table.GetServices().Party.GetParties(new GetPartiesParams
            {
                Skip = 0,
                Limit = 50
            });

            foreach (var party in parties)
            {
                Debug.Log(party.ToString());
            }
        });

        CreatePartyButton.onClick.AddListener(async () =>
        {
            var party = await DynamicPixels.Table.GetServices().Party.CreateParty(new CreatePartyParams
            {
                Data = new PartyInput
                {
                    Name = "my party",
                    Desc = "simple desc",
                    MaxMemberCount = 10
                }
            });

            Debug.Log(party.ToString());
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
