using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour
{
    public GameObject gokyuzuBir ;
    public GameObject gokyuzuİki;  

    public float arkaplanhiz= -1.5f;   

    public GameObject engel ;
    public int kacAdetengel=5;
    GameObject [] engeller ;       

    Rigidbody2D fizikbir;
    Rigidbody2D fizikiki;

    float uzunluk =0;

    float degisimZaman =0;

    int sayac =0;

    bool oyunBitti = true;

    

    
    void Start()
    {
        fizikbir = gokyuzuBir.GetComponent<Rigidbody2D>();// gokyuzu birde fizik biri kullanarak rigidbodye ulaştık diyebiliriz.
        fizikiki = gokyuzuİki.GetComponent<Rigidbody2D>();//gokyuzu ikide fizik ikiyi kullanarak rigidbodye ulaştık diyebiliriz.


        fizikbir.velocity = new Vector2 (arkaplanhiz,0);// hareket hızını belirledik
        fizikiki.velocity = new Vector2 (arkaplanhiz,0);// ikinci gökyüzünün hızını belirledik

        uzunluk = gokyuzuBir.GetComponent<BoxCollider2D>().size.x;//box coliderın uzunluğunu yani x eksenindeki uzunluğunu aldık

        engeller = new GameObject [kacAdetengel];
       

        for (int i =0;i<engeller.Length;i++)
        
        {//sıfırddan başlıyor engellerin uzunluğuna kadar devam edip gidecek

            engeller[i]=Instantiate (engel ,new Vector2 (-20,-20), Quaternion.identity);
            Rigidbody2D fizikEngel = engeller[i].AddComponent<Rigidbody2D>();
            //hafızada tutamadık
            fizikEngel.gravityScale =0;
            fizikEngel.velocity =new Vector2 (arkaplanhiz,0);
        }

    }


    void Update()
    {

        if (oyunBitti)
        {
            if (gokyuzuBir.transform.position.x <= -uzunluk)
            {
                gokyuzuBir.transform.position += new Vector3(uzunluk * 2, 0);
            }
            if (gokyuzuİki.transform.position.x <= -uzunluk)
            {
                gokyuzuİki.transform.position += new Vector3(uzunluk * 2, 0);
            }
            //-----------------------------------------------------------------------------------

            degisimZaman += Time.deltaTime;
            if (degisimZaman > 2f)
            {
                degisimZaman = 0;
                float yEksenim = Random.Range(1.31f, 2.7f);
                engeller[sayac].transform.position = new Vector3(10, yEksenim);
                sayac++;
                if (sayac >= engeller.Length)
                {
                    sayac = 0;
                }
            }

            else
            {


            }


        }


    }

    public void oyunbitti ()
    {
        for (int i =0;i<engeller.Length; i++)
        {
            engeller[i].GetComponent<Rigidbody2D>().velocity =Vector2.zero;
            fizikbir.velocity = Vector2.zero;
            fizikiki.velocity = Vector2.zero;

            oyunBitti = false;


        }
       
        
    }
}
