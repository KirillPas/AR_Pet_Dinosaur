using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Random = UnityEngine.Random;

public class SpawnerMulticoloredPrimitives : MonoBehaviour
{
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private InputActionReference tapAction;
    private void OnEnable()
    {
        tapAction.action.Enable();
        tapAction.action.performed += OnTap;
    }
    private void OnDisable()
    {
        tapAction.action.Disable();
        tapAction.action.performed -= OnTap;
    }
    private void OnTap(InputAction.CallbackContext context)
    {
        Vector2 touchPosition;
        // Получение позиции касания из контекста
        if (context.control is Pointer inputPointer)
        {
            touchPosition = inputPointer.position.ReadValue();
        }
        else if (context.control is TouchControl pointerControl)
        {
            touchPosition = pointerControl.position.ReadValue();
        }
        else
        {
            Debug.LogWarning("Действие касания было выполнено, но оно не былосенсорным вводом.");
     
            touchPosition = new Vector2(Screen.width / 2f, Screen.height / 2f);
        }
        var arRaycastHits = new List<ARRaycastHit>();
        // Проверка попадания луча на плоско

        if (!raycastManager.Raycast(touchPosition, arRaycastHits, TrackableType.PlaneWithinPolygon))
        {
            return;
        }
        // Получение позы первого попадания
        var hitPose = arRaycastHits[0].pose;
        // Выбор случайного примитива
        var values = Enum.GetValues(typeof(PrimitiveType));
        var randomPrimitive = (PrimitiveType)values.GetValue(Random.Range(0, values.Length));
        // Создание примитива и настройка его свойств
        var placedObject = GameObject.CreatePrimitive(randomPrimitive);
        placedObject.transform.localScale = Vector3.one * 0.1f;
        placedObject.transform.position = hitPose.position;
        placedObject.transform.rotation = hitPose.rotation;
        placedObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

}
