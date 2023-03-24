using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;



public class NameDisplay : MonoBehaviour
{

    public TMP_InputField inputUser;

    public TextMeshProUGUI displayUser;

    public int row;
    public int column;
    public int coordinate;
    public string serial_number;

    void Start()
    {
        StartCoroutine(GetRequest("http://192.168.0.111/IndoorNavi/Unity/index.php"));
    }
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
        }

    }

  
        public void StoreNum(string uri )
        {
        

            StartCoroutine(GetRequest("http://192.168.0.111/IndoorNavi/Unity/index.php"));


            inputUser.text = serial_number;
            displayUser.text = "row";
            displayUser.text = "Serial number: " + inputUser.text + "  Row :  " + row + " Column: " + column;

       
        }
    

}



