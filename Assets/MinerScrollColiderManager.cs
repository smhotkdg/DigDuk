using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MinerScrollColiderManager : MonoBehaviour {

    // Use this for initialization
    public GameObject myRect;
    GlobalVariable gv;
    int startPos = 0;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {        
     
    }
    void FixedUpdate()
    {
        int deptIndex = 0;
        if (gv.MapType == 1)
        {
            deptIndex = gv.Depth;
        }
        if (gv.MapType == 2)
        {
            deptIndex = gv.DesertDepth;
        }
        if (gv.MapType == 3)
        {
            deptIndex = gv.IceDepth;
        }
        if (gv.MapType == 4)
        {
            deptIndex = gv.ForestDepth;
        }

        if (deptIndex < 4)
        {
            startPos = -350 / 2 ;
        }
        else
        {
            startPos = ((deptIndex - 2) * (-350)) / 2;
        }

        if(gv.MapType ==1)
        {
            for (int i = 0; i < gv.ListHireCount.Count; i++)
            {
                gv.ListbStartMineralAnim[i] = false;
            }
            int count = -1000;
            //여기 좌표값 확인해서 보이는곳만 이미지 보이게 해야됨
            for (int i = 0; i < deptIndex; i++)
            {
                if ((int)myRect.transform.localPosition.y + 350 >= (startPos + (i * 350)))
                {
                    count = -(i + 4) * 2 - 1;                  
                }
            }

            count = count + 2;

            for (int i = 0; i < gv.ListHireCount.Count; i++)
            {
                if (gv.ListHireCount[i] == count)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireCount[i] == count + 1)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireCount[i] == count + 2)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireCount[i] == count + 3)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireCount[i] == count + 4)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireCount[i] == count + 5)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireCount[i] == count + 6)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireCount[i] == count + 7)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireCount[i] == count + 8)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
            }
        }


        if (gv.MapType == 2)
        {
            for (int i = 0; i < gv.ListHireDesertCount.Count; i++)
            {
                gv.ListbStartMineralAnim[i] = false;
            }
            int count = -1000;
            //여기 좌표값 확인해서 보이는곳만 이미지 보이게 해야됨
            for (int i = 0; i < deptIndex; i++)
            {
                if ((int)myRect.transform.localPosition.y + 350 >= (startPos + (i * 350)))
                {
                    count = -(i + 4) * 2 - 1;
                }
            }

            count = count + 2;

            for (int i = 0; i < gv.ListHireDesertCount.Count; i++)
            {
                if (gv.ListHireDesertCount[i] == count)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireDesertCount[i] == count + 1)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireDesertCount[i] == count + 2)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireDesertCount[i] == count + 3)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireDesertCount[i] == count + 4)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireDesertCount[i] == count + 5)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireDesertCount[i] == count + 6)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireDesertCount[i] == count + 7)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireDesertCount[i] == count + 8)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
            }
        }

        if (gv.MapType == 3)
        {
            for (int i = 0; i < gv.ListHireIceCount.Count; i++)
            {
                gv.ListbStartMineralAnim[i] = false;
            }
            int count = -1000;
            //여기 좌표값 확인해서 보이는곳만 이미지 보이게 해야됨
            for (int i = 0; i < deptIndex; i++)
            {
                if ((int)myRect.transform.localPosition.y + 350 >= (startPos + (i * 350)))
                {
                    count = -(i + 4) * 2 - 1;
                }
            }

            count = count + 2;

            for (int i = 0; i < gv.ListHireIceCount.Count; i++)
            {
                if (gv.ListHireIceCount[i] == count)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireIceCount[i] == count + 1)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireIceCount[i] == count + 2)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireIceCount[i] == count + 3)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireIceCount[i] == count + 4)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireIceCount[i] == count + 5)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireIceCount[i] == count + 6)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireIceCount[i] == count + 7)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireIceCount[i] == count + 8)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
            }
        }

        if (gv.MapType == 4)
        {
            for (int i = 0; i < gv.ListHireForestCount.Count; i++)
            {
                gv.ListbStartMineralAnim[i] = false;
            }
            int count = -1000;
            //여기 좌표값 확인해서 보이는곳만 이미지 보이게 해야됨
            for (int i = 0; i < deptIndex; i++)
            {
                if ((int)myRect.transform.localPosition.y + 350 >= (startPos + (i * 350)))
                {
                    count = -(i + 4) * 2 - 1;
                }
            }

            count = count + 2;

            for (int i = 0; i < gv.ListHireForestCount.Count; i++)
            {
                if (gv.ListHireForestCount[i] == count)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireForestCount[i] == count + 1)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireForestCount[i] == count + 2)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireForestCount[i] == count + 3)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireForestCount[i] == count + 4)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireForestCount[i] == count + 5)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireForestCount[i] == count + 6)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireForestCount[i] == count + 7)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
                if (gv.ListHireForestCount[i] == count + 8)
                {
                    gv.ListbStartMineralAnim[i] = true;
                }
            }
        }
    }   
}
