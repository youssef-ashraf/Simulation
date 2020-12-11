public class Car 
{
    private DNA dna ;
private NeuralNetwork network ;
private Vector3 intialPoint ;
private float distance ;

private bool initialized = false ;
void Start()
{

}
public void Initialize ()
{
    network = new NeuralNetwork();
    dna = new DNA (network.grtWeights());
    intialPoint = transform.position ;
    initialized = true ;
}
public void Initialize(DNA dna)
{
    network = new NeuralNetwork(dna);
    this.dna = dna ;
    intialPoint = transform.position ;
    initialized = true ;
}
void Update ()
{
    if(initialized)
    {
        float[] = GetComponent<Lasers>().getDistances();
        network.feedForward(inputs);
        list<float> outputs = network.getOutputs();
        GetComponent<CarMov>().updateMovement(outputs);
        distance = Vector3.Distance(transform.position , intialPoint);
    }
}
void OnTriggerEnter(Collider col)
{
    changeCamera();
}
public DNA getDNA()
{
    return dna ;
}
public void changeCamera()
{
    List<GameObject> cars = GameObject.Find("CarController").GetComponent<CarControllerAI>().getCars();
    if(cars.Count == 2)
    {
        controller.winner = cars[0].GetComponent<Car>.getDNA();
        controller.secWinner = cars[1].GetComponent<Car>.getDNA();
    }
    if (cars.Count == 1)
    {
        if(!controller.winner.Equals(cars[0].GetComponent<Car>().getDNA()))
        {
            DNA inter = controller.secWinner ;
            controller.secWinner = controller.winner ;
            controller.winner = inter ;
        }
        cars.Remove (gameObject);
        Destory (gameObject);
    }
    else
    {
        int rand = Random.Range( 0 , (int)cars.Count);
        if (cars[rand]==gameObject)
        {
            changeCamera();
        }
        else
        {
            if (gameObject == GameObject.Find("Camera").GetComponent<CameraMovement>().getFollowing())
            {
                GameObject.Find("Camera").GetComponent<CameraMovement>().Follow(cars[rand]);
            }
            cars.Remove(gameObject);
            Destory(gameObject);
        }
    }
}
    
}



public class CarMov
{
    private float vyRot = 0 ;
public float speedLinear = 0.2f ;
private float vz ;
private float acceleration ;
private float increaseAcc = 5 ;
public bool activeAcceleration = true ;
public float speedRotation = 0.5f ;

void Start ()
{
    vz = speedLinear ;

}
void Update ()
{
    float time = Time.deltaTime ;
    transform.position += transform.forward * (vz*time + 0.5f*acceleration*time*time);
    transform.Rotate(new Vector3(0 , vyRot , 0));

}
public float getAcceleration ()
{
    return acceleration ;
}
public void updateMovement(List <float> outputsRot)
{
    if(outputs[0]>1f)
    {
        vyRot=(outputs[0]*2-1)*speedRotation * Time.deltaTime ;
    }
    else
    {
         vyRot= outputs[0]*2*speedRotation * Time.deltaTime ;
        
    }
    if(outputs[1]*2>1f)
    {
        acceleration = (outputs[0]*2-1)*increaseAcc ;

    }
    else
    {
        acceleration = outputs[0]*2*increaseAcc ;
        
    }

}


public class CameraMovement 
{
    public GameObject FirstCar ;
    public float speedRotCamera = 0.2f ;
    public float KeyRotSpeedCamera = 500f ;
    private float rotCamera = 0 ;
    public float timeAnimation = 1 ;
    public GameObject follow ;
    public Vector3 initialPosition ;
    public float intialTime ;

    void Start()
    {
        List <GameObject>cars = GameObject.Find("CarController").GetComponent<CarControllerAI>().getCars();
        follow = cars[Random.Range(0 , cars.Count-1)];
        initialPosition = transform.position ;

    }

    void Update ()
    {
        if (follow!=null)
        {
            float timePassed = (Time.time - intialTime);
            float proportion = timePassed / timeAnimation ;
            Vector3 currentPosition ;
            if (proportion<1)
            {
                currentPosition = Vector3.Lerp(initialPosition , follow.transform.position , proportion) ;

            }
            else
            {
                currentPosition = follow.transform.position ;
            }
            transform.position = new Vector3 (currentPosition.x , currentPosition.y + 11.21f , currentPosition.z - 17.91f);
            transform.LookAt(currentPosition);
            transform.Translate (Vector3.right * Time.deltaTime * rotCamera * 5);

        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            List<GameObject>cars = GameObject.Find("carController").GetComponent<CarControllerAI>().getCars();
            int index = cars.IndexOf(follow);
            if (index == cars.Count-1)
            {
                index = 0 ;
            }
            else
            {
                index += 1 ;
            }
            Follow(cars[index]);
        }
    }
    public void Follow (GameObject newFollow)
    {
        intialPoint = follow.transform.position ;
        intialTime = Time.time ;
        follow = newFollow ;
    }
    public void unFollow ()
    {
        follow = null ;
    }

}

public class CarControllerAI
{
    public List<GameObject>cars = new List <GameObject>();
    public DNA winner ; 
    public DNA secWinner ;

    void Start()
    {


    }
    void Update ()
    {

    }
    public List<GameObject> getCars()
    {
        return cars ;

    }
}
    
 



















