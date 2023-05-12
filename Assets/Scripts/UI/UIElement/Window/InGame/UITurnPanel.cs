using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

namespace ProjectG
{
    public class UITurnPanel : UIWindow
    {


        // -TODO- 옵젝풀로 바꿔야함
        [SerializeField]
        GameObject turnSlotPrefab;

        // 턴 슬롯들
        List<List<UITurnSlot>> turnSlots = new List<List<UITurnSlot>>();

        [SerializeField]
        List<Vector3> slotPos = new List<Vector3>();

        [SerializeField]
        Transform slotPool;
        public override void InitUI()
        {
            base.InitUI();


            for (int i = 0; i < 3; i++)
            {
                turnSlots.Add(new List<UITurnSlot>());
            }
        }
        [ContextMenu("Generate")]
        public void GenerateSlotPos()
        {
            for (int i = 0; i < slotPool.childCount; i++)
            {
                slotPos.Add(slotPool.GetChild(i).position);
            }

        }


        public UITurnSlot PopSkiil()
        {
            var slot = turnSlots[0][0];
            Destroy(slot.gameObject);
            turnSlots[0].RemoveAt(0);

            return null;
        }
        public void NextTurn()
        {
            for (int i = 0; i < turnSlots[0].Count; i++)
            {
                Destroy(turnSlots[0][i].gameObject);
            }
            turnSlots.RemoveAt(0);
            turnSlots.Add(new List<UITurnSlot>());
        }
        public void AddSkill(UITurnSlot slot)
        {
            var newSlot = Instantiate(turnSlotPrefab).GetComponent<UITurnSlot>();

            newSlot.transform.position = slot.transform.position;
            newSlot.SetSlot(slot.skill);
            newSlot.transform.SetParent(slotPool.transform);

            turnSlots[newSlot.skill.leftCost].Add(newSlot);
            
        }
        public void RemoveSkill(UITurnSlot slot)
        {
            for (int i = 0; i < turnSlots.Count; i++)
            {
                turnSlots[i].Remove(slot);

            }
            Destroy(slot.gameObject);
        }

        public override void UpdateUI()
        {
            base.UpdateUI();

            SettingSlots();

        }
        public void SettingSlots()
        {
            int pos = 0;

            if (turnSlots[0].Count > 0)
            {
                turnSlots[0][0].transform.position =
                     Vector3.Lerp(
                     turnSlots[0][0].transform.position,
                     slotPos[pos],
                     Time.deltaTime * 10);
            }
            pos += 2;

            for (int i = 0; i < turnSlots.Count; i++)
            {
                for (int j = 0; j < turnSlots[i].Count; j++)
                {
                    if (i == 0 && j == 0) continue;

                    turnSlots[i][j].transform.position =
                     Vector3.Lerp(
                      turnSlots[i][j].transform.position,
                         slotPos[pos],
                      Time.deltaTime * 10);
                    pos++;
                }

                pos++;
                
            }
        }

        public override void Show()
        {
            SetCanvasGroup(true);
        }
        public override void Hide()
        {
            SetCanvasGroup(false);
        }
        #region Editor GUI
        public void OnGUI()
        {
            // var style = new GUIStyle(GUI.skin.button);
            // style.fontSize = 70;
            // if (GUILayout.Button("ADD1", style)) AddSkill(new Skill() { leftCost = 0 });
            // if (GUILayout.Button("ADD2", style)) AddSkill(new Skill() { leftCost = 1 });
            // if (GUILayout.Button("ADD3", style)) AddSkill(new Skill() { leftCost = 2 });
            // if (GUILayout.Button("POP", style)) PopSkiil();
            // if (GUILayout.Button("NEXT", style)) NextTurn();
        }
        #endregion
    }



}