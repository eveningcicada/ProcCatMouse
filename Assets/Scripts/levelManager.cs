using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour {

    [SerializeField] Cat catPrefab;
    [SerializeField] Mouse mousePrefab;

    public static List<Cat> listOfCats = new List<Cat>();
    public static List<Mouse> listOfMice = new List<Mouse>();

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        Ray pointerRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit pointerRayHitInfo = new RaycastHit();

        if (Physics.Raycast(pointerRay, out pointerRayHitInfo, 1000f))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Cat newCat = (Cat)Instantiate(catPrefab, pointerRayHitInfo.point + Vector3.up * 0.6f, Quaternion.identity);
                listOfCats.Add(newCat);
            }
            if (Input.GetMouseButtonDown(1))
            {
                Mouse newMouse = (Mouse)Instantiate(mousePrefab, pointerRayHitInfo.point + Vector3.up * 0.6f, Quaternion.identity);
                listOfMice.Add(newMouse);
            }
        }
	}
}
