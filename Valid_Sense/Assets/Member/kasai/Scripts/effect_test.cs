using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect_test : MonoBehaviour
{

    ////�G�t�F�N�g�֘A
    //[SerializeField] GameObject briliantEffect;//�u�����A���g�̃G�t�F�N�g
    //[SerializeField] GameObject briliantBack;//�u�����A���g�̔w�i�G�t�F�N�g
    //[SerializeField] GameObject brilianttext;//�u�����A���g�̕����G�t�F�N�g

    //[SerializeField] GameObject greatEffect;//�O���[�g�̃G�t�F�N�g
    //[SerializeField] GameObject greatBack;//�O���[�g�̔w�i�G�t�F�N�g
    //[SerializeField] GameObject greattext;//�O���[�g�̕����G�t�F�N�g

    //[SerializeField] GameObject goodtext;//�O�b�h�̕����G�t�F�N�g

    //[SerializeField] GameObject poortext;//�v�A�[�̕����G�t�F�N�g

    //[SerializeField] private float destroytimer = 5;//�G�t�F�N�g��������܂ł̎���(���u��)

    //public enum NOTES_POSITION
    //{
    //    notespos0,
    //    notespos1,
    //    notespos2,
    //    notespos3,
    //    notespos4,
    //}
    //public enum NOTES_POSITION2
    //{
    //    notespos0,
    //    notespos1,
    //    notespos2,
    //    notespos3,
    //    notespos4,
    //}
    //public enum NOTES_POSITION3
    //{
    //    notespos0,
    //    notespos1,
    //    notespos2,
    //    notespos3,
    //    notespos4,
    //}
    //public enum NOTES_POSITION4
    //{
    //    notespos0,
    //    notespos1,
    //    notespos2,
    //    notespos3,
    //    notespos4,
    //}

    //public NOTES_POSITION pos;
    //public NOTES_POSITION2 pos2;
    //public NOTES_POSITION3 pos3;
    //public NOTES_POSITION4 pos4;

    //private string inputconfig1 = "null";
    //private string inputconfig2 = "null";
    //private string inputconfig3 = "null";
    //private string inputconfig4 = "null";
    
    EffectManager effectmanager= new EffectManager();
    SkillEffectManager skilleffectmanager = new SkillEffectManager();

    // Start is called before the first frame update
    void Start()
    {
        effectmanager =GetComponent<EffectManager>();
        skilleffectmanager = GetComponent<SkillEffectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(effectmanager);
            EffectManager.Instance.Effect(EffectManager.EffectState.Brilliant,1);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Good");
            EffectManager.Instance.Effect(EffectManager.EffectState.Good, 1);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            EffectManager.Instance.Effect(EffectManager.EffectState.Good,1);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Poor");
            EffectManager.Instance.Effect(EffectManager.EffectState.Poor,1);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SkillEffectManager.Instance.Skill(1, true);
        }
    }

    //IEnumerator Briliant()
    //{
            
           
    //        //Debug.Log("Briliant");
    //        //tx.judgetxt = "Briliant";

    //        GameObject effect1 = Instantiate(briliantEffect) as GameObject; //����G�t�F�N�g����
    //        effect1.transform.position = this.transform.position;
    //        GameObject effect2 = Instantiate(briliantBack) as GameObject;   //�G�t�F�N�g�w�i����
    //        effect2.transform.position = this.transform.position;
    //        GameObject effect3 = Instantiate(brilianttext) as GameObject;   //���蕶������
    //        effect3.transform.position = this.transform.position;

    //        //�m�[�c�̔�����ǂ����ɉ��Z����
    //        yield return new WaitForSeconds(destroytimer);
    //    effect1.gameObject.SetActive(false);
    //    effect2.gameObject.SetActive(false);
    //    effect3.gameObject.SetActive(false);
    //    //Destroy(this.gameObject);   //�m�[�c�폜
    //}

    //IEnumerator Great()
    //{
        
    //        GameObject effect1 = Instantiate(greatEffect) as GameObject;
    //        effect1.transform.position = this.transform.position;
    //        GameObject effect2 = Instantiate(greatBack) as GameObject;
    //        effect2.transform.position = this.transform.position;
    //        GameObject effect3 = Instantiate(greattext) as GameObject;
    //        effect3.transform.position = this.transform.position;

    //        yield return new WaitForSeconds(destroytimer);

    //    effect1.gameObject.SetActive(false);
    //    effect2.gameObject.SetActive(false);
    //    effect3.gameObject.SetActive(false);
            
    //        Destroy(effect1.gameObject);
    //        Destroy(effect2.gameObject);
    //        Destroy(effect3.gameObject);
            
        

    //}
    //IEnumerator Good()
    //{
        
    //        GameObject effect1 = Instantiate(greatEffect) as GameObject;
    //        effect1.transform.position = this.transform.position;
    //        GameObject effect2 = Instantiate(greatBack) as GameObject;
    //        effect2.transform.position = this.transform.position;
    //        GameObject effect3 = Instantiate(goodtext) as GameObject;
    //        effect3.transform.position = this.transform.position;

    //        yield return new WaitForSeconds(destroytimer);
    //    effect1.gameObject.SetActive(false);
    //    effect2.gameObject.SetActive(false);
    //    effect3.gameObject.SetActive(false);


    //}
    //IEnumerator Poor()
    //{
        
            
    //        GameObject effect = Instantiate(poortext) as GameObject;
    //        effect.transform.position = this.transform.position;

    //        yield return new WaitForSeconds(destroytimer);
    //    effect.gameObject.SetActive(false);

    //}
}



