using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;///bunu eklememiz gerek

public class ZombiHareket : MonoBehaviour
{
    OyunKontrol FonksiyonUlaþ;
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
        oyuncu = GameObject.Find("Oyuncu");//FPSController objesini bulup oyuncuya atadý 
        FonksiyonUlaþ = GameObject.Find("_Script").GetComponent<OyunKontrol>();
    }


    void Update()
    {
        GetComponent<NavMeshAgent>().destination = oyuncu.transform.position;//oyuncunun pozisyonuna yönlendirmiþ olacagýz
        //destination = yan gideceði konum
        //problem animasyonlar tekrar ediyor
        Mesafe = Vector3.Distance(transform.position, oyuncu.transform.position);
        //distance ->3 boyutlu 2 mesafa arasýný ölçer 
        if (Mesafe < 4f && Hayatta)//Saldýrýyor
        {
            if (!aSource.isPlaying)//calmýyorsa gir diyor
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
            Debug.Log("CARPÝSMA GERÇEKLEÞTÝ");
            ZombiCan--;
            if (ZombiCan == 0)
            {
                FonksiyonUlaþ.PuanArtir(puanArtisi);

                Hayatta = false;
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject, 10f);
                Instantiate(Kalp, gameObject.transform.position, Quaternion.identity);///Quaternion.identity -> ile dongusel deerleri 0 alýyor
                                                                                      ///DENEYSEL ONCESÝ CALISIYOR
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                GetComponent<NavMeshAgent>().Stop();
                ///YAPMAK istediðim þey oldu ama altýnda yeþil yanýyor 

            }
        }
    }
}
