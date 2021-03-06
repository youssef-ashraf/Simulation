﻿using System.Collections;
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
        fire = GameObject.Find("Fire");
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
                te.GetComponent<UnityEngine.UI.Text>().text = "AM Ended";
                var csv = new System.Text.StringBuilder();
                var newLine = "";
                csv.AppendLine(newLine);
                File.AppendAllText("move.csv", csv.ToString());
            }
            else
            {
                auto = true;
                te.GetComponent<UnityEngine.UI.Text>().text = "AM Started";
                
            }
        }
        if (auto)
        {
            Vector3 vv = fire.transform.position - gameObject.transform.position;

            distances = gameObject.GetComponent<Lasers>().getDistances();
            dis = Mathf.Sqrt(Mathf.Pow(fire.transform.position.x - transform.position.x, 2) + Mathf.Pow(fire.transform.position.z - transform.position.z, 2));
            var csv = new System.Text.StringBuilder();
            var s = File.ReadAllText("move.csv");
            string[] s_list = s.Split(',');
            if (s_list[0] == "1")
            {

                te.GetComponent<UnityEngine.UI.Text>().text = s_list[1].Trim();
                print(s_list[1]);
                if (s_list[1].Trim() == "UpArrow")
                {

                    rb.MovePosition(transform.position + (transform.forward * Time.deltaTime *  speed));
                }
                if (s_list[1].Trim() == "DownArrow")
                {

                    rb.MovePosition(transform.position + (transform.forward * Time.deltaTime *  -speed));
                }

                if (s_list[1].Trim() == "LeftArrow")
                {
                    Quaternion deltaRotationLeft = Quaternion.Euler(new Vector3(0, -50, 0) *  Time.deltaTime);
                    rb.MoveRotation(rb.rotation * deltaRotationLeft);
                }
                if (s_list[1].Trim() == "RightArrow")
                {
                    Quaternion deltaRotationLeft = Quaternion.Euler(new Vector3(0, 50, 0) * Time.deltaTime);
                    rb.MoveRotation(rb.rotation * deltaRotationLeft);
                }
                var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", 0, dis, distances[0], distances[1], distances[2], distances[3], distances[4], distances[5], distances[6], distances[7], gameObject.transform.rotation.y, vv.x, vv.z);
                csv.AppendLine(newLine);
                File.WriteAllText("move.csv", csv.ToString());
            }
            else if (s_list[0] == "")
            {
                var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", 0, dis, distances[0], distances[1], distances[2], distances[3], distances[4], distances[5], distances[6], distances[7], gameObject.transform.rotation.y, vv.x, vv.z);
                csv.AppendLine(newLine);
                File.AppendAllText("move.csv", csv.ToString());
            }
            


            //string ans = result.Prediction;
            //te.GetComponent<UnityEngine.UI.Text>().text = ans;
        }




    }


    
}
