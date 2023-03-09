using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class birds : MonoBehaviour
{
    Vector2 startPosition;
    public float force;  // Rigidbody'nin uygulayacaðý kuvvet

    [SerializeField] float maxDragValue = 3; // Maksimum sürükleme mesafesini yazdýk. SerializeField deðer baþka scriptlerden eriþilemez fakat Inspector panelinden dzenlenebilir

    /*Rigidbody2D rb2d;                  GetComponent<Rigidbody2D>()            Componentleri karþýlarýndaki þekilde de tanýmlayabiliriz.
    SpriteRenderer sprite;               GetComponent<SpriteRenderer>()*/

    void Start()
    {
        startPosition = GetComponent<Rigidbody2D>().position; // Bu kod ile kuþumuzun baþlangýç konumunu ayarladýk.
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void OnMouseDown()
    {  // Týklanýnca kýrmýzý renk olmasýný saðladýk
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    void OnMouseUp()
    {
        Vector2 currentPosition = GetComponent<Rigidbody2D>().position;  // Fareyi býraktýðýmýzda olacak son konumu ayarlardýk.
        Vector2 direction = startPosition - currentPosition;   // Gittiði yolu tanýmlamak için yazdýk.
        direction.Normalize();  // Bu kod ile çapraz giderken hem y hem de x ekseninin kuvvetini almadan normal hýzý ile gitmesi için yazdýk.

        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().AddForce(direction * force);
       
        GetComponent<SpriteRenderer>().color = Color.white;  // Týklama kaldýrýldýðý zaman eski rengine dönmesini saðladýk.
    }

    void OnMouseDrag()
    {  // Mouse týklanarak seçilince faremizi takip etmesini saðladýk.
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPositon = mousePosition;

        float distance = Vector2.Distance(startPosition, desiredPositon);// baþlangýç pozisyonu ve mouse konumu arasýndaki mesafeyi belirledik.
        if(distance > maxDragValue) // sürükleme mesafesinden fazla ise olacaklar.
        {
            Vector2 direction = desiredPositon - startPosition;
            direction.Normalize();
            desiredPositon = startPosition + (direction * maxDragValue);
        }
        if (desiredPositon.x > startPosition.x)
        {
            desiredPositon.x = startPosition.x;
        }
        GetComponent<Rigidbody2D>().position = desiredPositon;

    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)  // Çarpýnca gerçekleþecek olaylarý yazdým.  
    {
        StartCoroutine(ResetWait());
    }

    IEnumerator ResetWait()
    {
        yield return new WaitForSeconds(3); // 3 saniye bekledikten sonra tekrar eski konumuna dönderdim.
        GetComponent<Rigidbody2D>().position = startPosition;   // Çarptýktan sonra baþlangýç konumuna getirdim. Inspector'den Freeze Rotation ile dönmeyi durdurdum.
        GetComponent<Rigidbody2D>().isKinematic = true;         // En baþa dönünce düþmemesi için yazdým.
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;    // Tekrar tekrar baþa gelip ayný hareketleri yapmamasý için yazdým. Hýzýný sýfýrladým. 
    }


}