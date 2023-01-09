
using System;
using System.Collections.Generic;
using System.Text;
using SagaLib;
using SagaDB.Actor;
using SagaDB.Item;
using SagaMap.Scripting;
using SagaScript.Chinese.Enums;
namespace 自創劇情
{
    public partial class 自創劇情 : Event
    {
        public 自創劇情()
        {
            this.EventID = 60000027;
        }
        public override void OnEvent(ActorPC pc)
        {
            if (pc.CInt["自創劇情技能点任务标记"] == 1 && pc.CInt["自創劇情1任务技能点获得"] == 1)
                TitleProccess(pc, 7, 1);
            ChangeMessageBox(pc);
               
            BitMask<失眠的人> mark = pc.CMask["失眠的人對話"];
            if (!mark.Test(失眠.首次對話))
                首次對話(pc, mark);
            else if (mark.Test(失眠.首次對話) || !mark.Test(失眠.給安眠枕頭))
                帶助眠物品給失眠的人(pc, mark);
        }
        void 首次對話(ActorPC pc, BitMask<失眠的人> mark)
        {
            if (!mark.Test(失眠.首次對話))
            {
                
                Say(pc, 112, "好困啊..", "失眠的人");
                Say(pc, 112, "好想睡覺!!", "失眠的人");
                
                if(Select(pc, "該怎麼辦？", "", "上前詢問", "不理他") == 1){
                    mark.SetValue(失眠.首次對話, true);
                }

                Say(pc, 112, "啊你好...", "失眠的人");
                Say(pc, 112, "明明已經三天三夜都沒睡了卻怎麼也睡不著啊", "失眠的人");
                switch (Select(pc, " ", "", "幫幫他", "一拳打暈"))
                {
                    case 1:
                        Say(pc, 158, "太好了你願意幫助我嗎？", "失眠的人");
                        break;
                    case 2:
                        Say(pc, 376, "哇啊啊拒絕暴力QAQ", "失眠的人");
                        break;
                }
                Select(pc, " ", "", "去找找能助眠的東西吧");
            }
            
        }
        void 帶助眠物品給失眠的人(ActorPC pc, BitMask<失眠的人> mark)
        {
            if(!mark.Test(失眠.给安眠藥) && !mark.Test(失眠.給安眠枕頭) && CountItem(pc, 10000311) >= 1 && CountItem(pc, 11111111) >= 1){ //找不到安眠枕頭的代號哇 隨便寫
                Say(pc, 158, "等好久了！本來想著能不能在你回來前睡著...", "失眠的人");
                switch (Select(pc, " ", "", "給他安眠藥", "給他安眠枕頭"))
                {
                    case 1:
                        給安眠藥(pc,mark);
                        break;
                    case 2:
                        給安眠枕頭(pc,mark);
                        break;
                }
            }else if(!mark.Test(失眠.给安眠藥) && CountItem(pc, 10000311) >= 1 ){ 
                Say(pc, 158, "等好久了！本來想著能不能在你回來前睡著...", "失眠的人");
                if(Select(pc, " ", "", "給他安眠藥") == 1)
                {
                    給安眠藥(pc,mark);
                }
            }else if(!mark.Test(失眠.給安眠枕頭) && CountItem(pc, 11111111) >= 1 ){ 
                Say(pc, 158, "等好久了！本來想著能不能在你回來前睡著...", "失眠的人");
                if(Select(pc, " ", "", "給他安眠枕頭") == 1)
                {
                    給安眠枕頭(pc,mark);
                }
            }else if(CountItem(pc, 10000311) == 0 && CountItem(pc, 11111111) == 0){
                Say(pc, 0, "(去找找能助眠的東西吧)");
            }
        }

        void 給安眠藥(ActorPC pc, BitMask<失眠的人> mark)
        {
            TakeItem(pc, 10000311, 1);
            mark.SetValue(失眠.给安眠藥, true);
            Say(pc, 158, "咕嚕...咕嚕...$R（像喝酒一樣把安眠藥一口乾了）", "失眠的人");
            Say(pc, 158, "......", "失眠的人");
            Say(pc, 158, "...", "失眠的人");
            Say(pc, 158, "...？", "失眠的人");
            Say(pc, 158, "看來好像沒有效果呢", "失眠的人");
            Say(pc, 158, "是不是產生抗藥性了呢$R（碎念..碎念..）", "失眠的人");
            Say(pc, 0, "（好像聽到了甚麼很不得了的內容）");
            Say(pc, 0, "再去找找其他能助眠的東西吧");
        }
        void 給安眠枕頭(ActorPC pc, BitMask<失眠的人> mark)
        {
            TakeItem(pc, 11111111, 1);
            mark.SetValue(失眠.給安眠枕頭, true);
            Say(pc, 158, "哦哦？這枕頭...", "失眠的人");
            Say(pc, 158, "絲滑柔順的觸感！", "失眠的人");
            Say(pc, 158, "躺起來柔軟蓬鬆！", "失眠的人");
            Say(pc, 158, "符合人體工學的設計！", "失眠的人");
            Say(pc, 524, "這枕頭是奇蹟啊！！......ZZz", "失眠的人");
            Say(pc, 0, "（看來是有效果了？）");
            Say(pc, 524, "......", "失眠的人");
            Say(pc, 524, "...", "失眠的人");
            Say(pc, 524, "灰常感謝...Zzz", "失眠的人");
            

            if (pc.CInt["自創劇情技能点任务标记"] != 1)
            {  
                Say(pc, 524, "你得到了一个技能点。");
                pc.SkillPoint3 += 1;//得到一个技能点
            }
                SagaMap.Network.Client.MapClient.FromActorPC(pc).SendPlayerInfo();//发送玩家信息封包
                ShowEffect(pc, 4131);//显示特效，ID4131
                pc.CInt["自創劇情技能点任务标记"] = 1;//技能点获取标记
                if (pc.CInt["自創劇情1任务技能点获得"] == 1)
                    TitleProccess(pc, 7, 1);
                Wait(pc, 3000);
        }


    }
}
