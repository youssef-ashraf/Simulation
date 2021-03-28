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
    GameObject Arrow;
    // Start is called before the first frame update
    void Start()
    {
        Arrow = GameObject.Find("Arrow");
        fire = GameObject.Find("Fire");
        te = GameObject.Find("Text1");
        dis = Mathf.Sqrt(Mathf.Pow(fire.transform.position.x - transform.position.x, 2) + Mathf.Pow(fire.transform.position.z - transform.position.z, 2));
        te.GetComponent<UnityEngine.UI.Text>().text = "Bloody Hell";
        //Arrow.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 vee = fire.transform.position - gameObject.transform.position;
        float f = (Mathf.Atan(vee.x / vee.z) * 180 / Mathf.PI);
        if (f > 0 && vee.z < 0 ) 
            f = f + 180;
        if (vee.z < 0 && vee.x > 0)
            f = f + 180;
        Arrow.transform.rotation = Quaternion.Euler(new Vector3(0, f,0));
        Arrow.transform.position = gameObject.transform.position + new Vector3(0, 1.5f, 0);

        if (Input.GetKeyDown(KeyCode.C))
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
                te.GetComponent<UnityEngine.UI.Text>().text = "Distance: " + (int)dis + "\n" + (int)(distances[1]*10) + "\n" + (int)(distances[2] * 10) + "\n" + (int)(distances[3] * 10) + "\n" + (int)(distances[4] * 10) + "\n" + (int)(distances[5] * 10) + "\n" + (int)(distances[6] * 10) + "\n" + (int)(distances[7] * 10);
                var csv = new System.Text.StringBuilder();
                foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(kcode))
                        key = kcode.ToString();
                }
                Vector3 vv = fire.transform.position - gameObject.transform.position;

                var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", dis, distances[0], distances[1], distances[2], distances[3], distances[4], distances[5], distances[6], distances[7],gameObject.transform.rotation.y,vv.x,vv.z, key);
                csv.AppendLine(newLine);
                File.AppendAllText("new.csv", csv.ToString());
            }
        }
    }
}
