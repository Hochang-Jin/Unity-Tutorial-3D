using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace Farm
{
    public class GameManager : Singleton<GameManager>
    {
        public UIManager ui;
        public FieldManager field;
        public ItemManager item;
        
        public enum CameraState
        {
            OUTSIDE,
            FIELD,
            HOUSE,
            ANIMAL,
            BOARD
        }
        public CameraState _cameraState = CameraState.OUTSIDE;
        
        [SerializeField] private CinemachineClearShot clearShot;

        public void SetCameraState(CameraState newState)
        {
            if (_cameraState != newState)
            {
                _cameraState = newState;

                foreach (var VARIABLE in clearShot.ChildCameras)
                {
                    VARIABLE.Priority = 1;
                }
                clearShot.ChildCameras[(int)_cameraState].Priority = 10;
            }
        }
    }
}
