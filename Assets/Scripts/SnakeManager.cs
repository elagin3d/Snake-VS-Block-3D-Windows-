using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class SnakeManager : MonoBehaviour
{
    public GameObject BodySnakePref;
    public float SpeedSnake;
    [SerializeField]
    private float _sensitivity;
    public TMP_Text TextLife;
    private int _snakeLife;
    //
    public List<GameObject> _bodySnake = new List<GameObject>();
    [SerializeField]
    private List<Vector3> _positionsBody = new List<Vector3>();
    // 
    public ParticleSystem DestroyBody;
    public Transform Target;
    //
    private Rigidbody _rb;
    private float _inputPositionX;
    //
    public static UnityEvent GameOver = new UnityEvent();
    public static UnityEvent RemoveBodyEvent = new UnityEvent();
    //
    [SerializeField] private SaveLoadSystem _saveLoadSystem;

    private void Awake()
    {
        _bodySnake[0].GetComponent<Rigidbody>().isKinematic = false;
    }
    void Start()
    {
        Finish.FinishEvent.AddListener(SetScoreSnake);
        //
        _sensitivity = _saveLoadSystem.GetSensitivityValue();
        //
        _rb = _bodySnake[0].GetComponent<Rigidbody>();
        _positionsBody.Add(_bodySnake[0].transform.position);
        _snakeLife = _bodySnake.Count;
        TextLife.text = _snakeLife.ToString();
        AddBody(_saveLoadSystem.GetScoreSnake() - 1);
    }
    private void FixedUpdate()
    {
        //Движение вперёд, управление влево и вправо
        if (Input.GetMouseButton(0))
        {
            _inputPositionX = Input.GetAxis("Mouse X") * _sensitivity;
            _rb.velocity = new Vector3(_inputPositionX, 0, SpeedSnake);
        }
        else
        {
            _rb.velocity = new Vector3(0, 0, SpeedSnake);
        }  
    }
    void Update()
    {
        // Перемещение хвоста змеи
        float _distance = (_bodySnake[0].transform.position - _positionsBody[0]).magnitude;
        if (_distance > 1)
        {
            Vector3 _direction = (_bodySnake[0].transform.position - _positionsBody[0]).normalized;
            _positionsBody.Insert(0, _positionsBody[0] + _direction);
            _positionsBody.RemoveAt(_positionsBody.Count - 1);
        }

        for (int i = 0; i < _bodySnake.Count; i++)
        {
            if (i == 0) continue;
            _bodySnake[i].transform.position = Vector3.Lerp(_positionsBody[i], _positionsBody[i - 1], _distance);
        }
        Target.position = _bodySnake[0].transform.position;
    }
    public void AddBody(int a)
    {
        for (int i = 0; i < a; i++)
        {
            Vector3 _positionNewBody = _positionsBody[_positionsBody.Count - 1];
            GameObject _newBody = Instantiate(BodySnakePref, _positionNewBody, Quaternion.identity, transform);
            _bodySnake.Add(_newBody);
            _positionsBody.Add(_newBody.transform.position);
            _snakeLife++;
            TextLife.text = _snakeLife.ToString();
        }
    }
    public void RemoveBody()
    {
        if( _bodySnake.Count > 1)
        {
            Destroy(_bodySnake[0]);
            _bodySnake.RemoveAt(0);
            _positionsBody.RemoveAt(0);
            _rb = _bodySnake[0].GetComponent<Rigidbody>();
            _bodySnake[0].GetComponent<Rigidbody>().isKinematic = false;
            RemoveBodyEvent?.Invoke();
        }
        else
        {
           _bodySnake[0].GetComponent<Renderer>().enabled = false;
            GameOver?.Invoke();
        }
        _snakeLife--;
        TextLife.text = _snakeLife.ToString();
        DestroyBody.Play();
    }

    public void SetSensitivityValue(float sens) // Вызов через слайдер 
    {
        _sensitivity = sens * 50;
        _saveLoadSystem.SaveSensitivityValue(_sensitivity);
    }

    private void SetScoreSnake()
    {
        _saveLoadSystem.SaveScoreSnake(_snakeLife);
    }
}
