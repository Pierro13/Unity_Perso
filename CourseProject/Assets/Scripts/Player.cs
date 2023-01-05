using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float m_TranslationSpeed;
    [SerializeField] float m_RotationSpeed;

    [SerializeField] GameObject m_BallPrefab;
    [SerializeField] Transform m_BallSpawnPos;
    [SerializeField] float m_BallInitSpeed;

    [SerializeField] float m_ShootingPeriod;
    float m_TimeNextShoot;

    [SerializeField] float m_BallLifeTime;

    Rigidbody m_Rigidbody;

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_TimeNextShoot = Time.time;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    GameObject ShootBall()
    {
        GameObject newBallGO = Instantiate(m_BallPrefab);
        newBallGO.transform.position = m_BallSpawnPos.position;
        newBallGO.GetComponent<Rigidbody>().velocity = m_BallSpawnPos.forward * m_BallInitSpeed;
        return newBallGO;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    float hInput, vInput;
    //    hInput = Input.GetAxis("Horizontal");
    //    vInput = Input.GetAxis("Vertical");
    //    Vector3 vect = vInput * new Vector3(0, 0, 1) * m_TranslationSpeed * Time.deltaTime;
    //    transform.Translate(vect, Space.Self);

    //    float deltaAngle = hInput * m_RotationSpeed * Time.deltaTime;
    //    transform.Rotate(Vector3.up, deltaAngle, Space.Self);
    //}

    void FixedUpdate()
    {
        
        // Comportement dynamique
        float hInput, vInput;
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");


        #region Commentaire
        /*
        // Translation
        Vector3 vect = vInput * transform.forward * m_TranslationSpeed * Time.fixedDeltaTime;
        m_Rigidbody.MovePosition(transform.position + vect);

        // Rotation
        float deltaAngle = hInput * m_RotationSpeed * Time.deltaTime;
        Quaternion qRot = Quaternion.AngleAxis(deltaAngle, Vector3.up);

        Quaternion qStraightUpRot = Quaternion.FromToRotation(transform.up, Vector3.up);
        Quaternion qUprightOrient = Quaternion.Slerp(transform.rotation, 
                                                    qStraightUpRot * transform.rotation,
                                                    Time.fixedDeltaTime * 4);



        Quaternion qNewOrientation = qRot * qUprightOrient;
        m_Rigidbody.MoveRotation(qNewOrientation);

        m_Rigidbody.velocity = Vector3.zero;
        m_Rigidbody.angularVelocity = Vector3.zero;
        */
#endregion

        // Velocity
        Vector3 targetVelocity = transform.forward * vInput * m_TranslationSpeed;
        Vector3 delatVelocity = targetVelocity - m_Rigidbody.velocity;
        m_Rigidbody.AddForce(delatVelocity, ForceMode.VelocityChange);

        // Rotation
        Vector3 targetAngularVelocity = hInput * transform.up * m_RotationSpeed;
        Vector3 deltaAngVel = targetAngularVelocity - m_Rigidbody.angularVelocity;
        m_Rigidbody.AddTorque(deltaAngVel, ForceMode.VelocityChange);

        Quaternion qStraightUpRot = Quaternion.FromToRotation(transform.up, Vector3.up);
        Quaternion qUprightOrient = Quaternion.Slerp(transform.rotation,
                                                    qStraightUpRot * transform.rotation,
                                                    Time.fixedDeltaTime * 4);

        m_Rigidbody.MoveRotation(qUprightOrient);

        //

        bool isFiring = Input.GetButton("Fire1");
        if (isFiring && Time.time > m_TimeNextShoot)
        {
            Destroy(ShootBall(), m_BallLifeTime);
            m_TimeNextShoot = Time.time + m_ShootingPeriod;
        }
    }
}