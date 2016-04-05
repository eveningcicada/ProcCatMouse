using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cat : MonoBehaviour {

    // Update is called once per frame
    void FixedUpdate ()
    {
        foreach (Mouse thisMouse in levelManager.listOfMice)
        {
            Vector3 directionToMouse = thisMouse.transform.position - transform.position;

            float angle = Vector3.Angle(directionToMouse, transform.forward);

            if (angle < 30)
            {
                Ray catRay = new Ray(transform.position, directionToMouse);

                RaycastHit catRayHitInfo = new RaycastHit();

                if (Physics.Raycast(catRay, out catRayHitInfo, 100f))
                {
                    if (catRayHitInfo.collider.tag == "Mouse")
                    {
                        if (catRayHitInfo.distance <= 1.5f)
                        {
                            Destroy(thisMouse.gameObject);
                        }
                        else
                        {
                            GetComponent<Rigidbody>().AddForce(directionToMouse.normalized * 1000f);
                        }
                    }
                }

                Debug.DrawRay(transform.position, directionToMouse, Color.red);
            }
        }
    }

    void OnDestroy()
    {
        levelManager.listOfCats.Remove(this);
        Debug.Log("I've been slain!");
    }
}
