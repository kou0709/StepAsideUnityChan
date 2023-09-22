using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefab������
    public GameObject carPrefab;

    //coinPrefab������
    public GameObject coinPrefab;
    //cornPrefab������
    public GameObject conePrefab;
    //�X�^�[�g�n�_
    private int startPos = 80;
    //�S�[���n�_
    private int goalPos = 360;
    //�A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;

    private float ARange = 40f;

    //40�`50m��̈ʒu���L�[�v����
    private float speed = 16f;

    private GameObject unitychan;


    Camera cam;

    private float difference;

    private float DeadLine = 0f;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        DeadLine = startPos;

        this.unitychan = GameObject.Find("unitychan");
        

    // Update is called once per frame
    void Update()
    {
         if(goalPos>DeadLine && DeadLine <unitychan.transform.position.z + ARange)
         {

            //�ǂ̃A�C�e�����o���̂��������_���ɐݒ�
            int num = Random.Range(1, 11);
            if ( num <=2)
            {
                //�R�[����x��������꒼���ɐ���
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, DeadLine);

                }
            }
            else
            {
                //���[�����ƂɃA�C�e���𐶐�
                for (int j = -1; j <= 1; j++)
                {
                    //�A�C�e���̎�ނ����߂�
                    int item = Random.Range(1, 11);

                    //�A�C�e����u��Z���W�̃I�t�Z�b�g�������_���ɐݒ�
                    int offsetZ = Random.Range(-5, 6);

                    //60���R�C���z�u:30���Ԕz�u:10�������Ȃ�
                    if(1 <= item && item <= 6)
                    {
                        //�R�C���𐶐�
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, DeadLine + offsetZ);

                    }
                    else if(7 <= item && item <= 9)
                    {
                        //�Ԃ𐶐�
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, DeadLine + offsetZ);
                    }
                }
            }
                DeadLine += 15;
         }
    }
        if (this.gameObject.tag == "CarTag"||this.gameObject.tag =="TrafficConeTag"|| this.gameObject.tag == "CoinTag")
        {
            if ( cam.transform.position.z > this.transform.position.z)
            {
                Destroy(this.gameObject);
            }
        }

    }
}
