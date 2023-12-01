using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strait : MonoBehaviour
{

    private float scaleDuration = 0.2f;
    public Vector3 targetScale = new Vector3(0.15f, 0.14f, 1f);
    public Vector3 startScale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator ShipScaleDown(GameObject obj, Vector3 startScale)
    {
      
        float elapsedTime = 0f;
        Debug.Log("Called");
        while (elapsedTime < scaleDuration)  {
            obj.transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / scaleDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        obj.transform.localScale = targetScale;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Works");
        if (col.gameObject.tag == "Ship")
        {
            
            startScale = col.gameObject.transform.localScale;
                StartCoroutine(ShipScaleDown(col.gameObject, startScale));
        }
        Debug.Log("Works");
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ship")
        {

            
            StartCoroutine(ShipScaleUp(col.gameObject, startScale));
        }
        Debug.Log("Works");
    }

    IEnumerator ShipScaleUp(GameObject obj, Vector3 startScale)
    {

        float elapsedTime = 0f;

        while (elapsedTime < scaleDuration)
        {
            obj.transform.localScale = Vector3.Lerp(targetScale, startScale, elapsedTime / scaleDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        obj.transform.localScale = startScale;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
