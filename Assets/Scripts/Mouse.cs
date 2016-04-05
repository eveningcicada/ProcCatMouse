using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

    public Transform cat;

    float adrenaline = 0f;

	// Update is called once per frame
	void FixedUpdate ()
    {
        foreach (Cat thisCat in levelManager.listOfCats)
        {
            Vector3 directionToCat = thisCat.transform.position - transform.position;

            float angle = Vector3.Angle(directionToCat, transform.forward);

            adrenaline -= Time.deltaTime;

            if (angle < 60)
            {
                Ray mouseRay = new Ray(transform.position, directionToCat);

                RaycastHit mouseRayHitInfo = new RaycastHit();

                if (Physics.Raycast(mouseRay, out mouseRayHitInfo, 100f))
                {
                    if (mouseRayHitInfo.collider.tag == "Cat")
                    {
                        //GetComponent<Rigidbody>().AddForce(-directionToCat.normalized * 1000f);
                        transform.localEulerAngles += transform.up * 180f;

                        adrenaline = 0.5f;
                    }
                }
            }
        }

        if (adrenaline > 0f)
        {
            GetComponent<Rigidbody>().velocity *= 2f;
        }
        else
        {
            adrenaline = 0f;
        }
	}

    void OnDestroy()
    {
        levelManager.listOfMice.Remove(this);
        Debug.Log("I've been slain!");
    }
}
