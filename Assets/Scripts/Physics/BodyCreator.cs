using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BodyCreator : MonoBehaviour
{
    [SerializeField] Body bodyPrefab;
    [SerializeField] FloatData speed;
    [SerializeField] FloatData size;
    [SerializeField] FloatData density;
    [SerializeField] FloatData drag;
    [SerializeField] FloatData restitution;
    [SerializeField] EnumData bodyType;

	bool action = false;
	bool pressed = false;

    void Update()
    {
        if (action && (pressed || Input.GetKey(KeyCode.LeftControl)))
        {
            pressed = false;

            Vector3 position = Simulator.Instance.GetScreenToWorldPosition(Input.mousePosition);
            
            Body body = Instantiate(bodyPrefab, position, Quaternion.identity); //Quaternion identity here means no rotation
            body.bodyType = (Body.eBodyType)bodyType.value;
            body.shape.size = size.value;
            body.shape.density = density.value;
            body.drag = drag.value;
            body.restitution = restitution.value;
            
            body.ApplyForce(Random.insideUnitCircle.normalized * speed.value, Body.eForceMode.Velocity);

            Simulator.Instance.bodies.Add(body);
        }
    }

    public void OnPointerDown()
    {
        if (Input.GetMouseButton(0))
        {
            action = true;
            pressed = true;
        }
    }

    public void OnPointerExit()
    {
        action = false;
    }

    public void OnPointerUp()
    {
        action = false;
    }

}
