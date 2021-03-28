using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class DT : MonoBehaviour
{
    public int speed = 15;
    bool auto = false;
    GameObject te;
    float[] distances = new float[8];
    float dis;
    GameObject fire;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
        te = GameObject.Find("Text1");
        fire = GameObject.Find("Cube");
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (auto)
            {
                auto = false;
                te.GetComponent<UnityEngine.UI.Text>().text = "Automatic Move Ended";
            }
            else
            {
                auto = true;
                te.GetComponent<UnityEngine.UI.Text>().text = "Automatic Move Started";
                if (auto)
                {
                    Vector3 vv = fire.transform.position - gameObject.transform.position;

                    distances = gameObject.GetComponent<Lasers>().getDistances();
                    dis = Mathf.Sqrt(Mathf.Pow(fire.transform.position.x - transform.position.x, 2) + Mathf.Pow(fire.transform.position.z - transform.position.z, 2));
                    //var input = new ModelInput()
                    //{
                    //    Distance = dis,
                    //    S = distances[0],
                    //    SW = distances[1],
                    //    W = distances[2],
                    //    NW = distances[3],
                    //    N = distances[4],
                    //    NE = distances[5],
                    //    E = distances[6],
                    //    SE = distances[7],
                    //    Car_Dir = gameObject.transform.rotation.y,
                    //    Fire_Dir_X = vv.x,
                    //    Fire_Dir_Y = vv.z
                    //};
                    //ModelOutput result = ConsumeModel.Predict(input);
                    var csv = new System.Text.StringBuilder();
                    var s = File.ReadAllText("move.csv");
                    var s_list = s.Split(',');
                    if(s_list[0] == "1")
                    {

                        te.GetComponent<UnityEngine.UI.Text>().text = s_list[1];
                        if (s_list[1] == "UpArrow")
                        {

                            rb.MovePosition(transform.position + (transform.forward * Time.deltaTime * speed));
                        }
                        if (s_list[1] == "DownArrow")
                        {

                            rb.MovePosition(transform.position + (transform.forward * Time.deltaTime * -speed));
                        }

                        if (s_list[1] == "DownArrow")
                        {
                            Quaternion deltaRotationLeft = Quaternion.Euler(new Vector3(0, -50, 0) * Time.deltaTime);
                            rb.MoveRotation(rb.rotation * deltaRotationLeft);
                        }
                        if (s_list[1] == "DownArrow")
                        {
                            Quaternion deltaRotationLeft = Quaternion.Euler(new Vector3(0, 50, 0) * Time.deltaTime);
                            rb.MoveRotation(rb.rotation * deltaRotationLeft);
                        }
                        var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", 0,dis, distances[0], distances[1], distances[2], distances[3], distances[4], distances[5], distances[6], distances[7], gameObject.transform.rotation.y, vv.x, vv.z);
                        csv.AppendLine(newLine);
                        File.AppendAllText("move.csv", csv.ToString());
                    }
                    //string ans = result.Prediction;
                    //te.GetComponent<UnityEngine.UI.Text>().text = ans;
                }
            }
        }


        
       
    }


    
}
