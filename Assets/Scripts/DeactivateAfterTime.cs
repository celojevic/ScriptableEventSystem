using UnityEngine;

public class DeactivateAfterTime : MonoBehaviour
{

    [SerializeField] private float _delay = 5f;

    private float _initDelay;

    private void OnEnable()
    {
        _initDelay = _delay;   
    }

    private void Update()
    {
        _initDelay -= Time.deltaTime;
        if (_initDelay <= 0f)
            gameObject.SetActive(false);
    }

}
