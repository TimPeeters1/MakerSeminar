using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Valve.VR;

public class GameManager: MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        instance = this;
    }
    #endregion

    [SerializeField] PlayableDirector director;

    Camera cameraObject;

    Vector3 _originalPos;

    public bool lock1, lock2, lock3, doorLock;

    public SteamVR_ActionSet set;
    public SteamVR_Action_Boolean trigger;
    public SteamVR_Action_Boolean trigger1;

    public SteamVR_Input_Sources inputSource;

    public GameObject failScreen;
    public AudioClip failSound;
    public AudioClip winSound;

    private void Start()
    {
        set.Activate(SteamVR_Input_Sources.Any, 0, true);
        cameraObject = Camera.main;
        _originalPos = cameraObject.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || trigger.stateDown || trigger1.stateDown)
        {
            director.Play();
        }
    }

    public void DoShake()
    {
        StartCoroutine(CameraShake(0.4f, 0.2f));
    }

    public IEnumerator CameraShake(float _duration, float _magnitude)
    {

        float _elapsed = 0.0f;

		while (_elapsed < _duration)
		{
			float x = Random.Range(-1f, 1f) * _magnitude;
			float y = Random.Range(-1f, 1f) * _magnitude;

			cameraObject.transform.localPosition = new Vector3(_originalPos.x + x, _originalPos.y + y, _originalPos.z);

			_elapsed += Time.deltaTime;

			yield return null;
		}
        cameraObject.transform.localPosition = _originalPos;
    }
}