using System.Xml;
using System.Collections.Generic;
using UnityEngine;

public class Localization : MonoBehaviour
{
    private static Dictionary<string, Dictionary<string, string>> _localization;
    private static string _language;

    [SerializeField] private TextAsset textFile;

    private void Awake()
    {
        if (_localization == null)
            Setup();
        if (_language == null)
            SetLanguage();
    }

    private void Setup()
    {
        _localization = new Dictionary<string, Dictionary<string, string>>();

        var XMLdoc = new XmlDocument();
        XMLdoc.LoadXml(textFile.text);

        foreach (XmlNode lang in XMLdoc["languages"].ChildNodes)
        {
            var langDic = new Dictionary<string, string>();
            foreach (XmlNode word in lang)
            {
                langDic[word.Name] = word.InnerText;
            }
            _localization[lang.Name] = langDic;
        }
    }

    private void SetLanguage()
    {
        switch(Application.systemLanguage)
        {
            case SystemLanguage.Russian:
                _language = "ru";
                break;
            case SystemLanguage.English:
                _language = "en";
                break;
            default:
                _language = "en";
                break;
        }
    }

    public static string GetTranslated(string word, string lang)
    {
        return _localization[lang][word];
    }

    public static string GetTranslated(string word)
    {
        return _localization[_language][word];
    }
}
