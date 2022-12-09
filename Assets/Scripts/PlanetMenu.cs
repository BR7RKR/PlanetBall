using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlanetMenu : MonoBehaviour
{
    [SerializeField] private float _angleOfRotation;
    [SerializeField] private MenuUI _menuUI;

    private AudioSource _inputRotationSound;
    
    private void Awake()
    {
        _inputRotationSound = GetComponent<AudioSource>();
        _inputRotationSound.Play(0);
    }

    void Update()
    {
        _inputRotationSound.Pause();
        if (!_menuUI.IsShowingControls)
            RotateConstantly();
        else Rotate();
    }

    private void RotateConstantly()
    {
        transform.Rotate(0, _angleOfRotation, 0);
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, _angleOfRotation, 0);

            _inputRotationSound.UnPause();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, -_angleOfRotation, 0);
            
            _inputRotationSound.UnPause();
        }
        else _inputRotationSound.Pause();
    }
}
