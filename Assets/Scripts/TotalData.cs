using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class TotalData : MonoBehaviour
{
    public Text NewConfirmedIn;
    public Text ConfirmedIn;
    public Text NewDeathsIn;
    public Text DeathsIn;
    public Text NewRecoveredIn;
    public Text RecoveredIn;
    
    public string url = "https://api.covid19api.com/summary";

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(GetRequest(url));
    }
    
    IEnumerator GetRequest(string url)
    {
        UnityWebRequest req = UnityWebRequest.Get(url);
        
        yield return req.SendWebRequest();
        
        if(req.isNetworkError || req.isHttpError)
        {
            Debug.LogError(req.error);
            NewConfirmedIn.text = "Error Getting Data";
            ConfirmedIn.text = "Error Getting Data";
            NewDeathsIn.text = "Error Getting Data";
            DeathsIn.text = "Error Getting Data";
            NewRecoveredIn.text = "Error Getting Data";
            RecoveredIn.text = "Error Getting Data";
            yield break;
        }
        
        JSONNode ReqData = JSON.Parse(req.downloadHandler.text);
        NewConfirmedIn.text = ReqData[0]["NewConfirmed"];
        ConfirmedIn.text =  ReqData[0]["TotalConfirmed"];
        NewDeathsIn.text = ReqData[0]["NewDeaths"];
        DeathsIn.text =  ReqData[0]["TotalDeaths"];
        NewRecoveredIn.text = ReqData[0]["NewRecovered"];
        RecoveredIn.text =  ReqData[0]["TotalRecovered"];
    }
}
