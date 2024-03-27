using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    int count = 0;
    [SerializeField] AudioClip clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collectable"))
        {
            count++;
            Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(clip, collision.transform.position);    
            Debug.Log(count);
        }
                
    }





}
