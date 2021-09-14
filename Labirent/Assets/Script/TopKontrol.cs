using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class TopKontrol : MonoBehaviour
{
    public UnityEngine.UI.Button btn;
    public UnityEngine.UI.Text zaman, can,durum;
    private Rigidbody rg;
    public float hiz = 3.5f;
    float zamansayaci = 22;
    int cansayaci = 3;
    bool oyunDevam = true;
    bool oyuntamam = false;
   
    void Start()
    {
        can.text = cansayaci+"";
        rg = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunDevam && !oyuntamam) { 
        zamansayaci -= Time.deltaTime;
        zaman.text = (int)zamansayaci + "";
        }
        else if(!oyuntamam)
        {
            durum.text = "GAME OVER";
            btn.gameObject.SetActive(true);
        }
        if (zamansayaci < 0)
            oyunDevam = false;
    }

    void FixedUpdate()
    {
        if (oyunDevam && !oyuntamam) { 
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");

        Vector3 kuvvet = new Vector3(-dikey, 0, yatay);
        rg.AddForce(kuvvet*hiz);
       
        }
        else
        {
            rg.velocity = Vector3.zero; 
            rg.angularVelocity = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision cls)
    {

        string objIsmi = cls.gameObject.name;
        if (objIsmi.Equals("bitis"))
        {
            // print("oyun tamamlandý");
            oyuntamam = true;
            durum.text = "COMPLETED";
            btn.gameObject.SetActive(true);
            SceneManager.LoadScene("bolum2");

    }
        else if(!objIsmi.Equals("zemin") && !objIsmi.Equals("Plane"))
        {
            cansayaci -= 1;
            can.text = cansayaci + "";
            if (cansayaci == 0)
                oyunDevam = false;
        }

    }

}
