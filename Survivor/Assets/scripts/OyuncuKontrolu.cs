using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OyuncuKontrolu : MonoBehaviour
{
    private AudioSource aSource;
    public AudioClip AtisSesi, CanAlmaSesi, OlmeSesi, YaralanmaSesi;

    public OyunKontrol oyunKontrol;
    public Transform mermiPos;//oluþturacagýmýz merminin posunu alýyoruz 
    public GameObject mermi;//prefabimiz olacak
    public GameObject Patlama;
    public Image CanImaji;
    float CanDegeri = 30f;
    private void Start()
    {
        aSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))//sol týka basýldýkca 
        {
            aSource.PlayOneShot(AtisSesi,1f);
            GameObject go = Instantiate(mermi, mermiPos.position, mermiPos.rotation) as GameObject;//mermimizi mermiposda ve rotationda olustur -> gameobcejte de dönusturuyoruz
            GameObject goPatlama = Instantiate(Patlama, mermiPos.position, mermiPos.rotation) as GameObject;///Patlama Objemizi oluþturuyozu
            go.GetComponent<Rigidbody>().velocity = mermiPos.transform.forward * 10f;// hýz yani yönü  = merminin ileri yönunde 

            Destroy(go.gameObject, 2f);//sonsuza kadar gitmesin diye 
            Destroy(goPatlama.gameObject, 1f);
        }
    }
    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals("zombi"))
        {
            Debug.Log("Saldýrý");
            aSource.PlayOneShot(YaralanmaSesi,1f);
            CanDegeri-=10f;
            CanImaji.fillAmount = CanDegeri/100f;
            CanImaji.color = Color.Lerp(Color.red ,Color.green, CanDegeri / 100f);
            if (CanDegeri<=0)
            {
                aSource.PlayOneShot(OlmeSesi,1f);
                oyunKontrol.OyunBitti();
            }
        }
    }

    private void OnTriggerEnter(Collider c)//icinden gecilen objeleri kontrol ediyor
    {
        if (c.gameObject.tag.Equals("Heart"))
        {
            if (CanDegeri<100)
            {
                aSource.PlayOneShot(CanAlmaSesi,1f);
                CanDegeri += 10f;
            }
            
            Destroy(c.gameObject);
            CanImaji.fillAmount = CanDegeri / 100f;
            CanImaji.color = Color.Lerp(Color.red, Color.green, CanDegeri / 100f);
            
        }
    }
 

}
