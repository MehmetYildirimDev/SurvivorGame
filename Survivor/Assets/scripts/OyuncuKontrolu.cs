using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuKontrolu : MonoBehaviour
{
    public Transform mermiPos;//olu�turacag�m�z merminin posunu al�yoruz 
    public GameObject mermi;//prefabimiz olacak
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))//sol t�ka bas�ld�kca 
        {
            GameObject go = Instantiate(mermi, mermiPos.position, mermiPos.rotation) as GameObject;//mermimizi mermiposda ve rotationda olustur -> gameobcejte de d�nusturuyoruz
            go.GetComponent<Rigidbody>().velocity = mermiPos.transform.forward * 10f;// h�z yani y�n�  = merminin ileri y�nunde 
            Destroy(go, 2f);//sonsuza kadar gitmesin diye 
        }
    }
}
