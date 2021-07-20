using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ThirdPersonInputManager : Singleton<ThirdPersonInputManager>
{
    #region Variables
    private string horizontalInput = "Horizontal";
    private string verticallInput = "Vertical";

    public ThirdPersonController controller;
    public ThirdPersonCamera tpCamera;

    private string characterPath = "Character";
    private GameObject character;
    private GameObject characterPrefab;
    #endregion

    private void StartAsync()
    {
        Addressables.LoadAssetAsync<GameObject>(characterPath).Completed += onCharacterLoadDone;
    }

    private void onCharacterLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        characterPrefab = obj.Result;
        character = Instantiate(characterPrefab);
        character.name = characterPrefab.name;
        InitilizeController();
        InitializeCamera();
    }
    public override void Init()
    {
        StartAsync();
    }
    protected virtual void FixedUpdate()
    {
        if (controller == null)
            return;
        controller.AirControl();
    }

    protected virtual void Update()
    {
        InputHandle();
    }

    protected virtual void InitilizeController()
    {
        character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, -13);
        controller = character.GetComponentInChildren<ThirdPersonController>();
        //if (controller != null)
        //    controller.Init();
    }

    protected virtual void InitializeCamera()
    {
        if (tpCamera == null)
        {
            tpCamera = CameraManager.GetInstance().MainCameraController;
            if (!tpCamera)
            {
                tpCamera = FindObjectOfType<ThirdPersonCamera>();
            }
            if (tpCamera)
            {
                tpCamera.SetMainTarget(character.transform);
                tpCamera.Init();
            }
        }
    }
    protected virtual void InputHandle()
    {
        if (controller == null)
            return;
        MoveInput();
    }

    public virtual void MoveInput()
    {
        controller.input.x = Input.GetAxis(horizontalInput);
        controller.input.z = Input.GetAxis(verticallInput);
    }
}
