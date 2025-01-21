using Assets.Script;
using Assets.Script.Character;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rig;
    public FixedJoystick joystick;
    public Player player;
    public Camera camera;
    public float runMod = 2.5f;
    private float RunSpeed =>
        player.stats.speed * runMod;
    private float currentSpeed;
    private float Direction { get; set; } = 0;

	public void Move()
	{
		float x = joystick.Horizontal * currentSpeed;
        float y = joystick.Vertical * currentSpeed;
        if (x > 0) Direction = 0;
        else if(x < 0) Direction = 180f;
		Direction = x switch
        {
			> 0 => 0,
			< 0 => 180,
			_ => Direction
		};
		currentSpeed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : player.stats.speed;

        rig.position += new Vector2(x, y) * Time.fixedDeltaTime;
        camera.transform.position = new(rig.position.x, rig.position.y, camera.transform.position.z);
        transform.rotation = Quaternion.Euler(0f, Direction, 0f);
	}
	// Start is called before the first frame update
	void Start()
    {
        currentSpeed = player.stats.speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.status == Status.Normal)
        {
			Move();
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Item"))
		{
            var collect = collision.GetComponent<CollectableItem>();
            var itemAdded = player.inventory.AddItem(collect);
            if(itemAdded) Destroy(collision.gameObject);
		}
	}
}
