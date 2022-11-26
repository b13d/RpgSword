using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// ��� ������, �� ������ ��������� � ������� ������������ ��� ���������� ����!!! ������ PUBLIC > PRIVATE � �.�
/// </summary>

public class SettingsGame : MonoBehaviour
{
    //bool pauseGame;
    public SpawnEnemy spawnEnemy;
    int count = 20000;
    static int waveCount = 0;
    float oneSeconds = 1f, healtsPlayer;
    TextMeshProUGUI textTimer, textWave;
    public UIPlayer uiPlayer;

    void Start()
    {
        textTimer = transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>(); // ������� ������ TimeText
        textWave = transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>(); // ������� ������ WaveText

        textWave.text = "Wave: " + waveCount;
        healtsPlayer = uiPlayer.sliderHealthPlayer.value;

        //Debug.Log("�������� ����� Start");
    }

    private void Update()
    {
        if (ParametrsPlayer.lvlUP == false)
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                Debug.Log("����� ������ ���");
                uiPlayer.ShowInfoPlayer();
            }

            if (Input.GetKeyUp(KeyCode.Tab))
            {
                Debug.Log("������� ������ ���");
                uiPlayer.HideInfoPlayer();

            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
                InitialValues();
            }

            healtsPlayer = uiPlayer.sliderHealthPlayer.value;

            if (healtsPlayer == 0)
                InitialValues();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ParametrsPlayer.lvlUP == false)
        {
            if (count >= 0 && oneSeconds == 1)
            {
                textTimer.text = "" + count;
                count--;
            }

            oneSeconds -= Time.deltaTime;


            if (oneSeconds < 0)
            {
                oneSeconds = 1f;
            }



            if (count < 0)
            {
                textWave.gameObject.SetActive(true);
                waveCount++;
                SceneManager.LoadScene(0);
                textWave.text += "�����: " + waveCount;
                count = 20000;
                // �������� ���� ��� ������� ������, �� ������ ������ ������ ��������
                // ����� � �������� � ��������� ���� +1
            }
        }


    }

    public void InitialValues() // ����� ����� ��� �� ������� ��� ������ ��
    {
        textWave.gameObject.SetActive(true);
        count = 20000;
        waveCount = 0;
        oneSeconds = 1f;
    }
}
