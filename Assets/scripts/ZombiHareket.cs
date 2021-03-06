using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;///bunu eklememiz gerek

public class ZombiHareket : MonoBehaviour
{
    OyunKontrol FonksiyonUlaş;
    public GameObject Kalp;
    bool Hayatta = true;
    GameObject oyuncu;
    int ZombiCan = 3;
    float Mesafe;
    int puanArtisi = 1;
    private AudioSource aSource;


    void Start()
    {
        aSource = GetComponent<AudioSource>();
        oyuncu = GameObject.Find("Oyuncu");//FPSController objesini bulup oyuncuya atadı 
        FonksiyonUlaş = GameObject.Find("_Script").GetComponent<OyunKontrol>();
    }


    void Update()
    {
        GetComponent<NavMeshAgent>().destination = oyuncu.transform.position;//oyuncunun pozisyonuna yönlendirmiş olacagız
        //destination = yan gideceği konum
        //problem animasyonlar tekrar ediyor
        Mesafe = Vector3.Distance(transform.position, oyuncu.transform.position);
        //distance ->3 boyutlu 2 mesafa arasını ölçer 
        if (Mesafe < 4f && Hayatta)//Saldırıyor
        {
            if (!aSource.isPlaying)//calmıyorsa gir diyor
            {
                aSource.Play();
            }
            
            GetComponentInChildren<Animation>().Play("Zombie_Attack_01");

        }
        else if (Mesafe > 4f && Hayatta)//Yuruyor
        {
            aSource.Stop();
            GetComponentInChildren<Animation>().Play("Zombie_Walk_01");
            
        }
        else//Oldu
        {
            aSource.Stop();
            GetComponentInChildren<Animation>().Stop("Zombie_Attack_01");
            GetComponentInChildren<Animation>().Stop("Zombie_Walk_01");
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals("mermi"))
        {
            Debug.Log("CARPİSMA GERÇEKLEŞTİ");
            ZombiCan--;
            if (ZombiCan == 0)
            {
                FonksiyonUlaş.PuanArtir(puanArtisi);

                Hayatta = false;
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject, 10f);
                Instantiate(Kalp, gameObject.transform.position, Quaternion.identity);///Quaternion.identity -> ile dongusel deerleri 0 alıyor
                                                                                      ///DENEYSEL ONCESİ CALISIYOR
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                GetComponent<NavMeshAgent>().Stop();
                ///YAPMAK istediğim şey oldu ama altında yeşil yanıyor 

            }
        }
    }
}
