using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;///bunu eklememiz gerek

public class ZombiHareket : MonoBehaviour
{
    GameObject oyuncu;
    // Start is called before the first frame update
    void Start()
    {
        oyuncu = GameObject.Find("FPSController");//FPSController objesini bulup oyuncuya atadý 
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = oyuncu.transform.position;//oyuncunun pozisyonuna yönlendirmiþ olacagýz
//destination = yan gideceði konum 
    }
}
