using UnityEngine;
using UnityEngine.InputSystem;

public class HandPresence : MonoBehaviour
{
	public GameObject handModelPrefab;
	private Animator handAnimator;
	[SerializeField] private InputActionProperty _activateAction;
	[SerializeField] private InputActionProperty _gripAction;
	
    void Start()
    {
	    var obj = Instantiate(handModelPrefab, transform);
	    handAnimator = obj.GetComponent<Animator>();
    }

    void Update()
	{
		var gripValue = _gripAction.action.ReadValue<float>();
		var actionValue = _activateAction.action.ReadValue<float>();

		handAnimator.SetFloat("Grip", gripValue);
		handAnimator.SetFloat("Trigger", actionValue);
	}
}