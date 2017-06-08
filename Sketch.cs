using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sketch : MonoBehaviour {
    public GameObject myPrefab;

	string _WebsiteURL = "http://infomgmt192.azurewebsites.net/tables/RevenueTest2?zumo-api-version=2.0.0";

    void Start () {
	    string jsonResponse = Request.GET(_WebsiteURL);
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }
		RevenueTest2[] rt2 = JsonReader.Deserialize<RevenueTest2[]>(jsonResponse);

		int totalCubes = 10;
        int totalDistance = 2;
        int i = 0;

		foreach (RevenueTest2 revenue in rt2)
        {
			Debug.Log("This products name is: " + revenue.City);
            float perc = i / (float)totalCubes;
            i++;
            float x = perc * totalDistance;
            float y = 5.0f;
            float z = 0.0f;
            GameObject newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
            newCube.GetComponent<myCubeScript>().setSize((1.0f - perc) * 2);
            newCube.GetComponent<myCubeScript>().ratateSpeed = perc;
			newCube.GetComponentInChildren<TextMesh>().text = revenue.City;
		    newCube.GetComponent<Renderer>().material.color = Color.blue; 


        }
    }
	void Update () {
	
	}
}
