using System;
using System.Collections;
using System.Collections.Generic;
using models.inputs;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class leaderboard : MonoBehaviour
{
    [SerializeField] public Button BackButton;
    [SerializeField] public Button SubmitButton;
    [SerializeField] public Button GetScoresButton;
    [SerializeField] public TMP_InputField LeaderboardInput;
    [SerializeField] public TMP_InputField ScoreInput;

    async void Start()
    {
        GetScoresButton.onClick.AddListener(async () =>
        {
            var leaderboardId = LeaderboardInput.text;
            var scores = await DynamicPixels.Table.GetServices().Leaderboard.GetScores(new GetScoresParams
            {
                LeaderboardId = leaderboardId
            });
            
            foreach(var s in scores)
            {
                Debug.Log(s.ToString());
            } 
        });
        
        SubmitButton.onClick.AddListener(async () =>
        {
            var leaderboardId = LeaderboardInput.text;
            var value = ScoreInput.text;
            
            await DynamicPixels.Table.GetServices().Leaderboard.SubmitScore(new SubmitScoreParams
            {
                LeaderboardId = leaderboardId,
                Score = Convert.ToInt32(value)
            });
        });
        
        BackButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("mainMenu");
        });
        
        var leaderboards = await DynamicPixels.Table.GetServices().Leaderboard.GetLeaderboards(new GetLeaderboardsParams
        {
            
        });

        foreach(var l in leaderboards)
        {
            Debug.Log(l.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
