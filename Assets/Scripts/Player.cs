using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(LineRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private AudioClip _rotationSound;
    [SerializeField] private AudioClip _pushSound;
    [SerializeField] private float _velocity;
    [SerializeField] private float _deathBorderX;
    [SerializeField] private float _deathBorderZ;
    [SerializeField] private float _angleOfRotation = 1f;
    [SerializeField] private Material _rayMaterial;
    
    private AudioSource _audioSource;
    private LineRenderer _line;
    private Rigidbody _rb;
    private int _inputScale;
    private int _scorePoints;
    private bool _isLost;
    
    public bool IsDead { get; private set; }

    public Rigidbody Rb
    {
        get => _rb;
    }

    void Start()
    {
        Time.timeScale = 1;
        
        _rb = GetComponent<Rigidbody>();
        _line = GetComponent<LineRenderer>();
        _audioSource = GetComponent<AudioSource>();
        
        _audioSource.clip = _rotationSound;
        _audioSource.Play(0);
        _audioSource.Pause();
    }

    private void FixedUpdate()
    {
        Force();
        Rotate();
        DrawLine();
        Death();
    }

    private void Force()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isLost)
        {
            _audioSource.PlayOneShot(_pushSound);
            _rb.velocity = transform.right * _velocity;
            _isLost = true;
        }
    }
    
    private void Rotate()
    {
        if (!_isLost)
        {
            if (Input.GetKey(KeyCode.A))
                transform.Rotate(0, -_angleOfRotation, 0);
            if (Input.GetKey(KeyCode.D))
                transform.Rotate(0, _angleOfRotation, 0);
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                _audioSource.loop = true;
                _audioSource.UnPause();
            }
            else
            {
                _audioSource.Pause();
                _audioSource.loop = false;
            }
        }
    }

    private void Death()
    {
        if (!IsInBorders(transform.position.x, _deathBorderX) || !IsInBorders(transform.position.z, _deathBorderZ))
            IsDead = true;
    }

    private bool IsInBorders(float currentPositionXorYorZ, float border)
    {
        return currentPositionXorYorZ < border && currentPositionXorYorZ > -border;
    }

    private void DrawLine()
    {
        _line = SetUpLine(_line, Color.red);
    }

    private LineRenderer SetUpLine(LineRenderer line, Color color, float startWidth = 0.1f, float endWidth = 0.1f)
    {
        line.startWidth = startWidth;
        line.endWidth = endWidth;
        line.material = _rayMaterial;
        line.startColor = color;
        line.endColor = color;
        
        UpdateLine();
        
        return line;
    }

    private void UpdateLine()
    {
        var ray = new Ray(transform.position, transform.right);
        
        _line.SetPosition(0, transform.position);
        _line.SetPosition(1, ray.GetPoint(2));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
            _audioSource.PlayOneShot(_hitSound);
    }
}
