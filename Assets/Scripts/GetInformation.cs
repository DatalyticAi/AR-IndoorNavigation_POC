using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class GetInformation : MonoBehaviour
{
    private string secretKey = "mySecretKey";
    public string serialnumberURL = "http://192.168.0.111/IndoorNavi/Unity/index.php";

    public TMP_InputField serial_numberInput;
    public TextMeshProUGUI rowDisplayText;
    public TextMeshProUGUI columnDisplayText;


    public void SubmitBtn()
    {
        rowDisplayText.text = "Row, Column :  "
        + columnDisplayText.text;

        StartCoroutine(GetRequest(Convert.ToInt32(serial_numberInput.text)));
        
        serial_numberInput.gameObject.transform.parent.GetComponent<InputField>().text = " ";
        
    }

    IEnumerator GetRequest(int serial_number)
    {
        UnityWebRequest sn_get = UnityWebRequest.Get(serialnumberURL);
        yield return sn_get.SendWebRequest();
        if (sn_get.error != null)
            Debug.Log("There was an error getting the serial number: "
                    + sn_get.error);

        else
        {
            string dataText = sn_get.downloadHandler.text;
            MatchCollection mc = Regex.Matches(dataText, @"_");
            if (mc.Count > 0)
            {
                string[] splitData = Regex.Split(dataText, @"_");
                for (int i = 0; i < mc.Count; i++)
                {
                    if (i >= 0)

                        rowDisplayText.text +=
                                            splitData[i];
                    else
                        columnDisplayText.text +=
                                            splitData[i];

                }
            }
        }

    }
}