///
///������
///

//switch(pos)
//{
//    case NOTES_POSITION.notespos0:
//        inputconfig1 = "space";
//        break;
//    case NOTES_POSITION.notespos1:
//        inputconfig1 = "a";
//        break;
//    case NOTES_POSITION.notespos2:
//        inputconfig1 = "s";
//        break;
//    case NOTES_POSITION.notespos3:
//        inputconfig1 = "d";
//        break;
//    case NOTES_POSITION.notespos4:
//        inputconfig1 = "f";
//        break;
//    default:
//        Debug.Log("Error");
//        break;
//}
//switch (pos2)
//{
//    case NOTES_POSITION2.notespos0:
//        inputconfig2 = "space";
//        break;
//    case NOTES_POSITION2.notespos1:
//        inputconfig2 = "a";
//        break;
//    case NOTES_POSITION2.notespos2:
//        inputconfig2 = "s";
//        break;
//    case NOTES_POSITION2.notespos3:
//        inputconfig2 = "d";
//        break;
//    case NOTES_POSITION2.notespos4:
//        inputconfig2 = "f";
//        break;
//    default:
//        Debug.Log("Error");
//        break;
//}
//switch (pos3)
//{
//    case NOTES_POSITION3.notespos0:
//        inputconfig3 = "space";
//        break;
//    case NOTES_POSITION3.notespos1:
//        inputconfig3 = "a";
//        break;
//    case NOTES_POSITION3.notespos2:
//        inputconfig3 = "s";
//        break;
//    case NOTES_POSITION3.notespos3:
//        inputconfig3 = "d";
//        break;
//    case NOTES_POSITION3.notespos4:
//        inputconfig3 = "f";
//        break;
//    default:
//        Debug.Log("Error");
//        break;
//}
//switch (pos4)
//{
//    case NOTES_POSITION4.notespos0:
//        inputconfig4 = "space";
//        break;
//    case NOTES_POSITION4.notespos1:
//        inputconfig4 = "a";
//        break;
//    case NOTES_POSITION4.notespos2:
//        inputconfig4 = "s";
//        break;
//    case NOTES_POSITION4.notespos3:
//        inputconfig4 = "d";
//        break;
//    case NOTES_POSITION4.notespos4:
//        inputconfig4 = "f";
//        break;
//    default:
//        Debug.Log("Error");
//        break;
//}

//if(Input.GetKeyDown(inputconfig1))
//{
//    StartCoroutine(Briliant());
//}
//if(Input.GetKeyDown(inputconfig2))
//{
//    StartCoroutine(Great());
//}
//if(Input.GetKeyDown(inputconfig3))
//{
//    StartCoroutine(Good());
//}
//if(Input.GetKeyDown(inputconfig4))
//{
//    StartCoroutine(Poor());
//}