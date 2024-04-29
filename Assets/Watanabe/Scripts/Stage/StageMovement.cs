using UnityEngine;

public class StageMovement : MonoBehaviour
{
    #region Inspector設定変数一覧
    [Tooltip("背景の移動速度")]
    [SerializeField]
    private float _moveSpeed = 1f;

    [SerializeField]
    private GameObject _carnivorousPrefab = default;
    [SerializeField]
    private GameObject[] _flowerPrefab = new GameObject[3];
    [Tooltip("花の生成数")]
    [SerializeField]
    private int _flowerCount = 1;

    [Tooltip("植物の生成間隔（x軸）")]
    [SerializeField]
    private float _flowerDuration = 5f;
    [Range(1, 5)]
    [SerializeField]
    private int _carnivorousCount = 1;
    #endregion

    private Vector3 _position = Vector3.zero;
    private GameObject _spawnPlantPrefab = default;
    private int _spawnCounter = 0;
    private int _carnivorousRatio = 0;

    public int FlowerCount => _flowerCount;

    private void Start()
    {
        _position = transform.position;
        _spawnPlantPrefab = _carnivorousPrefab;
        _carnivorousRatio = _flowerCount / _carnivorousCount;
        FlowerInstance();
    }

    private void Update()
    {
        if (GameManager.instance.IsPause) { return; }

        //背景移動処理
        _position.x -= Time.deltaTime * _moveSpeed;
        transform.position = _position;
    }

    private void FlowerInstance()
    {
        if (!_flowerPrefab[0] || !_carnivorousPrefab) { return; }

        for (int i = 1; i <= _flowerCount + _carnivorousRatio; i++) { SpawnPlant(i); }
    }

    /// <summary> 植物の生成 </summary>
    private void SpawnPlant(int counter)
    {
        int index = Random.Range(0, _flowerPrefab.Length);

        if (_carnivorousCount == _spawnCounter)
        {
            _spawnPlantPrefab = _carnivorousPrefab;
            _spawnCounter = 0;
        }
        else
        {
            _spawnPlantPrefab = _flowerPrefab[index];
            _spawnCounter++;
        }

        var plant = Instantiate(_spawnPlantPrefab);
        plant.transform.SetParent(transform);
        plant.transform.position = new Vector3(counter * _flowerDuration, -2.7f, 0f);
    }
}
