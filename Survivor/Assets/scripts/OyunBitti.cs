using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunBitti : MonoBehaviour
{
    public Text puan;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;///Fare kilitlenmisse kilidi kald�r�yor
        Cursor.visible = true;//mouse g�z�kmesi i�in   
        puan.text = "Puaniniz : " + PlayerPrefs.GetInt("puan");//Puan� geri cag�rma 
    }

    // Update is called once per frame
   public void YenidenBaslat()
    {
        SceneManager.LoadScene("Oyun");
    }
}
