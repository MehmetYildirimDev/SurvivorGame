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
        oyuncu = GameObject.Find("FPSController");//FPSController objesini bulup oyuncuya atad� 
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = oyuncu.transform.position;//oyuncunun pozisyonuna y�nlendirmi� olacag�z
//destination = yan gidece�i konum 
    }
}
