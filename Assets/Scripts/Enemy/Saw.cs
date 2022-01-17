using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField]
    private Collider2D m_Collider2D;
    [SerializeField]
    private Transform targetRotation;
    [SerializeField]
    private float m_Speed = 3f;
    [SerializeField]
    private bool m_RotateClockwise = false;
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        if (targetRotation == null) {
				targetRotation = transform;
			}
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = targetRotation.rotation.eulerAngles;
			if (!m_RotateClockwise) {
				rotation.z += m_Speed;
			} else {
				rotation.z -= m_Speed;
			}
			targetRotation.rotation = Quaternion.Euler (rotation);
    }
}
