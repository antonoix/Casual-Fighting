using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YandexAds : MonoBehaviour
{
    [SerializeField] private YandexSDK _yandexSDK;

    public void ShowInterstitial()
    {
        _yandexSDK.ShowAdvertisment();
    }
}
