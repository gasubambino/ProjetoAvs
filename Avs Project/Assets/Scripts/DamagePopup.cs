using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    public static DamagePopup Create(Vector3 positon,int damage, bool isCritical)//popup instantiate
    {
        Transform damagePopupTransform = Instantiate(GameManager.Instance.pfDamagePopup, positon, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damage, isCritical);
        return damagePopup;
    }

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        
    }

    public void Setup(int damageAmount, bool isCritical)
    {
        textMesh.SetText(damageAmount.ToString());
        if (!isCritical)
        {
            //Normal damage
            textMesh.fontSize = 6;
            textColor = Color.white;
        }
        else
        {
            //Critical damage
            textMesh.fontSize = 9;
            textColor = HexToColor("#FF3A00");
        }        
        textMesh.color = textColor;
        disappearTimer = .3f;
    }

    private void Update()
    {
        float moveYSpd = 2f;
        transform.position += new Vector3(0, moveYSpd) * Time.deltaTime;

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            float disappearSpd = 3f;
            textColor.a -= disappearSpd * Time.deltaTime;
            textMesh.color = textColor;
        }
        if (textColor.a < 0)
        {
            Destroy(gameObject);
        }
    }

    private Color HexToColor(string hex)
    {
        // Removendo o caractere '#' se estiver presente
        if (hex.StartsWith("#"))
        {
            hex = hex.Substring(1);
        }

        // Convertendo o valor hexadecimal para RGB
        float r = (float)System.Convert.ToInt32(hex.Substring(0, 2), 16) / 255;
        float g = (float)System.Convert.ToInt32(hex.Substring(2, 2), 16) / 255;
        float b = (float)System.Convert.ToInt32(hex.Substring(4, 2), 16) / 255;

        // Criando uma nova cor com os valores RGB
        Color color = new Color(r, g, b);

        return color;
    }
}
