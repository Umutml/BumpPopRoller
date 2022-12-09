using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    private float xBound = 12.5f;
    private CinemachineVirtualCamera vcam;
    private AudioSource GameAudio;
    
    private void Start()
    {
        vcam = GameObject.Find("CMvcam1").GetComponent<CinemachineVirtualCamera>();
        GameAudio = GameObject.Find("GameManager").GetComponentInChildren<AudioSource>();
    }
    private void Update()
    {
        DeactivateObject();
        CenterizeForce();
    }
    private void OnCollisionStay(Collision collision)
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * GameManager.instance.constForce);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.tag = "Touched";
            vcam.Follow = collision.transform; // Camera Target Changed
            Rigidbody collrb = collision.gameObject.GetComponent<Rigidbody>();
            collrb.isKinematic = false;
            for (int i = 0; i < GameManager.instance.SpawnCount; i++)
            {
                GameManager.instance.activeBall++;
                GameObject cloneBall = Instantiate(collision.gameObject, collision.transform.position, Quaternion.identity);
                Rigidbody clonerb = cloneBall.GetComponent<Rigidbody>();
                clonerb.AddExplosionForce(GameManager.instance.expForce, transform.position, 10f, 0, ForceMode.Impulse);
            }
            GameAudio.Play();
        }
        
    }
    private void DeactivateObject()
    {
        if (transform.position.y < -30) 
        { 
            gameObject.SetActive(false);
            Destroy(gameObject);
            GameManager.instance.activeBall--;
        }
    }
    private void CenterizeForce()
    {
        if (transform.position.x >= xBound)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.left * 20);
        }
        if (transform.position.x <= -xBound)                                 // If balls go left and right boundries add little force to middle           
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * 20);
        }
    }



}
