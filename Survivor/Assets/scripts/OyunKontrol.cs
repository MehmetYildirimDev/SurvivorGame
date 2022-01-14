using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    public GameObject zombi;
    float zamanSayaci;
    float olusumSureci = 3f;
    public Text PuanText;
    int puan;
    void Start()
    {
        zamanSayaci = olusumSureci;
    }

    // Update is called once per frame
    void Update()
    {
        zamanSayaci -= Time.deltaTime;
        if (zamanSayaci < 0)
        {
            Vector3 pos = new Vector3(333.115845f, 24.4799995f, 294.791473f);
            Instantiate(zombi, pos, Quaternion.identity);
            zamanSayaci = olusumSureci;
        }
    }

    public void PuanArtir(int p)
    {
        puan += p;
        PuanText.text = puan.ToString();
    }
    public void OyunBitti()
    {
        PlayerPrefs.SetInt("puan", puan);//anahtar kelime ilki ikincisi deðer 
                                         //Oyun Kapansa dahi bu bilgilere eriþebiliyoruz
        SceneManager.LoadScene("OyunBitti");
    }

}
