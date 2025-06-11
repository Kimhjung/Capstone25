using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public PlayerController PlayerController;
    public PlayerAI PlayerAI;

    public void EnableAI()
    {
        if (PlayerAI != null)
            PlayerAI.enabled = true;

        if (PlayerController != null)
            PlayerController.enabled = false;

        Debug.Log("AI ��� Ȱ��ȭ");
    }
    public void DisableAI()
    {
        if (PlayerAI != null)
            PlayerAI.enabled = false;

        if (PlayerController != null)
            PlayerController.enabled = true;

        Debug.Log("���� ���� ��� Ȱ��ȭ");
    }
}
