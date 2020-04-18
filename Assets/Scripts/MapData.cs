using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class MapData : MonoBehaviour
{
    public Image China;
    public Image France;
    public Image Germany;
    public Image Iran;
    public Image Italy;
    public Image Spain;
    public Image Switzerland;
    public Image Turkey;
    public Image UnitedKingdom;
    public Image UnitedStates;
    
    public string url = "https://api.covid19api.com/summary";
    
    public void TotalCases()
    {
        StartCoroutine(GetRequest(url,1));
    }
    public void NewCases()
    {
        StartCoroutine(GetRequest(url,6));
    }
    public void TotalDeaths()
    {
        StartCoroutine(GetRequest(url,2));
    }
    public void NewDeaths()
    {
        StartCoroutine(GetRequest(url,3));
    }
    public void TotalRecovered()
    {
        StartCoroutine(GetRequest(url,4));
    }
    public void NewRecovered()
    {
        StartCoroutine(GetRequest(url,5));
    }
    
    IEnumerator GetRequest(string url, int type)
    {
        UnityWebRequest req = UnityWebRequest.Get(url);
        
        yield return req.SendWebRequest();
        
        if(req.isNetworkError || req.isHttpError)
        {
            Debug.LogError(req.error);
            yield break;
        }
        
        JSONNode ReqData = JSON.Parse(req.downloadHandler.text);
        float[] vals = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] ind = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        string[] countries = {"CN","FR","DE","IR","IT","ES","CH","TR","GB","US"};
        
        for (int j = 0; j < 247; j++)
        {
            for (int i = 0; i < 10; i++)
            {
                if (ReqData["Countries"][j]["CountryCode"] == countries[i])
                {
                    ind[i] = j;
                }
            }
        }
        switch (type)
        {
            case 1:
                vals[0] = Int32.Parse(ReqData["Countries"][ind[0]]["TotalConfirmed"]);
                vals[1] = Int32.Parse(ReqData["Countries"][ind[1]]["TotalConfirmed"]);
                vals[2] = Int32.Parse(ReqData["Countries"][ind[2]]["TotalConfirmed"]);
                vals[3] = Int32.Parse(ReqData["Countries"][ind[3]]["TotalConfirmed"]);
                vals[4] = Int32.Parse(ReqData["Countries"][ind[4]]["TotalConfirmed"]);
                vals[5] = Int32.Parse(ReqData["Countries"][ind[5]]["TotalConfirmed"]);
                vals[6] = Int32.Parse(ReqData["Countries"][ind[6]]["TotalConfirmed"]);
                vals[7] = Int32.Parse(ReqData["Countries"][ind[7]]["TotalConfirmed"]);
                vals[8] = Int32.Parse(ReqData["Countries"][ind[8]]["TotalConfirmed"]);
                vals[9] = Int32.Parse(ReqData["Countries"][ind[9]]["TotalConfirmed"]);
                break;
            case 2:
                vals[0] = Int32.Parse(ReqData["Countries"][ind[0]]["TotalDeaths"]);
                vals[1] = Int32.Parse(ReqData["Countries"][ind[1]]["TotalDeaths"]);
                vals[2] = Int32.Parse(ReqData["Countries"][ind[2]]["TotalDeaths"]);
                vals[3] = Int32.Parse(ReqData["Countries"][ind[3]]["TotalDeaths"]);
                vals[4] = Int32.Parse(ReqData["Countries"][ind[4]]["TotalDeaths"]);
                vals[5] = Int32.Parse(ReqData["Countries"][ind[5]]["TotalDeaths"]);
                vals[6] = Int32.Parse(ReqData["Countries"][ind[6]]["TotalDeaths"]);
                vals[7] = Int32.Parse(ReqData["Countries"][ind[7]]["TotalDeaths"]);
                vals[8] = Int32.Parse(ReqData["Countries"][ind[8]]["TotalDeaths"]);
                vals[9] = Int32.Parse(ReqData["Countries"][ind[9]]["TotalDeaths"]);
                break;
            case 3:
                vals[0] = Int32.Parse(ReqData["Countries"][ind[0]]["NewDeaths"]);
                vals[1] = Int32.Parse(ReqData["Countries"][ind[1]]["NewDeaths"]);
                vals[2] = Int32.Parse(ReqData["Countries"][ind[2]]["NewDeaths"]);
                vals[3] = Int32.Parse(ReqData["Countries"][ind[3]]["NewDeaths"]);
                vals[4] = Int32.Parse(ReqData["Countries"][ind[4]]["NewDeaths"]);
                vals[5] = Int32.Parse(ReqData["Countries"][ind[5]]["NewDeaths"]);
                vals[6] = Int32.Parse(ReqData["Countries"][ind[6]]["NewDeaths"]);
                vals[7] = Int32.Parse(ReqData["Countries"][ind[7]]["NewDeaths"]);
                vals[8] = Int32.Parse(ReqData["Countries"][ind[8]]["NewDeaths"]);
                vals[9] = Int32.Parse(ReqData["Countries"][ind[9]]["NewDeaths"]);
                break;
            case 4:
                vals[0] = Int32.Parse(ReqData["Countries"][ind[0]]["TotalRecovered"]);
                vals[1] = Int32.Parse(ReqData["Countries"][ind[1]]["TotalRecovered"]);
                vals[2] = Int32.Parse(ReqData["Countries"][ind[2]]["TotalRecovered"]);
                vals[3] = Int32.Parse(ReqData["Countries"][ind[3]]["TotalRecovered"]);
                vals[4] = Int32.Parse(ReqData["Countries"][ind[4]]["TotalRecovered"]);
                vals[5] = Int32.Parse(ReqData["Countries"][ind[5]]["TotalRecovered"]);
                vals[6] = Int32.Parse(ReqData["Countries"][ind[6]]["TotalRecovered"]);
                vals[7] = Int32.Parse(ReqData["Countries"][ind[7]]["TotalRecovered"]);
                vals[8] = Int32.Parse(ReqData["Countries"][ind[8]]["TotalRecovered"]);
                vals[9] = Int32.Parse(ReqData["Countries"][ind[9]]["TotalRecovered"]);
                break;
            case 5:
                vals[0] = Int32.Parse(ReqData["Countries"][ind[0]]["NewRecovered"]);
                vals[1] = Int32.Parse(ReqData["Countries"][ind[1]]["NewRecovered"]);
                vals[2] = Int32.Parse(ReqData["Countries"][ind[2]]["NewRecovered"]);
                vals[3] = Int32.Parse(ReqData["Countries"][ind[3]]["NewRecovered"]);
                vals[4] = Int32.Parse(ReqData["Countries"][ind[4]]["NewRecovered"]);
                vals[5] = Int32.Parse(ReqData["Countries"][ind[5]]["NewRecovered"]);
                vals[6] = Int32.Parse(ReqData["Countries"][ind[6]]["NewRecovered"]);
                vals[7] = Int32.Parse(ReqData["Countries"][ind[7]]["NewRecovered"]);
                vals[8] = Int32.Parse(ReqData["Countries"][ind[8]]["NewRecovered"]);
                vals[9] = Int32.Parse(ReqData["Countries"][ind[9]]["NewRecovered"]);
                break;
            default:
                vals[0] = Int32.Parse(ReqData["Countries"][ind[0]]["NewConfirmed"]);
                vals[1] = Int32.Parse(ReqData["Countries"][ind[1]]["NewConfirmed"]);
                vals[2] = Int32.Parse(ReqData["Countries"][ind[2]]["NewConfirmed"]);
                vals[3] = Int32.Parse(ReqData["Countries"][ind[3]]["NewConfirmed"]);
                vals[4] = Int32.Parse(ReqData["Countries"][ind[4]]["NewConfirmed"]);
                vals[5] = Int32.Parse(ReqData["Countries"][ind[5]]["NewConfirmed"]);
                vals[6] = Int32.Parse(ReqData["Countries"][ind[6]]["NewConfirmed"]);
                vals[7] = Int32.Parse(ReqData["Countries"][ind[7]]["NewConfirmed"]);
                vals[8] = Int32.Parse(ReqData["Countries"][ind[8]]["NewConfirmed"]);
                vals[9] = Int32.Parse(ReqData["Countries"][ind[9]]["NewConfirmed"]);
                break;
        }
        Debug.LogError(String.Join(",", vals.Select(p=>p.ToString()).ToArray()));
        float max = vals.Max();
        for (int i = 0; i < vals.Length; i++)
        {
            vals[i] = vals[i]/max;
            if (vals[i]>0.9)
            {
                vals[i] = 1f;
            }
            else if (vals[i]>0.5)
            {
                vals[i] = 0.75f;
            }
            else if (vals[i]>0.1)
            {
                vals[i] = 0.5f;
            }
            else
            {
                vals[i] = 0.25f;
            }
        }
        Debug.LogError(String.Join(",", vals.Select(p=>p.ToString()).ToArray()));
        Color tempColor = China.color;
        tempColor.a = vals[0];
        China.color = tempColor;
        tempColor = France.color;
        tempColor.a = vals[1];
        France.color = tempColor;
        tempColor = Germany.color;
        tempColor.a = vals[2];
        Germany.color = tempColor;
        tempColor = Iran.color;
        tempColor.a = vals[3];
        Iran.color = tempColor;
        tempColor = Italy.color;
        tempColor.a = vals[4];
        Italy.color = tempColor;
        tempColor = Spain.color;
        tempColor.a = vals[5];
        Spain.color = tempColor;
        tempColor = Switzerland.color;
        tempColor.a = vals[6];
        Switzerland.color = tempColor;
        tempColor = Turkey.color;
        tempColor.a = vals[7];
        Turkey.color = tempColor;
        tempColor = UnitedKingdom.color;
        tempColor.a = vals[8];
        UnitedKingdom.color = tempColor;
        tempColor = UnitedStates.color;
        tempColor.a = vals[9];
        UnitedStates.color = tempColor;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        float alpha = 0.0f;
        Color tempColor = China.color;
        tempColor.a = alpha;
        China.color = tempColor;
        
        tempColor = France.color;
        tempColor.a = alpha;
        France.color = tempColor;
        
        tempColor = Germany.color;
        tempColor.a = alpha;
        Germany.color = tempColor;
        
        tempColor = Iran.color;
        tempColor.a = alpha;
        Iran.color = tempColor;
        
        tempColor = Italy.color;
        tempColor.a = alpha;
        Italy.color = tempColor;
        
        tempColor = Spain.color;
        tempColor.a = alpha;
        Spain.color = tempColor;
        
        tempColor = Switzerland.color;
        tempColor.a = alpha;
        Switzerland.color = tempColor;
        
        tempColor = Turkey.color;
        tempColor.a = alpha;
        Turkey.color = tempColor;
        
        tempColor = UnitedKingdom.color;
        tempColor.a = alpha;
        UnitedKingdom.color = tempColor;
        
        tempColor = UnitedStates.color;
        tempColor.a = alpha;
        UnitedStates.color = tempColor;
    }
}
