using UnityEngine;

public class CallAndStand : MonoBehaviour
{
    public Card_script m_Card_script;

    void OnMouseDown()
    {
        if (gameObject.CompareTag("Stand"))
        {
            m_Card_script.standing = true;
            m_Card_script.stand();
        }
        else if (gameObject.CompareTag("Call"))
        {
            m_Card_script.call();
        }

    }


}
