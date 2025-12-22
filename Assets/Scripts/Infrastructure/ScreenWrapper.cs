using UnityEngine;
using Zenject;

public class ScreenWrapper : MonoBehaviour
{
    private float _halfWidth;
    private float _halfHeight;
    private Camera _camera;
    private SignalBus _signalBus;
    private Transform _transform;
    
    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
    
    void Start()
    {
        _camera = Camera.main;
        _transform = transform;

        float ortho = _camera.orthographicSize;
        float aspect = _camera.aspect;

        _halfHeight = ortho;
        _halfWidth = ortho * aspect; 
    }
    
    void LateUpdate()
    {
        Vector3 pos = _transform.position;

        if (pos.x > _halfWidth || pos.x < -_halfWidth ||
            pos.y > _halfHeight || pos.y < -_halfHeight)
        {
            _signalBus.Fire(new ExitedScreenBoundsSignal { Target = _transform });
        } 
    }
}
