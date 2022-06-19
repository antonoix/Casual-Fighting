using System.Runtime.InteropServices;
using UnityEngine;

public class YandexSDK : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAd();

    public void ShowAdvertisment()
    {
        ShowAd();
    }
}
