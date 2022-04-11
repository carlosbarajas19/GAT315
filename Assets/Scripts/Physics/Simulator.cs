using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulator : Singleton<Simulator>
{
	[SerializeField] StringData fps;
	[SerializeField] IntData fixedFPS;
	[SerializeField] List<Force> forces;

	public List<Body> bodies { get; set; } = new List<Body>();
	public float fixedDeltaTime => 1.0f / fixedFPS.value;
	
	Camera activeCamera;
	float timeAccumulator = 0;

	private void Start()
	{
		activeCamera = Camera.main;
	}

    private void Update()
    {
		//get fps
		fps.value = (1.0f/Time.deltaTime).ToString("F2");

		//
		timeAccumulator += Time.deltaTime;

		forces.ForEach(force => force.ApplyForce(bodies));

		while (timeAccumulator >= fixedDeltaTime)
        {
			bodies.ForEach(body =>
			{
				Integrator.SemiImplicitEuler(body, Time.deltaTime);
			}); //using linq

			timeAccumulator += fixedDeltaTime;
		}

       

		bodies.ForEach(body => body.acceleration = Vector2.zero);


        /*foreach (var body in bodies) // "old school"
        {
			Integrator.SemiImplicitEuler(body, Time.deltaTime);
        }*/
    }

    public Vector3 GetScreenToWorldPosition(Vector2 screen)
	{
		Vector3 world = activeCamera.ScreenToWorldPoint(screen);
		return new Vector3(world.x, world.y, 0);
	}
}
