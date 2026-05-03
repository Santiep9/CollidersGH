using UnityEngine;
using UnityEngine.InputSystem;

public class LanzarBola : MonoBehaviour
{
    public float fuerza = 500f;
    public float velocidadRotacion = 100f;

    private Rigidbody rb;
    private Vector3 posicionInicial;

    private InputActions inputActions;
    private Vector2 movimiento;

    private ResetearBolos[] bolos;

    void Awake()
    {
        inputActions = new InputActions();
    }

    void OnEnable()
    {
        inputActions.Enable();

        inputActions.Player.Jump.performed += OnLaunch;
        inputActions.Player.Move.performed += ctx => movimiento = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => movimiento = Vector2.zero;
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
        bolos = FindObjectsOfType<ResetearBolos>();
    }

    void Update()
    {
        transform.Rotate(Vector3.up * movimiento.x * velocidadRotacion * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            Reiniciar();
        }
    }

    void OnLaunch(InputAction.CallbackContext context)
    {
        Lanzar();
    }

    void Lanzar()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(transform.forward * fuerza);
    }

    void Reiniciar()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = posicionInicial;
        transform.rotation = Quaternion.identity;

        foreach (ResetearBolos bolo in bolos)
        {
            bolo.Reiniciar();
        }
    }
}
