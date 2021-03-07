using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataCollector : MonoBehaviour
{
    bool collect = false;
    float[] distances = new float[8];
    string key;
    float dis;
    GameObject fire;
    GameObject te;
    // Start is called before the first frame update
    void Start()
    {
        fire = GameObject.Find("Cube");
        te = GameObject.Find("Text1");
        dis = Mathf.Sqrt(Mathf.Pow(fire.transform.position.x - transform.position.x, 2) + Mathf.Pow(fire.transform.position.z - transform.position.z, 2));
        te.GetComponent<UnityEngine.UI.Text>().text = "Bloody Hell";
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if (collect)
            {
                collect = false;
                te.GetComponent<UnityEngine.UI.Text>().text = "Collect Ended";
            }
            else 
            {
                collect = true;
                te.GetComponent<UnityEngine.UI.Text>().text = "Collect Started";
            }
        }

        if (collect)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                distances = gameObject.GetComponent<Lasers>().getDistances();
                dis = Mathf.Sqrt(Mathf.Pow(fire.transform.position.x - transform.position.x, 2) + Mathf.Pow(fire.transform.position.z - transform.position.z, 2));
                te.GetComponent<UnityEngine.UI.Text>().text = "Distance: " + (int)dis + "\n" + distances[1] + "\n" + distances[2] + "\n" + distances[3] + "\n" + distances[4] + "\n" + distances[5] + "\n" + distances[6] + "\n" + distances[7];
                var csv = new System.Text.StringBuilder();
                foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(kcode))
                        key = kcode.ToString();
                }


                var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", dis, distances[0], distances[1], distances[2], distances[3], distances[4], distances[5], distances[6], distances[7], key);
                csv.AppendLine(newLine);
                File.AppendAllText("new.csv", csv.ToString());
            }
        }
    }
}
