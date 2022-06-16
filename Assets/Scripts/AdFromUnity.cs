using UnityEngine;
using UnityEngine.Advertisements;

public class AdFromUnity
{
    string gameId = "4793395";
    bool testMode = false;

    public void ShowInterstitial()
    {
        Advertisement.Initialize(gameId, testMode);
        Advertisement.Show();
    }
}
