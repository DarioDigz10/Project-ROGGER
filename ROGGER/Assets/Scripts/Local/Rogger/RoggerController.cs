using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(atractionController))]
public class RoggerController : MonoBehaviour
{
    public GameObject floor;
    private NavMeshAgent agent;
    private Vector3 target;
    private float targetTime;

    public float time;
    public float radioPath;
    public float radioSearch;


    //navMeshAgent propierties
    public float speed;
    public float angSpeed;
    public float stopDistance;

    private float dimX;
    private float dimZ;

    private bool atraido;
    [HideInInspector] public bool search;

    //[HideInInspector] public bool busqueda;

    private atractionController m_atractionController;
    /*public atractionController atractionController
	{
		get
		{
			if (m_atractionController == null) m_atractionController = GetComponent<atractionController>();
			return m_atractionController;
		}
	}*/

    void Start() {
        m_atractionController = GameManager.Instance.atractionController;
        agent = this.GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.angularSpeed = angSpeed;
        agent.stoppingDistance = stopDistance;

        dimX = floor.GetComponent<MeshRenderer>().bounds.size.x / 2;
        dimZ = floor.GetComponent<MeshRenderer>().bounds.size.z / 2;

        //Debug.Log ("x: "+dimX);
        //Debug.Log ("z: "+dimZ);

        targetTime = time;

        if (radioSearch == 0) {
            radioSearch = radioPath;
        }

        atraido = false;
        //search = false;
        //busqueda = false;
    }

    void FixedUpdate() {
        /*
		if (agent.remainingDistance <= 0.5) {
			newPath ();
		}*/

        if (targetTime <= 0 && agent.remainingDistance <= 0.5) {
            //search = true;
            //busqueda = true;
            atraido = false;
            m_atractionController.Search();
            if (atraido == false) {
                newPath();
            }
        }
        else {
            targetTime -= Time.deltaTime;
        }

        //Debug.Log (agent.remainingDistance + " distance");

    }

    void newPath() {
        //if (atraido == false) {
        //Debug.Log ("nuevo Path");
        float newX = Random.Range(this.transform.position.x + radioPath, this.transform.position.x - radioPath);
        float newZ = Random.Range(this.transform.position.z + radioPath, this.transform.position.z - radioPath);
        target = new Vector3(newX, this.transform.position.y, newZ);

        if (target.x > dimX || target.x < (dimX * -1) || target.z > dimZ || target.z < (dimZ * -1)) {
            //Debug.Log ("reiniciado");
            newPath();
            //agent.SetDestination (Vector3.zero);
        }
        else {
            agent.SetDestination(target);
        }

        //Debug.Log(target);
        targetTime = time;
        //}
    }

    public void atractiblePath(Vector3 destino) {
        Debug.Log(destino + "ATRAIDO DIOS MIO HAZ QUE PARE");
        agent.SetDestination(destino);
        atraido = true;
        targetTime = time;
    }
}
