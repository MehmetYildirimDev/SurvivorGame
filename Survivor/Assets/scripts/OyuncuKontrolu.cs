using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OyuncuKontrolu : MonoBehaviour
{
    

    public Transform mermiPos;//olu�turacag�m�z merminin posunu al�yoruz 
    public GameObject mermi;//prefabimiz olacak
    public GameObject Patlama;
    public Image CanImaji;
    float CanDegeri = 100f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))//sol t�ka bas�ld�kca 
        {
            GameObject go = Instantiate(mermi, mermiPos.position, mermiPos.rotation) as GameObject;//mermimizi mermiposda ve rotationda olustur -> gameobcejte de d�nusturuyoruz
            GameObject goPatlama = Instantiate(Patlama, mermiPos.position, mermiPos.rotation) as GameObject;///Patlama Objemizi olu�turuyozu
            go.GetComponent<Rigidbody>().velocity = mermiPos.transform.forward * 10f;// h�z yani y�n�  = merminin ileri y�nunde 

            Destroy(go.gameObject, 2f);//sonsuza kadar gitmesin diye 
            Destroy(goPatlama.gameObject, 1f);
        }
    }
    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals("zombi"))
        {
            Debug.Log("Sald�r�");
            CanDegeri-=10f;
            CanImaji.fillAmount = CanDegeri/100f;
            CanImaji.color = Color.Lerp(Color.red ,Color.green, CanDegeri / 100f);
        }
    }

    private void OnTriggerEnter(Collider c)//icinden gecilen objeleri kontrol ediyor
    {
        if (c.gameObject.tag.Equals("Heart"))
        {
            if (CanDegeri<100)
            {
                CanDegeri += 10f;
            }
            
            Destroy(c.gameObject);
            CanImaji.fillAmount = CanDegeri / 100f;
            CanImaji.color = Color.Lerp(Color.red, Color.green, CanDegeri / 100f);
            
        }
    }
 

}
