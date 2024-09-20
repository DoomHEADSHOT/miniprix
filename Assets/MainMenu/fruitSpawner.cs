using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fruitSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public GameObject[] fruits;
    private float waitTime = .1f;
    private float timer = 0.0f;
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
       
            GameObject fruit = Instantiate(fruits[Random.Range(0,fruits.Length)],transform);
           // fruit.transform.SetParent(transform);
            fruit.GetComponent<Rigidbody>().AddForce(Vector3.up*25,ForceMode.Impulse);
            Debug.Log("Spawned");
            Destroy(fruit,15f);
              timer = timer - waitTime;
         }
    }
}
