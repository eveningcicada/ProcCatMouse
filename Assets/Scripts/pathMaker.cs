using UnityEngine;
using System.Collections;

public class pathMaker : MonoBehaviour {

    [SerializeField] Transform[] pathMakerPrefab;
    [SerializeField] int tileCounter = 25;

	// Use this for initialization
	void Start ()
    {
        transform.position = new Vector3(-8f, 0.5f, -8f);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Ray trapRay = new Ray(transform.position, transform.forward);
        RaycastHit trapRayHitInfo = new RaycastHit();

        Debug.DrawRay(transform.position, transform.forward, Color.cyan);

        if (tileCounter > 0)
        {
            if (Physics.Raycast(trapRay, out trapRayHitInfo, 2.5f))
            {
                Debug.Log("You hit wall!");
                if (trapRayHitInfo.collider.gameObject.name == "Wall L")
                {
                    int randomNo = Random.Range(0, 5);

                    transform.localEulerAngles -= new Vector3(0f, 90f, 0f);

                    Instantiate(pathMakerPrefab[randomNo], this.transform.position, this.transform.rotation);
                    transform.localPosition += transform.forward * 4f;

                    transform.localEulerAngles -= new Vector3(0f, 90f, 0f);

                    tileCounter--;
                }
                else if (trapRayHitInfo.collider.gameObject.name == "Wall R")
                {
                    int randomNo = Random.Range(0, 5);

                    transform.localEulerAngles += new Vector3(0f, 90f, 0f);

                    Instantiate(pathMakerPrefab[randomNo], this.transform.position, this.transform.rotation);
                    transform.localPosition += transform.forward * 4f;

                    transform.localEulerAngles += new Vector3(0f, 90f, 0f);

                    tileCounter--;
                }
            }
            else
            {
                int randomNo = Random.Range(0, 5);

                Instantiate(pathMakerPrefab[randomNo], this.transform.position, this.transform.rotation);
                transform.localPosition += transform.forward *4f;

                tileCounter--;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
