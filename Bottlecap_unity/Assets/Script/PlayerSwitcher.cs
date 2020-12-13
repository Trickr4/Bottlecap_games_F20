using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject waterPrefab;
    public GameObject firePrefab;
    public GameObject naturePrefab;
    
    private GameObject _currentGameObject;
    private Player _currentPlayer;
    private Animator _animator;
    
    void Start()
    {
        _currentGameObject = GameObject.FindWithTag("Player");
        _currentPlayer = _currentGameObject.GetComponent<Player>();
        _animator = _currentGameObject.transform.Find("Parts").GetComponent<Animator>();

    }

    void Update()
    {
        // Water
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchPlayer(Enums.ELEMENT_TYPES.Water);
        }
        // Fire
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchPlayer(Enums.ELEMENT_TYPES.Fire);
        }
        // Nature
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchPlayer(Enums.ELEMENT_TYPES.Nature);
        }
    }

    void SwitchPlayer(Enums.ELEMENT_TYPES keyElement)
    {
        if (_currentPlayer.characterElement != keyElement)
        {
            _animator.Play("EnterTransform", 0, 0f);

            Vector3 oldObjectVector3 = _currentGameObject.transform.position;
            Quaternion oldObjectQuaternion = _currentGameObject.transform.rotation;
            Destroy(_currentGameObject);

            _currentGameObject = Instantiate(SelectPrefab(keyElement), oldObjectVector3, oldObjectQuaternion);
            _currentPlayer = _currentGameObject.GetComponent<Player>();
            _animator = _currentGameObject.transform.Find("Parts").GetComponent<Animator>();
            _animator.Play("ExitTransform", 0, 0f);

            
            // Have the camera follow the new object.
            GameObject cmGameObject = GameObject.FindWithTag("CMCamera");
            CinemachineVirtualCamera cinemachineVirtualCamera = cmGameObject.GetComponent<CinemachineVirtualCamera>();
            cinemachineVirtualCamera.Follow = _currentGameObject.transform;
            cinemachineVirtualCamera.LookAt = _currentGameObject.transform;
        }
    }

    private GameObject SelectPrefab(Enums.ELEMENT_TYPES keyElement)
    {
        if (keyElement == Enums.ELEMENT_TYPES.Fire)
        {
            return firePrefab;
        }
        if (keyElement == Enums.ELEMENT_TYPES.Water)
        {
            return waterPrefab;
        }
        if (keyElement == Enums.ELEMENT_TYPES.Nature)
        {
            return naturePrefab;
        }

        return null;
    }
}
