using System;
using System.Collections.Generic;
using System.Text;
using SagaLib;
using SagaDB.Actor;
using SagaMap.Scripting;

using SagaScript.Chinese.Enums;
namespace SagaScript.M30020001 //不知道取什麼名
{
    public class S11000330 : Event//不知道取什麼名
    {
        public S11000330()//不知道取什麼名
        {
            this.EventID = 11000330;//不知道取什麼名
        }

        public override void OnEvent(ActorPC pc)
        {
            page1(pc);
        }
        
        void page1(ActorPC pc)
        {
            switch (Select(pc, "请选择", "", "行刑者曲剑", "胜利之剑", "激光剑", "妖魔细剑", "机神爪", "塔盾", "猫猫护手盾", "圣枪", "龙矛", "下一页"))
            {
                case 1:
                    GiveItem(pc, 60023700, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 2:
                    GiveItem(pc, 60023800, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 3:
                    GiveItem(pc, 60021400, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 4:
                    GiveItem(pc, 60024000, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 5:
                    GiveItem(pc, 60023900, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 6:
                    GiveItem(pc, 60030600, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 7:
                    GiveItem(pc, 60031500, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 8:
                    GiveItem(pc, 60061500, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 9:
                    GiveItem(pc, 60061600, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 10:
                    page2(pc);
                    break;
            }
        }
        void page2(ActorPC pc)
        {
            switch (Select(pc, "请选择", "", "上一页", "弑龙弓", "普拉兹重弩", "河豚锤", "肉锤", "第七天堂", "巨龙战斧", "不可思议的魔杖", "下一页"))
            {
                case 1:
                    page1(pc);
                    break;
                case 2:
                    GiveItem(pc, 60092200, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 3:
                    GiveItem(pc, 60092300, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 4:
                    GiveItem(pc, 60043000, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 5:
                    GiveItem(pc, 60043100, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 6:
                    GiveItem(pc, 60051900, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 7:
                    GiveItem(pc, 60052000, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 8:
                    GiveItem(pc, 60072000, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 9:
                    page3(pc);
                    break;
            }
        }
        
        void page3(ActorPC pc)
        {
            switch (Select(pc, "请选择", "", "上一页", "终末之书", "黑金账簿", "惊魂手枪", "惊魂手枪（双枪）", "终末之吻步枪", "古代飞刀", "女王大人的皮鞭", "电子竖琴", "乐园卡"))
            {
                case 1:
                    page2(pc);
                    break;
                case 2:
                    GiveItem(pc, 60081400, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 3:
                    GiveItem(pc, 60082000, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 4:
                    GiveItem(pc, 60092400, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 5:
                    GiveItem(pc, 60092500, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 6:
                    GiveItem(pc, 60092600, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 7:
                    GiveItem(pc, 61010800, 50);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 8:
                    GiveItem(pc, 61030100, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 9:
                    GiveItem(pc, 61040400, 1);
                    TakeItem(pc, 10021600, 1);
                    break;
                case 10:
                    GiveItem(pc, 61050055, 50);
                    TakeItem(pc, 10021600, 1);
                    break;
            }
        }
    }
}
