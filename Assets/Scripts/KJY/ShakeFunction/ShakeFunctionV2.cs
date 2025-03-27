using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ShakeFunctionV2 : MonoBehaviour
{
    // ��鸱 3D ������Ʈ
    public Transform objectToShake;

    [SerializeField] private XRGrabInteractable grab;

    // ������ ������Ʈ ������
    public GameObject Beer;
    public GameObject Shape;
    public GameObject Mouse;
    public GameObject Pig;
    public GameObject Monkey;
    public GameObject Penguin;
    public GameObject Rabbit;


    // ��鸲 ���� �Ӱ谪
    public float shakeThreshold = 1.5f;

    // ��� ����ȭ �ð� ��� ����
    public float syncThreshold = 0.2f;

    // ������ ��ġ �׼�
    public InputActionProperty rightHandPositionAction;
    // �޼� ��ġ �׼�
    public InputActionProperty leftHandPositionAction;

    // �������� ���� ��ġ
    private Vector3 lastRightPosition;
    // �޼��� ���� ��ġ
    private Vector3 lastLeftPosition;


    private Vector3 lastRightVeclocity;
    private Vector3 lastLeftVeclocity;

    private Vector3 LeftAccelaretion;
    private Vector3 RightAccelaretion;

    private float shakeTimer = 0f;

    private float TheTime = 0f;
    private float timeLimit = 3f;


    void Start()
    {
        lastRightPosition = Vector3.zero;
        lastLeftPosition = Vector3.zero;
    }

    void Update()
    {


        if (grab.isSelected)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);


            // ��ġ ������ ��������
            Vector3 rightPosition = rightHandPositionAction.action.ReadValue<Vector3>();
            Vector3 leftPosition = leftHandPositionAction.action.ReadValue<Vector3>();

            // �ӵ� ���
            Vector3 rightVelocity = (rightPosition - lastRightPosition) / Time.deltaTime;
            Vector3 leftVelocity = (leftPosition - lastLeftPosition) / Time.deltaTime;

            LeftAccelaretion = (leftVelocity - lastLeftVeclocity) / Time.deltaTime;
            RightAccelaretion = (rightVelocity - lastRightVeclocity) / Time.deltaTime;

            if(LeftAccelaretion.magnitude >= shakeThreshold && RightAccelaretion.magnitude >= shakeThreshold)
            {
                TheTime += Time.deltaTime;

                float TimeDifference = Mathf.Abs(LeftAccelaretion.magnitude - RightAccelaretion.magnitude);

                if(TheTime >= timeLimit)
                {
                    if(TimeDifference <= syncThreshold)
                    {
                        //��鸲
                        shakeTimer = TheTime;
                        SetActive();
                        
                    }
                }
            }

            TheTime = 0;

            //���� ��ġ ������Ʈ
            lastRightPosition = rightPosition;
            lastLeftPosition = leftPosition;

            //���� �ӵ� ������Ʈ
            lastRightVeclocity = rightVelocity;
            lastLeftVeclocity = leftVelocity;

            if (shakeTimer > 0)
            {
                ShakeObject();
                shakeTimer -= Time.deltaTime;
            }


        }
        else
        {
            TheTime = 0f;
        }

    }


    void ShakeObject()
    {
        if (objectToShake != null)
        {
            // ��鸲 ũ��
            float shakeAmount = Mathf.Sin(Time.time * 20) * 0.1f;
            objectToShake.localPosition = new Vector3(shakeAmount, 0, 0);
        }
    }

    void SetActive()
    {

        Beer.SetActive(true);
        Shape.SetActive(true);
        Mouse.SetActive(true);
        Pig.SetActive(true);
        Monkey.SetActive(true);
        Penguin.SetActive(true);
        Rabbit.SetActive(true);

    }




}
