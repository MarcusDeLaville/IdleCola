using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelCloser : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _openClip;
    [SerializeField] private AudioClip _closeClip;

    [SerializeField] private GameObject _leftPanel;
    [SerializeField] private GameObject _rightPanel;

    [SerializeField] private GameObject _openPanel;

    private bool _isSidebar;
    private string _side;

    public void OpenPanel(GameObject gameObject)
    {
        if(_openPanel != null)
        {
            if(_openPanel != gameObject)
            {
                print(_openPanel);
                ClosePanel(_openPanel);
            }
        
        }
        _openPanel = gameObject;

        PlaySound(_openClip);
        gameObject.GetComponent<Animator>().SetBool("Open", true);        
    }

    public void ClosePanel(GameObject gameObject)
    {
        PlaySound(_closeClip);
        gameObject.GetComponent<Animator>().SetBool("Open", false);
        _isSidebar = false;
    }

    public void CloseContextPanel(GameObject gameObject)
    {
        PlaySound(_closeClip);
        gameObject.GetComponent<Animator>().SetBool("Open", false);
    }

    public void OpenContextPanel(GameObject gameObject)
    {
        PlaySound(_openClip);
        gameObject.GetComponent<Animator>().SetBool("Open", true);
    }

    private void PlaySound(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_isSidebar)
        {
        if ((Mathf.Abs(eventData.delta.x)) != 0)
        {
            if (eventData.delta.x > 0 && _side == "right")
            {
                    ClosePanel(_rightPanel);
            }
            else if (eventData.delta.x < 0 && _side == "left")
            {
                    ClosePanel(_leftPanel);
            }
        }
        }
        
    }

    public void Switch(string side)
    {
        _side = side;
        _isSidebar = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}
