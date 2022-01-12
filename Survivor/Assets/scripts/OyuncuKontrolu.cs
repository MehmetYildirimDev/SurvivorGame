using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuKontrolu : MonoBehaviour
{
    public Transform mermiPos;//oluþturacagýmýz merminin posunu alýyoruz 
    public GameObject mermi;//prefabimiz olacak
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))//sol týka basýldýkca 
        {
            GameObject go = Instantiate(mermi, mermiPos.position, mermiPos.rotation) as GameObject;//mermimizi mermiposda ve rotationda olustur -> gameobcejte de dönusturuyoruz
            go.GetComponent<Rigidbody>().velocity = mermiPos.transform.forward * 10f;// hýz yani yönü  = merminin ileri yönunde 
            Destroy(go, 2f);//sonsuza kadar gitmesin diye 
        }
    }
}
