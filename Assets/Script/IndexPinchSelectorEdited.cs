
using Oculus.Interaction.Input;
using System;
using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class IndexPinchSelectorEdited : MonoBehaviour, ISelector
{
  
        
        //MyCode
        [SerializeField] private GameObject _appIcon;
        [SerializeField] private GameObject _parent;
        [SerializeField] private ScrollBarAdjuster _adjuster;
        [SerializeField] private ScrollBarDayViewAdjuster _dayViewAdjuster;

        [SerializeField] private RayInteractorController _controller;
       // [SerializeField] private Scrollbar _scrollbar;

        private GameObject appIcon;

        private bool isPinching = false;

        private Vector3 _pinchStartPosition;
        private Vector3 _pinchEndPosition;

        private Vector3 _initalAppIconScale;

        private float dist = 0.0f;
        private int _viewNumber = 1;
        
        //
        [SerializeField, Interface(typeof(IHand))]
       
        private MonoBehaviour _hand;
        public IHand Hand { get; private set; }

        private bool _isIndexFingerPinching;

        public event Action WhenSelected = delegate { };
        public event Action WhenUnselected = delegate { };

        protected bool _started = false;

        protected virtual void Awake()
        {
            Hand = _hand as IHand;
        }

        protected virtual void Start()
        {
            this.BeginStart(ref _started);
            Assert.IsNotNull(Hand);
            this.EndStart(ref _started);
        }

        protected virtual void OnEnable()
        {
            if (_started)
            {
                Hand.WhenHandUpdated += HandleHandUpdated;
            }
        }

        protected virtual void OnDisable()
        {
            if (_started)
            {
                Hand.WhenHandUpdated -= HandleHandUpdated;
            }
        }

        private void Update()
        {
           // Debug.Log("Scroll Value: " +_scrollbar.value);
            if (isPinching && dist <=0.06) 
            {
              Debug.Log("Distance : " + Vector3.Distance(transform.position,_pinchStartPosition));
              dist = Vector3.Distance(transform.position, _pinchStartPosition);
            
             appIcon.transform.localScale = _initalAppIconScale * dist * 33.33f;
            }
            else if(isPinching && dist >=0.06)
            {
                appIcon.transform.parent = _parent.transform;
                Vector3 a = appIcon.transform.localPosition;
                Vector3 b = Vector3.zero;
                appIcon.transform.localPosition = Vector3.Lerp(a,b,0.3f);
            }

            if (_viewNumber == 1)
            {
                _controller._dayButton.onClick.Invoke();
                _controller._dayButton.Select();
            }
            if (_viewNumber == 2)
            {
                _controller._weekButton.onClick.Invoke();
                _controller._weekButton.Select();
            }
            if (_viewNumber == 3)
            {
                _controller._monthButton.onClick.Invoke();
                _controller._monthButton.Select();
            }
        }

        private void HandleHandUpdated()
        {
            var prevPinching = _isIndexFingerPinching;
            _isIndexFingerPinching = Hand.GetIndexFingerIsPinching();
            if (prevPinching != _isIndexFingerPinching)
            {
                if (_isIndexFingerPinching)
                {
                    WhenSelected();
                    appIcon = Instantiate(_appIcon, transform.position, Quaternion.identity);
                    _initalAppIconScale = appIcon.transform.localScale;
                    _pinchStartPosition = transform.position;
                    isPinching = true;
                
                }
                else
                {
                    WhenUnselected();
                    
                    isPinching = false;
                    _pinchEndPosition = transform.position;
                    var diff = _pinchEndPosition - _pinchStartPosition;
                   // Debug.Log("Difference: " + diff.normalized);
                    
                    
                    if (diff.normalized.z >= 0.90f)
                    {
                        Debug.Log("Forward");
                        IncreaseViewNumber();
                    }
                    if (diff.normalized.z <= -0.90f)
                    {
                        Debug.Log("Backward");
                        DecreaseViewNumber();
                    }
                    
                    if (diff.normalized.y >= 0.90f)
                    {
                        Debug.Log("UP");
                        if (_controller.isDayActive)
                        {
                            _dayViewAdjuster.scrolled = false;
                        }
                    }
                    if (diff.normalized.y <= -0.90f)
                    {
                        Debug.Log("Down");
                        if (_controller.isDayActive)
                        {
                            _dayViewAdjuster.scrolled = true;
                        }
                    }
                    if (diff.normalized.x >= 0.90f)
                    {
                        Debug.Log("Right");
                        if (_controller.isMonthActive)
                        {
                            _adjuster.IncreaseMonthValue();
                        }
                        
                    }
                    if (diff.normalized.x <= -0.90f)
                    {
                        Debug.Log("Left");
                        if (_controller.isMonthActive)
                        {
                            _adjuster.DecreaseMonthValue();
                        }
                    }
                  //  float dist = Vector3.Distance(_pinchStartPosition, _pinchEndPosition);
                  //  Debug.Log("Dsitance: " + dist);
                 //   Debug.Log("New Test............................. Pinch Released " + transform.position);
                 Destroy(appIcon);
                 dist = 0.0f;

                }
            }
        }

        private void IncreaseViewNumber()
        {
            if (_viewNumber <= 3)
            {
                _viewNumber += 1;
            }
            
        }

        private void DecreaseViewNumber()
        {
            if (_viewNumber > 0)
            {
                _viewNumber -= 1;
            }
        }

        #region Inject

        public void InjectAllIndexPinchSelector(IHand hand)
        {
            InjectHand(hand);
        }

        public void InjectHand(IHand hand)
        {
            _hand = hand as MonoBehaviour;
            Hand = hand;
        }

        #endregion
    }

