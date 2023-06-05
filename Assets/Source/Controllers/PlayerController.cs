using Assets.Processors;
using Assets.Source.Controllers;
using Assets.Source.Interfaces;
using Assets.Source.ScriptableObjects;
using UniRx;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Components
    [SerializeField]
    private PlayerConfiguration _playerConfiguration;
    private Rigidbody2D _rigidbody;
    private IMovementProcessor _movementProcessor;
    #endregion

    #region Properties
   
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _movementProcessor = new MovementProcessor(this.transform);
        GetComponent<HealthController>().InitializeComponent(_playerConfiguration);

        //Init Children
        var comps = GetComponentsInChildren<IChildComponent>();
        foreach (var comp in comps)
        {
            comp.InitializeComponent(_playerConfiguration);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var moveVec = ProcessInput();
        var velocity = _movementProcessor.CalculateVelocity(moveVec);

        _rigidbody.AddForce(velocity);
        _rigidbody.velocity *= 0.99f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("WalkingBoarder"))
        {
            _rigidbody.velocity = Vector2.zero; 
        }
    }

    private Vector2 ProcessInput()
    {
        var output = Vector2.zero;
        output.y = Input.GetAxis("Vertical");
        output.x = Input.GetAxis("Horizontal");

      
        return output;
    }
}
