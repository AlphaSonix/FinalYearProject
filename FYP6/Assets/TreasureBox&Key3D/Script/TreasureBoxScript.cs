using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample {
public class TreasureBoxScript : MonoBehaviour
{
    // Mouse Click
    private Camera _CameraObject;
    private RaycastHit _Hit;
    private bool _Have_Key_Black = false;
    private bool _Have_Key_Silver = false;
    private bool _Have_Key_Gold = false;
    private bool _Have_Key_Black2 = false;
    private bool _Have_Key_Silver2 = false;
    private bool _Have_Key_Gold2 = false;

    private bool _Open_Treasure_Wood = false;
    private bool _Open_Treasure_Silver = false;
    private bool _Open_Treasure_Gold = false;
    private bool _Open_Treasure_Wood2 = false;
    private bool _Open_Treasure_Silver2 = false;
    private bool _Open_Treasure_Gold2 = false;
    
    private Animator _Treasure_Wood_Anim;
    private Animator _Treasure_Silver_Anim;
    private Animator _Treasure_Gold_Anim;
    private Animator _Treasure_Wood_Anim2;
    private Animator _Treasure_Silver_Anim2;
    private Animator _Treasure_Gold_Anim2;
    
    private Animator _Key_Black_Anim;
    private Animator _Key_Silver_Anim;
    private Animator _Key_Gold_Anim;
    private Animator _Key_Black_Anim2;
    private Animator _Key_Silver_Anim2;
    private Animator _Key_Gold_Anim2;
    
    private GameObject _Treasure_Wood;
    private GameObject _Treasure_Silver;
    private GameObject _Treasure_Gold;
    private GameObject _Treasure_Wood2;
    private GameObject _Treasure_Silver2;
    private GameObject _Treasure_Gold2;
    
    private GameObject _Key_Black;
    private GameObject _Key_Silver;
    private GameObject _Key_Gold;
    private GameObject _Key_Black2;
    private GameObject _Key_Silver2;
    private GameObject _Key_Gold2;
    
    private GameObject _Effect;
    private GameObject[] _Effect_obj = new GameObject[6];
    
    void Start()
    {
        LOAD();
    }

    void Update()
    {
        MOUSE_DOWN();
    }
    private void LOAD()
    {
        // Camera
        _CameraObject = GameObject.Find("Main Camera").GetComponent<Camera>();

        _Treasure_Wood = Instantiate(Resources.Load<GameObject>("Prefab/box_Wood"));
        _Treasure_Wood.transform.position = new Vector3(-0.5f, 0, 0);
        _Treasure_Silver = Instantiate(Resources.Load<GameObject>("Prefab/box_Silver"));
        _Treasure_Silver.transform.position = new Vector3(-1.5f, 0, 0);
        _Treasure_Gold = Instantiate(Resources.Load<GameObject>("Prefab/box_Gold"));
        _Treasure_Gold.transform.position = new Vector3(-2.5f, 0, 0);
        _Treasure_Wood2 = Instantiate(Resources.Load<GameObject>("Prefab/box_Wood_Round"));
        _Treasure_Wood2.transform.position = new Vector3(0.5f, 0, 0);
        _Treasure_Silver2 = Instantiate(Resources.Load<GameObject>("Prefab/box_Silver_Round"));
        _Treasure_Silver2.transform.position = new Vector3(1.5f, 0, 0);
        _Treasure_Gold2 = Instantiate(Resources.Load<GameObject>("Prefab/box_Gold_Round"));
        _Treasure_Gold2.transform.position = new Vector3(2.5f, 0, 0);

        _Treasure_Wood.gameObject.SetActive(false);
        _Treasure_Silver.gameObject.SetActive(false);
        _Treasure_Gold.gameObject.SetActive(false);
        _Treasure_Wood2.gameObject.SetActive(false);
        _Treasure_Silver2.gameObject.SetActive(false);
        _Treasure_Gold2.gameObject.SetActive(false);

        _Key_Black = Instantiate(Resources.Load<GameObject>("Prefab/Key_Square1"));
        _Key_Black.transform.position = new Vector3(-0.5f, 0, 1);
        _Key_Silver = Instantiate(Resources.Load<GameObject>("Prefab/Key_Diamond1"));
        _Key_Silver.transform.position = new Vector3(-1, 0, 1);
        _Key_Gold = Instantiate(Resources.Load<GameObject>("Prefab/Key_Hexagon1"));
        _Key_Gold.transform.position = new Vector3(-1.5f, 0, 1);
        _Key_Black2 = Instantiate(Resources.Load<GameObject>("Prefab/Key_Round1"));
        _Key_Black2.transform.position = new Vector3(0.5f, 0, 1);
        _Key_Silver2 = Instantiate(Resources.Load<GameObject>("Prefab/Key_Star1"));
        _Key_Silver2.transform.position = new Vector3(1, 0, 1);
        _Key_Gold2 = Instantiate(Resources.Load<GameObject>("Prefab/Key_Heart1"));
        _Key_Gold2.transform.position = new Vector3(1.5f, 0, 1);

        _Treasure_Wood.name = "Box_Wood";
        _Treasure_Silver.name = "Box_Silver";
        _Treasure_Gold.name = "Box_Gold";
        _Key_Black.name = "Key_Black";
        _Key_Silver.name = "Key_Silver";
        _Key_Gold.name = "Key_Gold";
        _Treasure_Wood2.name = "Box_Wood_Round";
        _Treasure_Silver2.name = "Box_Silver_Round";
        _Treasure_Gold2.name = "Box_Gold_Round";
        _Key_Black2.name = "Key_Black2";
        _Key_Silver2.name = "Key_Silver2";
        _Key_Gold2.name = "Key_Gold2";

        _Treasure_Wood_Anim = _Treasure_Wood.GetComponent<Animator>();
        _Treasure_Silver_Anim = _Treasure_Silver.GetComponent<Animator>();
        _Treasure_Gold_Anim = _Treasure_Gold.GetComponent<Animator>();
        _Key_Black_Anim = _Key_Black.GetComponent<Animator>();
        _Key_Silver_Anim = _Key_Silver.GetComponent<Animator>();
        _Key_Gold_Anim = _Key_Gold.GetComponent<Animator>();
        _Treasure_Wood_Anim2 = _Treasure_Wood2.GetComponent<Animator>();
        _Treasure_Silver_Anim2 = _Treasure_Silver2.GetComponent<Animator>();
        _Treasure_Gold_Anim2 = _Treasure_Gold2.GetComponent<Animator>();
        _Key_Black_Anim2 = _Key_Black2.GetComponent<Animator>();
        _Key_Silver_Anim2 = _Key_Silver2.GetComponent<Animator>();
        _Key_Gold_Anim2 = _Key_Gold2.GetComponent<Animator>();

        _Effect = Resources.Load<GameObject>("Prefab/Effect");
    }

    private void MOUSE_DOWN()
    {
        if (Input.GetMouseButtonDown(0))
        {
            try{
                GameObject clicked_obj = null;
                Ray ray = _CameraObject.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out _Hit))
                {
                    clicked_obj = _Hit.collider.gameObject;
                }
                // Wood
                if(clicked_obj.name == "Key_Black")
                {
                    if(!_Have_Key_Black)
                    {
                        _Treasure_Wood.gameObject.SetActive(true);
                        _Treasure_Wood_Anim.Play("drop");
                        _Key_Black_Anim.Play("get");
                        StartCoroutine(Get_Key(_Key_Black_Anim, _Key_Black));
                    }
                }
                else if(clicked_obj.name == "Box_Wood" && _Have_Key_Black && !_Open_Treasure_Wood)
                {
                    _Open_Treasure_Wood = true;
                    _Have_Key_Black = false;
                    _Key_Black.gameObject.SetActive(true);
                    _Key_Black.transform.position = _Treasure_Wood.transform.position + new Vector3(0, 0.385f, 0.325f);
                    _Key_Black_Anim.Play("unlock");
                    StartCoroutine(Unlock(_Treasure_Wood_Anim, _Key_Black_Anim, _Key_Black, _Treasure_Wood));
                }
                else if(clicked_obj.name == "Box_Wood" && _Open_Treasure_Wood)
                {
                    _Open_Treasure_Wood = false;
                    _Treasure_Wood_Anim.CrossFade("close1", 0.1f, 0, 0.0f);
                    StartCoroutine(Close(_Treasure_Wood_Anim, _Key_Black_Anim, _Key_Black));
                }
                // Silver
                if(clicked_obj.name == "Key_Silver")
                {
                    if(!_Have_Key_Silver)
                    {
                        _Treasure_Silver.gameObject.SetActive(true);
                        _Treasure_Silver_Anim.Play("drop");
                        _Key_Silver_Anim.Play("get");
                        StartCoroutine(Get_Key(_Key_Silver_Anim, _Key_Silver));
                    }
                }
                else if(clicked_obj.name == "Box_Silver" && _Have_Key_Silver && !_Open_Treasure_Silver)
                {
                    _Open_Treasure_Silver = true;
                    _Have_Key_Silver = false;
                    _Key_Silver.gameObject.SetActive(true);
                    _Key_Silver.transform.position = _Treasure_Silver.transform.position + new Vector3(0, 0.385f, 0.325f);
                    _Key_Silver_Anim.Play("unlock");
                    StartCoroutine(Unlock(_Treasure_Silver_Anim, _Key_Silver_Anim, _Key_Silver, _Treasure_Silver));
                }
                else if(clicked_obj.name == "Box_Silver" && _Open_Treasure_Silver)
                {
                    _Open_Treasure_Silver = false;
                    _Treasure_Silver_Anim.CrossFade("close1", 0.1f, 0, 0.0f);
                    StartCoroutine(Close(_Treasure_Silver_Anim, _Key_Silver_Anim, _Key_Silver));
                }
                // Gold
                if(clicked_obj.name == "Key_Gold")
                {
                    if(!_Have_Key_Gold)
                    {
                        _Treasure_Gold.gameObject.SetActive(true);
                        _Treasure_Gold_Anim.Play("drop");
                        _Key_Gold_Anim.Play("get");
                        StartCoroutine(Get_Key(_Key_Gold_Anim, _Key_Gold));
                    }
                }
                else if(clicked_obj.name == "Box_Gold" && _Have_Key_Gold && !_Open_Treasure_Gold)
                {
                    _Open_Treasure_Gold = true;
                    _Have_Key_Gold = false;
                    _Key_Gold.gameObject.SetActive(true);
                    _Key_Gold.transform.position = _Treasure_Gold.transform.position + new Vector3(0, 0.385f, 0.325f);
                    _Key_Gold_Anim.Play("unlock");
                    StartCoroutine(Unlock(_Treasure_Gold_Anim, _Key_Gold_Anim, _Key_Gold, _Treasure_Gold));
                }
                else if(clicked_obj.name == "Box_Gold" && _Open_Treasure_Gold)
                {
                    _Open_Treasure_Gold = false;
                    _Treasure_Gold_Anim.CrossFade("close1", 0.1f, 0, 0.0f);
                    StartCoroutine(Close(_Treasure_Gold_Anim, _Key_Gold_Anim, _Key_Gold));
                }
                // Wood2
                if(clicked_obj.name == "Key_Black2")
                {
                    if(!_Have_Key_Black2)
                    {
                        _Treasure_Wood2.gameObject.SetActive(true);
                        _Treasure_Wood_Anim2.Play("drop");
                        _Key_Black_Anim2.Play("get");
                        StartCoroutine(Get_Key(_Key_Black_Anim2, _Key_Black2));
                    }
                }
                else if(clicked_obj.name == "Box_Wood_Round" && _Have_Key_Black2 && !_Open_Treasure_Wood2)
                {
                    _Open_Treasure_Wood2 = true;
                    _Have_Key_Black2 = false;
                    _Key_Black2.gameObject.SetActive(true);
                    _Key_Black2.transform.position = _Treasure_Wood2.transform.position + new Vector3(0, 0.385f, 0.325f);
                    _Key_Black_Anim2.Play("unlock");
                    StartCoroutine(Unlock(_Treasure_Wood_Anim2, _Key_Black_Anim2, _Key_Black2, _Treasure_Wood2));
                }
                else if(clicked_obj.name == "Box_Wood_Round" && _Open_Treasure_Wood2)
                {
                    _Open_Treasure_Wood2 = false;
                    _Treasure_Wood_Anim2.CrossFade("close1", 0.1f, 0, 0.0f);
                    StartCoroutine(Close(_Treasure_Wood_Anim2, _Key_Black_Anim2, _Key_Black2));
                }
                // Silver2
                if(clicked_obj.name == "Key_Silver2")
                {
                    if(!_Have_Key_Silver2)
                    {
                        _Treasure_Silver2.gameObject.SetActive(true);
                        _Treasure_Silver_Anim2.Play("drop");
                        _Key_Silver_Anim2.Play("get");
                        StartCoroutine(Get_Key(_Key_Silver_Anim2, _Key_Silver2));
                    }
                }
                else if(clicked_obj.name == "Box_Silver_Round" && _Have_Key_Silver2 && !_Open_Treasure_Silver2)
                {
                    _Open_Treasure_Silver2 = true;
                    _Have_Key_Silver2 = false;
                    _Key_Silver2.gameObject.SetActive(true);
                    _Key_Silver2.transform.position = _Treasure_Silver2.transform.position + new Vector3(0, 0.385f, 0.325f);
                    _Key_Silver_Anim2.Play("unlock");
                    StartCoroutine(Unlock(_Treasure_Silver_Anim2, _Key_Silver_Anim2, _Key_Silver2, _Treasure_Silver2));
                }
                else if(clicked_obj.name == "Box_Silver_Round" && _Open_Treasure_Silver2)
                {
                    _Open_Treasure_Silver2 = false;
                    _Treasure_Silver_Anim2.CrossFade("close1", 0.1f, 0, 0.0f);
                    StartCoroutine(Close(_Treasure_Silver_Anim2, _Key_Silver_Anim2, _Key_Silver2));
                }
                // Gold2
                if(clicked_obj.name == "Key_Gold2")
                {
                    if(!_Have_Key_Gold2)
                    {
                        _Treasure_Gold2.gameObject.SetActive(true);
                        _Treasure_Gold_Anim2.Play("drop");
                        _Key_Gold_Anim2.Play("get");
                        StartCoroutine(Get_Key(_Key_Gold_Anim2, _Key_Gold2));
                    }
                }
                else if(clicked_obj.name == "Box_Gold_Round" && _Have_Key_Gold2 && !_Open_Treasure_Gold2)
                {
                    _Open_Treasure_Gold2 = true;
                    _Have_Key_Gold2 = false;
                    _Key_Gold2.gameObject.SetActive(true);
                    _Key_Gold2.transform.position = _Treasure_Gold2.transform.position + new Vector3(0, 0.385f, 0.325f);
                    _Key_Gold_Anim2.Play("unlock");
                    StartCoroutine(Unlock(_Treasure_Gold_Anim2, _Key_Gold_Anim2, _Key_Gold2, _Treasure_Gold2));
                }
                else if(clicked_obj.name == "Box_Gold_Round" && _Open_Treasure_Gold2)
                {
                    _Open_Treasure_Gold2 = false;
                    _Treasure_Gold_Anim2.CrossFade("close1", 0.1f, 0, 0.0f);
                    StartCoroutine(Close(_Treasure_Gold_Anim2, _Key_Gold_Anim2, _Key_Gold2));
                }
            }
            catch (System.NullReferenceException)
            {
                // Nothing method
            }
        }
    }

    private IEnumerator Get_Key (Animator key_animator, GameObject key_obj)
    {
        while(true)
        {
            if(key_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1
                && key_animator.GetCurrentAnimatorStateInfo(0).IsName("get")
                && !key_animator.IsInTransition(0))
            {
                key_obj.gameObject.SetActive(false);
                if(key_obj.name == "Key_Black")
                {
                    _Have_Key_Black = true;
                }
                else if(key_obj.name == "Key_Silver")
                {
                    _Have_Key_Silver = true;
                }
                else if(key_obj.name == "Key_Gold")
                {
                    _Have_Key_Gold = true;
                }
                else if(key_obj.name == "Key_Black2")
                {
                    _Have_Key_Black2 = true;
                }
                else if(key_obj.name == "Key_Silver2")
                {
                    _Have_Key_Silver2 = true;
                }
                else if(key_obj.name == "Key_Gold2")
                {
                    _Have_Key_Gold2 = true;
                }
                yield break;
            }
            yield return null;
        }
    }
    private IEnumerator Unlock (Animator box_animator, Animator key_animator, GameObject key_obj, GameObject box_obj)
    {
        while(true)
        {
            if(key_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1
                && key_animator.GetCurrentAnimatorStateInfo(0).IsName("unlock")
                && !key_animator.IsInTransition(0))
            {
                box_animator.CrossFade("open1", 0.1f, 0, 0.0f);
                key_obj.gameObject.SetActive(false);
                Effect_appear(key_obj, box_obj);
                yield break;
            }
            yield return null;
        }
    }
    private IEnumerator Close (Animator box_animator, Animator key_animator, GameObject key_obj)
    {
        while(true)
        {
            if(box_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1
                && box_animator.GetCurrentAnimatorStateInfo(0).IsName("close1")
                && !box_animator.IsInTransition(0))
            {
                key_obj.gameObject.SetActive(true);
                key_animator.CrossFade("idle", 0.1f, 0, 0.0f);
                if(key_obj.name == "Key_Black")
                {
                    key_obj.transform.position = new Vector3(-0.5f, 0, 1);
                    _Treasure_Wood.gameObject.SetActive(false);
                    Destroy(_Effect_obj[0]);
                }
                else if(key_obj.name == "Key_Silver")
                {
                    key_obj.transform.position = new Vector3(-1, 0, 1);
                    _Treasure_Silver.gameObject.SetActive(false);
                    Destroy(_Effect_obj[1]);
                }
                else if(key_obj.name == "Key_Gold")
                {
                    key_obj.transform.position = new Vector3(-1.5f, 0, 1);
                    _Treasure_Gold.gameObject.SetActive(false);
                    Destroy(_Effect_obj[2]);
                }
                else if(key_obj.name == "Key_Black2")
                {
                    key_obj.transform.position = new Vector3(0.5f, 0, 1);
                    _Treasure_Wood2.gameObject.SetActive(false);
                    Destroy(_Effect_obj[3]);
                }
                else if(key_obj.name == "Key_Silver2")
                {
                    key_obj.transform.position = new Vector3(1, 0, 1);
                    _Treasure_Silver2.gameObject.SetActive(false);
                    Destroy(_Effect_obj[4]);
                }
                else if(key_obj.name == "Key_Gold2")
                {
                    key_obj.transform.position = new Vector3(1.5f, 0, 1);
                    _Treasure_Gold2.gameObject.SetActive(false);
                    Destroy(_Effect_obj[5]);
                }
                yield break;
            }
            yield return null;
        }
    }
    private void Effect_appear(GameObject key_obj, GameObject box_obj)
    {
        int i = -1;
        if(key_obj.name == "Key_Black")
        {
            i = 0;
        }
        else if(key_obj.name == "Key_Silver")
        {
            i = 1;
        }
        else if(key_obj.name == "Key_Gold")
        {
            i = 2;
        }
        else if(key_obj.name == "Key_Black2")
        {
            i = 3;
        }
        else if(key_obj.name == "Key_Silver2")
        {
            i = 4;
        }
        else if(key_obj.name == "Key_Gold2")
        {
            i = 5;
        }
        _Effect_obj[i] = null;
        _Effect_obj[i] = Instantiate<GameObject>(_Effect);
        _Effect_obj[i].transform.position = box_obj.transform.position + new Vector3(0, 0.3f, 0);
    }
}
}