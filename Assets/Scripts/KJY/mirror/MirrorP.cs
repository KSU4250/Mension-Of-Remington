using UnityEngine;

public class MirrorP : MonoBehaviour
{

    //��ġ�� �ν��ؼ� �´� ��ġ�� ��ġ���� �� �ٸ� ���� ����� �ǰ� �� �ȿ� ��ư �ְ� 
    //���� ������ �������� ó�� 
    //��ġ�� �� 1�� 2���� �ð� ������ ��� �� 
    //��ġ �ν� - ��Ī�ϴ� ��  - Ÿ�� & Trigger   
    //�´� ��ġ�� �θ� mirror & backPan ��Ȱ��ȭ �ȴ�.

    public delegate void MirroDelegate();
    public MirroDelegate mirroSucessCallback;


    [SerializeField] private GameObject Mirror;
    [SerializeField] private GameObject MirrorBackpan;
    [SerializeField] private GameObject Wall;

    [SerializeField] private MirrorButtonController mirrorbutton;
    [SerializeField] private MirroInsideButtonController mirrorinsidebutton;

    public bool TheResult = false;

    private void Update()
    {
        if (mirrorbutton.TheButtonisPressed == true && mirrorinsidebutton.TheButtonisPressed == true && !TheResult)
        {
            Debug.Log("���� ������");
            TheResult = true;
            mirroSucessCallback?.Invoke();
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "TheMirrorPlace")
        {
            //Debug.Log("�۵�");

            Mirror.SetActive(false);
            MirrorBackpan.SetActive(false);
            Wall.SetActive(false);

            //Invoke("Mirror.SetActive(false)", 1f);
            //Invoke("Mirrorbackpan.SetActive(false)", 1f);
            //Invoke("Wall.SetActive(false)", 1f);

        }
    }


}
