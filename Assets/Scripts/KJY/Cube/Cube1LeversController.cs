using System.Collections;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Cube1LeversController : MonoBehaviour
{

    //public Transform leverBase; // ������ ������
    //[SerializeField] private float maxAngle = 80f; 
    //[SerializeField] private float minAngle = -80f; 

    // ���� angle���� �־��ָ� �ɵ�
    public float AngleX = 0f;
    public float AngleZ = 0f;


    // ���̽�ƽ�� ȸ������ ������.
    public Transform joystick;

    private void Update()
    {
        AngleX = joystick.localRotation.eulerAngles.x;
        AngleZ = joystick.localRotation.eulerAngles.z;
    }




    //void Update()
    //{
    //    StartCoroutine(LeverControl());
    //}

    //public void OriginRotation()
    //{
    //    transform.localRotation = Quaternion.Euler(0f,0f,0f);
    //}

    //public IEnumerator LeverControl()
    //{
    //    if (Input.GetMouseButton(0)) 
    //    {
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        if (Physics.Raycast(ray, out RaycastHit hit))
    //        {
    //            if (hit.transform == transform) // ���� Ŭ�� ���� Ȯ��
    //            {
    //                // ���콺 �������� ȸ�� ���
    //                Vector3 mousePosition = Input.mousePosition;
    //                Vector3 leverPosition = Camera.main.WorldToScreenPoint(transform.position);
    //                Vector3 direction = (mousePosition - leverPosition).normalized;

    //                // X, Y �� ȸ�� ���
    //                float angleX = Mathf.Clamp(direction.y * maxAngle, minAngle, maxAngle);
    //                float angleY = Mathf.Clamp(-direction.x * maxAngle, minAngle, maxAngle);

    //                AngleX = angleX;
    //                AngleY = angleY;

    //                // Z ���� ����, X, Y �� ȸ�� ����
    //                transform.localRotation = Quaternion.Euler(angleX, angleY, 0);

    //            }
    //        }
    //    }

    //    yield return null;
    //}




}
