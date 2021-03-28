using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using SimulationML.Model;

public class DT : MonoBehaviour
{
    bool auto = false;
    GameObject te;
    float[] distances = new float[8];
    float dis;
    GameObject fire;

    // Start is called before the first frame update
    void Start()
    {
        
        te = GameObject.Find("Text1");
        fire = GameObject.Find("Cube");
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
                    var input = new ModelInput()
                    {
                        Distance = dis,
                        S = distances[0],
                        SW = distances[1],
                        W = distances[2],
                        NW = distances[3],
                        N = distances[4],
                        NE = distances[5],
                        E = distances[6],
                        SE = distances[7],
                        Car_Dir = gameObject.transform.rotation.y,
                        Fire_Dir_X = vv.x,
                        Fire_Dir_Y = vv.z
                    };
                    ModelOutput result = ConsumeModel.Predict(input);
                    string ans = result.Prediction;
                    te.GetComponent<UnityEngine.UI.Text>().text = ans;
                }
            }
        }


        
       
    }


    
}
