using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class CountryData : MonoBehaviour
{
    public Text CountryIn;
    public Text ConfirmedIn;
    public Text RecoveredIn;
    public Text ActiveIn;
    public Text DateIn;
    
    public Text CountryInput;
    
    public void GetData ()
    {
        CountryIn.text =  "Getting Data";
        ConfirmedIn.text =  "Getting Data";
        RecoveredIn.text =  "Getting Data";
        ActiveIn.text =  "Getting Data";
        DateIn.text =  "Getting Data";
        
        string url = "https://api.covid19api.com/total/country/" + CountryInput.text;
        
        StartCoroutine(GetRequest(url));
    }
    
    IEnumerator GetRequest(string url)
    {
        UnityWebRequest req = UnityWebRequest.Get(url);
        
        yield return req.SendWebRequest();
        
        if(req.isNetworkError || req.isHttpError)
        {
            Debug.LogError(req.error);
            CountryIn.text =  "Error Getting Data";
            ConfirmedIn.text =  "Error Getting Data";
            RecoveredIn.text =  "Error Getting Data";
            ActiveIn.text =  "Error Getting Data";
            DateIn.text =  "Error Getting Data";
            yield break;
        }
        
        JSONNode ReqData = JSON.Parse(req.downloadHandler.text);
        CountryIn.text = ReqData[ReqData.Count-1]["Country"];
        ConfirmedIn.text =  ReqData[ReqData.Count-1]["Confirmed"];
        RecoveredIn.text =  ReqData[ReqData.Count-1]["Recovered"];
        ActiveIn.text =  ReqData[ReqData.Count-1]["Active"];
        DateIn.text =  ReqData[ReqData.Count-1]["Date"];
    }
}
