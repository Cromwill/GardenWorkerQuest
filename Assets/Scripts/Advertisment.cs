using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class Advertisment : MonoBehaviour, IInterstitialAdListener
{
    private LevelProgression _levelProgression;
    private const string _appKey = "8ef24947ac3c06b516bac0213565d5bf8ca71aa049e4e1a9";

    private void Awake()
    {
        Appodeal.initialize(_appKey, Appodeal.INTERSTITIAL, true);
    }
    private void OnEnable()
    {
        _levelProgression = FindObjectOfType<LevelProgression>();
        _levelProgression.LevelStarted += ShowInterstitial;
    }

    private void OnDisable()
    {
        _levelProgression.LevelStarted -= ShowInterstitial;
    }

    public void onInterstitialClicked()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialClosed()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialExpired()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialFailedToLoad()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialLoaded(bool isPrecache)
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialShowFailed()
    {
        throw new System.NotImplementedException();
    }

    public void onInterstitialShown()
    {
        throw new System.NotImplementedException();
    }

    private void ShowInterstitial()
    {
        if (Appodeal.canShow(Appodeal.INTERSTITIAL))
            Appodeal.show(Appodeal.INTERSTITIAL);
    }
}
