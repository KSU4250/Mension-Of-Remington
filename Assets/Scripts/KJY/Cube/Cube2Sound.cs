using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class Cube2Sound : MonoBehaviour
{
    public AudioClip DogSound;
    public AudioClip MouseSound;
    public AudioClip RabbitSound;
    public AudioClip MonkeySound;
    public AudioClip AnimalPlay;

    //���� & ���� ȿ����
    public AudioClip success;
    public AudioClip failure; 

    //����
    public string[] Result = { "dog", "monkey", "dog", "mouse", "rabbit" };
    private string[] InputResult = new string[5];


    private GameObject[] Lights = new GameObject[5];
    [SerializeField] private Transform[] LightsPos;
    [SerializeField] private GameObject GreenLight;

   
    private int curNum = 0;
    private int correctNum = 0;

    //�����
    public bool TheCube2Result = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ClickDog();
        }

        if (curNum == 5)
        {
            CheckTheResult();
            curNum = 0;
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        if (hit.transform.gameObject.tag == "AnimalPlayButton")
        //        {
        //            AudioClip AnimalPlaySound = AnimalPlay;
        //            GetComponent<AudioSource>().Stop();
        //            GetComponent<AudioSource>().PlayOneShot(AnimalPlaySound, 0.8f);
        //        }
        //    }
        //}
    }

    // �� �̹��� Ŭ��������
    public void ClickDog()
    {
        Debug.Log("�� Ŭ����");

        // �Һ� �߰�
        AddLight();

        // �迭�� �ش絿�� �߰�
        AddToArr("dog");

        // ���� ���
        AudioClip AnimalSound = DogSound;
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(AnimalSound, 0.8f);

        // ���� num�߰�
        curNum++;
    }

    // �䳢 �̹��� Ŭ��������
    public void ClickRabbit()
    {
        Debug.Log("�䳢 Ŭ����");

        // �Һ� �߰�
        AddLight();

        // �迭�� �ش絿�� �߰�
        AddToArr("rabbit");

        // ���� ���
        AudioClip AnimalSound = RabbitSound;
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(AnimalSound, 0.8f);

        // ���� num�߰�
        curNum++;
    }

    // �÷��� ��ư Ŭ��������
    public void ClickPlay()
    {
        AudioClip AnimalPlaySound = AnimalPlay;
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(AnimalPlaySound, 0.8f);
    }

    // �� Ŭ���� �ݹ�޾�����
    public void CallbackMouse()
    {
        AddLight();
        AddToArr("mouse");

        AudioClip AnimalSound = MouseSound;
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(AnimalSound, 0.8f);

        curNum++;

    }

    // ��Ű Ŭ���� �ݹ� �޾�����
    public void CallbackMonkey()
    {
        AddLight();
        AddToArr("monkey");

        AudioClip AnimalSound = MonkeySound;
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(AnimalSound, 0.8f);

        curNum++;
    }

    // �Է¹��� ���� �迭�� �߰�
    private void AddToArr(string _animal)
    {
        for (int i = 0; i < InputResult.Length; ++i)
        {
            if (InputResult[i] == null)
            {
                //�� ĭ�� ���� �ֱ�
                InputResult[i] = _animal;
                Debug.Log($"{_animal}��(��) �迭�� {i}�� ĭ�� �߰��Ǿ����ϴ�.");
                return;
            }
        }
    }

    // �Һ� ����
    private void AddLight()
    {
        //GameObject greenLightInstance = Instantiate(GreenLight, LightsPos[curNum].position, Quaternion.Euler(0f,90f,0f));

        if (curNum < Lights.Length && Lights[curNum] == null)
        {
            Lights[curNum] = Instantiate(GreenLight, LightsPos[curNum].position, Quaternion.Euler(0f, 90f, 0f), transform);

            //greenLightInstance.transform.SetParent(Lights[curNum].transform);
        }
    }

    // ����� Ȯ��
    private void CheckTheResult()
    {
        for (int i = 0; i < Result.Length; ++i)
        {
            if (Result[i] == InputResult[i])
            {
                correctNum++;
            }
        }

        Debug.Log(correctNum);

        if (correctNum == 5)
        {
            TheCube2Result = true;
            AudioClip SuccessSound = success;
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(SuccessSound, 0.8f);
        }
        else
        {
            AudioClip FailureSound = failure;
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(FailureSound, 0.8f);
            Debug.Log("����");

            Destroy(Lights[0]);
            Destroy(Lights[1]);
            Destroy(Lights[2]);
            Destroy(Lights[3]);
            Destroy(Lights[4]);

            correctNum = 0;
            InputResult = new string[5];
        }
    }



    //private void FinalCheck()
    //{
    //    if (curNum == 5)
    //    {
    //        // ������Ʈ���� ��� ������ �ȵǱ� ������ �ϳ� ����
    //        ++curNum;

    //        //CheckTheResult();
    //        StartCoroutine(CheckTheResultCoroutine());
    //    }
    //}

    //private IEnumerator CheckTheResultCoroutine()
    //{
    //    yield return null;

    //    while (true)
    //    {
    //        if (Input.GetMouseButtonDown(0)) break;
    //        yield return null;
    //    }

    //    CheckTheResult();
    //}


    //private void CheckAnimal()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;

    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            if (hit.transform.gameObject.tag == "Dog")
    //            {
    //                AddLight();
    //                //DogLight.gameObject.SetActive(true);
    //                Debug.Log("Doglight");
    //                AudioClip AnimalSound = DogSound;
    //                GetComponent<AudioSource>().Stop();
    //                GetComponent<AudioSource>().PlayOneShot(AnimalSound, 0.8f);

    //                AddToArr("dog");
    //            }
    //            if (hit.transform.gameObject.tag == "Mouse")
    //            {
    //                AddLight();
    //                //MouseLight.gameObject.SetActive(true);
    //                AudioClip AnimalSound = MouseSound;
    //                GetComponent<AudioSource>().Stop();
    //                GetComponent<AudioSource>().PlayOneShot(AnimalSound, 0.8f);

    //                AddToArr("mouse");
    //            }
    //        }

    //    }
    //   // yield return null;
    //}

    //�����ϴ� �ñ� �����ϱ�

    //private void TheOtherAnimalValue()
    //{
    //    if (Rabbit == 1)
    //    {
    //        //RabbitLight.gameObject.SetActive(true);
    //        AddLight();
    //        AudioClip AnimalSound = RabbitSound;
    //        GetComponent<AudioSource>().Stop();
    //        GetComponent<AudioSource>().PlayOneShot(AnimalSound, 0.8f);

    //        AddToArr("rabbit");
    //    }
    //    if (Monkey == 1)
    //    {
    //        //MonkeyLight.gameObject.SetActive(true);
    //        AddLight();
    //        AudioClip AnimalSound = MonkeySound;
    //        GetComponent<AudioSource>().Stop();
    //        GetComponent<AudioSource>().PlayOneShot(AnimalSound, 0.8f);

    //        AddToArr("monkey");
    //    }
    //}
}
