using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenu : MonoBehaviour
{
    public GameObject backgroud1;
    public GameObject backgroud2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(swap_background());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator swap_background()
    {
        backgroud1.SetActive(true);
        backgroud2.SetActive(false);
        yield return new WaitForSeconds(10f);
        backgroud1.SetActive(false);
        backgroud2.SetActive(true);
        yield return new WaitForSeconds(10f);
        StartCoroutine(swap_background());
    }
}
