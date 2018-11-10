using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public Camera camera;
	public Rigidbody rb;
	

	void Update()
	{
		if (!isLocalPlayer)
		{
			camera.enabled = false;
			return;

		}


		Screen.lockCursor = true;
		Screen.lockCursor = false;
		Cursor.visible = false;

		//var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		//var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;



		float p = 0.3f;


		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(-1 * p, 0, 0);
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(1 * p, 0, 0);
		}
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(0, 0, 1 * p);
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(0, 0, -1 * p);
		}
		if (Input.GetKey(KeyCode.Space)){
			transform.Translate(0, 1 * p, 0);
		}
		if (Input.GetKey(KeyCode.LeftShift)) 
		{
				transform.Translate(0, -1 * p, 0);
		}
		//transform.Translate(0, 0, z);

		//if (Input.GetMouseButtonDown(0))
		//{
			//CmdFire();
		//}
	}
		

	// This [Command] code is called on the Client …
	// … but it is run on the Server!
	[Command]
	void CmdFire()
	{
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 500;

		// Spawn the bullet on the Clients
		NetworkServer.Spawn(bullet);

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);
	}

	public override void OnStartLocalPlayer ()
	{
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}

	void Start()
	{
		camera.enabled = true;
	}


}