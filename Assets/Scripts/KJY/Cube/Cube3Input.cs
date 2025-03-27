using TMPro;
using UnityEngine;

public class Cube3Input : MonoBehaviour
{

    public TMP_Text text2;  // TMP_Text ������Ʈ�� ����

    private int currentValue = 0; // ������ ��Ʈ�� (�ʱⰪ 0000)

    public bool TheCube3Result = false;

    private void Start()
    {
        text2.text = "0000";
    }

    private void Update()
    {
        // �� Ű �Է¿� ���� �ش� �ڸ����� ����
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IncrementValue(1000);  // Q Ű�� ù ��° �ڸ� ����
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            IncrementValue(0100);  // W Ű�� �� ��° �ڸ� ����
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            IncrementValue(0010);  // E Ű�� �� ��° �ڸ� ����
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            IncrementValue(0001);  // R Ű�� �� ��° �ڸ� ����
        }
    }

    // ������ �ڸ��� �ش��ϴ� ���� ������Ű�� �Լ�
    private void IncrementValue(int positionValue)
    {
        // �� �ڸ��� ���������� ������Ű�� ���� �� �ڸ��� ���ڸ� ����
        int thousands = (currentValue / 1000) % 10; // ù ��° �ڸ� (1000 �ڸ�)
        int hundreds = (currentValue / 100) % 10;   // �� ��° �ڸ� (100 �ڸ�)
        int tens = (currentValue / 10) % 10;        // �� ��° �ڸ� (10 �ڸ�)
        int ones = currentValue % 10;               // �� ��° �ڸ� (1 �ڸ�)

        // positionValue�� ���� �ش� �ڸ� ���� ������Ŵ
        if (positionValue == 1000)
        {
            thousands = (thousands + 1) % 10; // ù ��° �ڸ� ����
        }
        else if (positionValue == 0100)
        {
            hundreds = (hundreds + 1) % 10;  // �� ��° �ڸ� ����
        }
        else if (positionValue == 0010)
        {
            tens = (tens + 1) % 10;          // �� ��° �ڸ� ����
        }
        else if (positionValue == 0001)
        {
            ones = (ones + 1) % 10;          // �� ��° �ڸ� ����
        }

        // ���ο� ���� ���ļ� currentValue�� ����
        currentValue = thousands * 1000 + hundreds * 100 + tens * 10 + ones;

        // �ؽ�Ʈ�� 4�ڸ� ���ڷ� ǥ�� (��: 0000, 1000, 0100)
        text2.text = currentValue.ToString("D4");
    }

}
