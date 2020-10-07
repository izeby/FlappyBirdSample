using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class New : MonoBehaviour
{
    //TANIMLAMALAR
    public Sprite[] KusSprite;
    SpriteRenderer spriteRenderer;
    int kusSayac = 0;
    float kusAnimasyonZaman = 0;
    bool ilerigericontrol = true;
    Rigidbody2D fizik;
    int puan = 0;
    public Text puanText;
    bool oyunbitti = true;
    OyunKontrol oyunKontrol;
    AudioSource[] sesler;
    public int enYuksekPuan = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        oyunKontrol = GameObject.FindGameObjectWithTag("oyunkontrol").GetComponent<OyunKontrol>();
        sesler = GetComponents<AudioSource>();
        enYuksekPuan = PlayerPrefs.GetInt("enyuksekpuankayit");
        Debug.Log("EN YUKSEK PUAN :" + enYuksekPuan);

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && oyunbitti)
        {
            fizik.velocity = new Vector2(0, 0);
            fizik.AddForce(new Vector2(0, 220));
            sesler[0].Play();
        }

        if (fizik.velocity.y > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 15);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -15);
        }
        animasyon();

    }
    void animasyon()
    {
        //1saniyede bir bu if yapısının içine girecek
        kusAnimasyonZaman += Time.deltaTime;
        if (kusAnimasyonZaman > 0.9f)
        {
            kusAnimasyonZaman = 0;
            if (ilerigericontrol)
            {
                spriteRenderer.sprite = KusSprite[kusSayac]; //sayac 0 1 2 3
                kusSayac++;//3

                if (kusSayac == KusSprite.Length)
                {
                    kusSayac--;
                    ilerigericontrol = false;
                }
            }
            else
            {
                kusSayac--;
                spriteRenderer.sprite = KusSprite[kusSayac];//2 1 0 
                if (kusSayac == 0)
                {
                    kusSayac++;
                    ilerigericontrol = true;
                }

            }

        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "puan")
        {
            puan++;
            puanText.text = "Score = " + puan;
            Debug.Log(puan);
            sesler[1].Play();
        }

        if (col.gameObject.tag == "engel")
        {
            oyunbitti = false;
            sesler[2].Play();
            oyunKontrol.oyunbitti();
            GetComponent<CircleCollider2D>().enabled = false; //Öldüğü anda birden fazla cisme çarpıyor ve ses geliyor.
                                                              // Bunu önlemek için kapattık.

            if (puan > enYuksekPuan)
            {
                enYuksekPuan = puan;
                PlayerPrefs.SetInt("enyuksekpuankayit", enYuksekPuan);

            }

            Invoke("AnaMenuyeDon", 2);

        }

    }

    void AnaMenuyeDon()
    {
        PlayerPrefs.SetInt("puankayit", puan);
        SceneManager.LoadScene("anamenu");
       

    }

 }

