using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{

    [SerializeField] GameObject confettiGO;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") || other.CompareTag("Touched") || other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            GameManager.instance.finishedBall++;
            GameManager.money++;
            GameManager.instance.activeBall--;
            GameObject cloneConfetti = Instantiate(confettiGO, other.transform.position, Quaternion.identity);
            Destroy(cloneConfetti, 2f);
        }
    }

}
