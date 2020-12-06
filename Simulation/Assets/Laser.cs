

public class Laser 
{
    public Color laserColor = new Color (0 , 1 , 0 , 0.5f );
    public float distanceLaser = 50 ;
    public float finalLength = 0.02f ;
    public float initialLength = 0.02f ;

    private Vector3 positionLaser ;
    private LinerRemderer linerRemderer ;
    private float distance = 0 ;
    

     void Start ()
  {
      distance = distanceLaser ;
      positionLaser = new Vector3 (0 , 0 , finalLength) ;
      linerRemderer = gameObject.AddComponent<LinerRemderer>();
      linerRemderer.material = new Material (Shader.Find("particles/Additive")) ;
      linerRemderer.startColor = laserColor ;
      linerRemderer.endColor = laserColor ;
      linerRemderer.startWidth = initialLength ;
      linerRemderer.endWidth = finalLength ;
      linerRemderer.positionCount = 2 ;
  }

  void Update ()
  {
     Vector3 finalPoint = transform.position + transform.forward * distanceLaser ;
     RaycastHit collisionPoint ;
     if (Physics.Raycast(transform.position , transform.forward , out collisionPoint , distanceLaser))
     {
         linerRemderer.SetPostion(0 , transform.position) ;
         linerRemderer.SetPostion(1 , collisionPoint.point) ;
         distance = collisionPoint.distance ;
     }
     else
     {
         linerRemderer.SetPostion(0 , transform.position) ;
         linerRemderer.SetPostion(1 , finalPoint) ; 
         distance = distanceLaser ;
     }
  }
 
 
 public void getDistance ()
      {
          return distance ;
      }

}
