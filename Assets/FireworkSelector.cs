using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class FireworkSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] fireworkContainers;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private RectTransform buttonParent;

    [SerializeField] private Color deactivatedColor;
    [SerializeField] private Color activatedColor;
    
    private Image[] buttonImages;

    private int currentIndex;

    private void Start()
    {
        currentIndex = -1;

        buttonImages = new Image[fireworkContainers.Length];
        for (int i = 0; i < fireworkContainers.Length; i++)
        {
            var button = Instantiate(buttonPrefab, buttonParent);
            var i1 = i;
            button.GetComponent<Button>().onClick.AddListener(() => SwitchButton(i1));
            buttonImages[i] = button.GetComponent<Image>();
        }
    }

    void Update()
    {
        for (int i = 0; i < fireworkContainers.Length; i++)
        {
            if (!Input.GetKeyDown(i + "")) continue;
            
            Debug.Log($"Key pressed for firework {i}");
            SwitchButton(i);
            return;
        }
    }

    void SwitchButton(int index)
    {
        Debug.Log($"SwitchButton called with index: {index}");

        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
        {
            SetToIndex(index);
        }
        else
        {

            if (fireworkContainers[index].activeSelf)
            {
                DisableButton(index);
            }
            else
            {
                EnableButton(index);
            }
        }
    }

    private void DisableButton(int index)
    {
        Debug.Log($"Disabling button at index {index}");
        
        fireworkContainers[index].SetActive(false);
        buttonImages[index].color = deactivatedColor;
    }

    void EnableButton(int index)
    {
        Debug.Log($"Enabling button at index {index}");

        fireworkContainers[index].SetActive(true);
        buttonImages[index].color = activatedColor;
    }

    public void SetToIndex(int index)
    {
        if (index >= fireworkContainers.Length)
        {
            Debug.LogError($"Index {index} is out of range for fireworkContainers");
        }

        if (index == currentIndex)
        {
            Debug.Log($"Index {index} is already the current index");
            return;
        }

        for (var i = 0; i < fireworkContainers.Length; i++)
        {
            fireworkContainers[i].SetActive(false);
            buttonImages[i].color = deactivatedColor;
        }

        if (index >= 0)
        {
            fireworkContainers[index].SetActive(true);
            buttonImages[index].color = activatedColor;
        }
    }
}
