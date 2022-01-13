using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;///bunu eklememiz gerek

public class ZombiHareket : MonoBehaviour
{
    OyunKontrol FonksiyonUla�;
    public GameObject Kalp;
    bool Hayatta = true;
    GameObject oyuncu;
    int ZombiCan = 3;
    float Mesafe;
    int puanArtisi = 1;
    // Start is called before the first frame update
    void Start()
    {
        oyuncu = GameObject.Find("Oyuncu");//FPSController objesini bulup oyuncuya atad� 
        FonksiyonUla� = GameObject.Find("_Script").GetComponent<OyunKontrol>();
    }


    void Update()
    {
        GetComponent<NavMeshAgent>().destination = oyuncu.transform.position;//oyuncunun pozisyonuna y�nlendirmi� olacag�z
        //destination = yan gidece�i konum
        //problem animasyonlar tekrar ediyor
        Mesafe = Vector3.Distance(transform.position, oyuncu.transform.position);
        //distance ->3 boyutlu 2 mesafa aras�n� �l�er 
        if (Mesafe < 4f && Hayatta)
        {
            GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
        }
        else if (Mesafe > 4f && Hayatta)
        {
            GetComponentInChildren<Animation>().Play("Zombie_Walk_01");
        }
        else
        {
            GetComponentInChildren<Animation>().Stop("Zombie_Attack_01");
            GetComponentInChildren<Animation>().Stop("Zombie_Walk_01");
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals("mermi"))
        {
            Debug.Log("CARP�SMA GER�EKLE�T�");
            ZombiCan--;
            if (ZombiCan == 0)
            {
                FonksiyonUla�.PuanArtir(puanArtisi);

                Hayatta = false;
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject, 10f);
                Instantiate(Kalp, gameObject.transform.position, Quaternion.identity);///Quaternion.identity -> ile dongusel deerleri 0 al�yor
                                                                                      ///DENEYSEL ONCES� CALISIYOR
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                GetComponent<NavMeshAgent>().Stop();
                ///YAPMAK istedi�im �ey oldu ama alt�nda ye�il yan�yor 

            }
        }
    }
}
