using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDongusu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(new Vector3(250, 0, 250), Vector3.right, 5f * Time.deltaTime);
        //bir nokta etraf�nda d�nd�rmek i�in kullan�l�r bu fonksiyon
        //noktay� olusturduk ilk parametrede sonra y�nu sectik , zaman� se�tik 
        
    }
}
