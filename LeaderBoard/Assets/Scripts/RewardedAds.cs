using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardedAds : MonoBehaviour, IUnityAdsListener
{

   private string gameid = "4386561";
   // private string gameid = "4382484";
   // private string interstitialID = "Interstitial_Android";
    private string rewardedVideoID = "Rewarded_Android";
    public bool TestMode;
    public Button showInterstitial;
    public Button watchRewardAd;
    public Text gemsAmt;

    void Start()
    {
        Advertisement.Initialize(gameid, TestMode);
        //showInterstitial.interactable = Advertisement.IsReady(interstitialID);
       // watchRewardAd.interactable = Advertisement.IsReady(rewardedVideoID);
        //Advertisement.AddListener(this);
       // ShowRewardedVideo();
        //OnUnityAdsReady(gameid);
    }

    

    public void ShowRewardedVideo()
    {
        Advertisement.Show(rewardedVideoID);
    }

    public void OnUnityAdsReady(string placementID)
    {
        if (placementID == rewardedVideoID)
        {
            watchRewardAd.interactable = true;
        }

       


    }

    public void OnUnityAdsDidFinish(string placementID, ShowResult showResult)
    {
        if (placementID == rewardedVideoID)
        {
            if (showResult == ShowResult.Finished)
            {
                GetReward();
            }
            else if (showResult == ShowResult.Skipped)
            {
                //Do nothing
            }
            else if (showResult == ShowResult.Failed)
            {
                //tell player ads failed
            }
        }
    }


    public void OnUnityAdsDidError(string message)
    {
        //Show or log the error here
    }

    public void OnUnityAdsDidStart(string placementID)
    {
        //Do this if ads starts
    }

    public void GetReward()
    {
        if (PlayerPrefs.HasKey("gems"))
        {
            int gemAmount = PlayerPrefs.GetInt("gems");
            PlayerPrefs.SetInt("gems", gemAmount + 50);
        }
        else
        {
            PlayerPrefs.SetInt("gems", 50);
        }

        gemsAmt.text = "Gems: " + PlayerPrefs.GetInt("gems").ToString();
    }
}
