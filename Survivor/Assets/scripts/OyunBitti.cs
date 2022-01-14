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
        Cursor.lockState = CursorLockMode.None;///Fare kilitlenmisse kilidi kaldýrýyor
        Cursor.visible = true;//mouse gözükmesi için   
        puan.text = "Puaniniz : " + PlayerPrefs.GetInt("puan");//Puaný geri cagýrma 
    }

    // Update is called once per frame
   public void YenidenBaslat()
    {
        SceneManager.LoadScene("Oyun");
    }
}
