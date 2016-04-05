using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class movement : MonoBehaviour {
 
    Ray moveRay;
    [SerializeField] float distance;

    // Update is called once per frame
    void FixedUpdate ()
    {
        distance = 1 + distance / 10f;

        GetComponent<Rigidbody>().velocity = transform.forward * 10f + Physics.gravity;

        moveRay = new Ray(transform.position, transform.forward);

        //Debug.DrawRay(transform.position, transform.forward, Color.cyan);

        if (Physics.SphereCast(moveRay, 0.25f, distance))
        {

            int randturn = Random.Range(0, 2);

            if (randturn == 0)
            {
                transform.localEulerAngles += transform.up * 90;
            }
            else
            {
                transform.localEulerAngles -= transform.up * 90;
            }
        }

	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, transform.forward * distance);
        Gizmos.DrawSphere(transform.position + transform.forward * distance, 0.25f);
    }
}
