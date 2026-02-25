using UnityEngine;
using static QueezEnum;

public class ConclusionSystem : MonoBehaviour
{
    public GameObject finalPanel;

    private KillerType selectedKiller;
    private MotiveType selectedMotive;
    private PlanType selectedPlan;

    // Правильные ответы
    private KillerType correctKiller = KillerType.Wife;
    private MotiveType correctMotive = MotiveType.Jealousy;
    private PlanType correctPlan = PlanType.NotPlanned;

    public void OpenFinalScreen()
    {
        finalPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // ===== Killer =====
    public void SelectKiller_Wife()
    {
        selectedKiller = KillerType.Wife;
    }

    public void SelectKiller_Neighbor()
    {
        selectedKiller = KillerType.Neighbor;
    }

    public void SelectKiller_Stranger()
    {
        selectedKiller = KillerType.Stranger;
    }

    // ===== Motive =====
    public void SelectMotive_Jealousy()
    {
        selectedMotive = MotiveType.Jealousy;
    }

    public void SelectMotive_SelfDefense()
    {
        selectedMotive = MotiveType.SelfDefense;
    }

    public void SelectMotive_Robbery()
    {
        selectedMotive = MotiveType.Robbery;
    }

    // ===== Plan =====
    public void SelectPlan_Planned()
    {
        selectedPlan = PlanType.Planned;
    }

    public void SelectPlan_NotPlanned()
    {
        selectedPlan = PlanType.NotPlanned;
    }

    public void ConfirmConclusion()
    {
        bool isCorrect =
            selectedKiller == correctKiller &&
            selectedMotive == correctMotive &&
            selectedPlan == correctPlan;

        Time.timeScale = 1f;

        if (isCorrect)
        {
            ShowSuccess();
        }
        else
        {
            ShowFail();
        }
    }

    private void ShowSuccess()
    {
        Debug.Log("Дело раскрыто.");
    }

    private void ShowFail()
    {
        Debug.Log("Версия неверна.");
    }
}