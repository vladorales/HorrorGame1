using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ItemInspect : MonoBehaviour
{
	Vector3 ItemStartPosition;
	Quaternion StartingRot;
	int layerMask = 1 << 8;

	public playerMovement move;
	public mouseLook mouseRotation;
	public Transform InspectZone;

	public static GameObject currentObject, manager;
	private Rigidbody rb;

	bool isInspecting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
