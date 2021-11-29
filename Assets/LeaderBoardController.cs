using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;


public class LeaderBoardController : MonoBehaviour
{
    public InputField memberID, playerScore, playerName;
    public int id;
    int maxScores = 8;
    public Text[] entries;

    private void Start()
    {
        LootLockerSDKManager.StartSession("Player", (response) => { 
            if (response.success)
            {
                Debug.Log("Success1");
            }else
            {
                Debug.Log("Failed1");
            }
        });
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SetPlayerName(playerName.text, (response) => {
            if (response.success)
            {
                Debug.Log(response.name);
            }
            else
            {
                Debug.Log("Fail2");
            }
        });

        LootLockerSDKManager.SubmitScore(memberID.text, int.Parse(playerScore.text), id, (response) => {
            if (response.success)
            {
                Debug.Log("Success2");
            }
            else
            {
                Debug.Log("Fail2");
            }
        });
    }

    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(id, maxScores, (response) => {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;
               
                for (int i = 0; i < scores.Length;i++)
                {
                    if (scores[i].player != null)
                    {
                        entries[i].text = (scores[i].rank + ".  " + scores[i].player.name + " " + scores[i].score);
                    }
                    else {
                        entries[i].text = (scores[i].rank + ".  " + scores[i].score);
                    }
                }
                if (scores.Length < maxScores)
                {
                    for (int i = scores.Length; i < maxScores; i++)
                    {
                        entries[i].text = (i + 1).ToString() + ". none";
                    }
                }
            }
            else
            {
                Debug.Log("Fail2");
            }
        });
    }
}
