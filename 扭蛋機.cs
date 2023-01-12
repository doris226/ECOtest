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
            BitMask<DFHJFlags> mask = new BitMask<DFHJFlags>(pc.CMask["DFHJ"]);
            int count = 0;
            if(SInt["獎品A"] == 0){
                Again();
            }
            if (SInt["Mamasan_Carapace"] < 100000)
            {
                if (!mask.Test(DFHJFlags.甲壳收集开始))
                {
                    mask.SetValue(DFHJFlags.甲壳收集开始, true);
                    Say(pc, 131, "我的儿子竟然$R;" +
                        "偷养了小狗呢。$R;");
                    Say(pc, 131, "妈妈对不起。$R;");
                    Say(pc, 131, "本来想扔掉的。$R;" +
                        "后来有了感情……$R;" +
                        "$R汪汪的叫著，不是很可爱吗?$R;" +
                        "$P现在，没有小狗的话，感觉不自在了$R;" +
                        "所以干脆想开个宠物商店呢。$R;" +
                        "$P汪汪很喜欢『甲壳』$R;" +
                        "甲壳多的话就可以开店了。$R;" +
                        "$R一个人搜集起来很困难。$R;" +
                        "$P如果见到的话$R;" +
                        "别扔掉，给我就好了$R;" +
                        "$P目标是10万个。$R;" +
                        "找到10万个就开店了。$R;");
                    return;
                }
                switch (Select(pc, "要做什麼呢？", "", "扭蛋", "查看目前剩餘獎勵", "什麼也不做"))
                {
                    case 1:
                        start(pc);
                        break;
                    case 2:
                        查看目前剩餘獎勵(pc);
                        break;
                    case 3:
                        break;
                }
                return;
            }
        //重新設置獎品數量
        void Again()
        {
            SInt["獎品A"] = 1;
            SInt["獎品B"] = 2;
            SInt["獎品C"] = 3;
            SInt["獎品D"] = 3;
            SInt["獎品E"] = 3;
        }
        //開始抽獎
        void start(ActorPC pc){
            //設定獎品機率
            Dictionary<string, int> probability = new Dictionary<string, int>(){};
            probability.Add("獎品A", 5);//5%
            probability.Add("獎品B", 15);//10%
            probability.Add("獎品C", 35);//20%
            probability.Add("獎品D", 60);//25%
            probability.Add("獎品E", 100);//40%

            //如果獎品沒了則排除
            if(SInt["獎品B"] == 0){
                probability.Remove("獎品B");
            }
            if(SInt["獎品C"] == 0){
                probability.Remove("獎品C");
            }
            if(SInt["獎品D"] == 0){
                probability.Remove("獎品D");
            }
            if(SInt["獎品E"] == 0){
                probability.Remove("獎品E");
            }

            Random rand = new Random();
            int nowpro = rand.Next(0, probability["獎品E"]);
            foreach (KeyValuePair<string, int> item in probability)
            {
                if(item.Value - nowpro >= 0){
                    GiveItem(pc, 1234567, 1);
                    SInt[item.Key]--;
                    SaveServerSvar();
                    break;
                }
            }
        }
        void 查看目前剩餘獎勵(){
            Say(pc, 131, "目前剩餘獎勵$R;" +
            "獎品A　目前剩餘" + SInt["獎品A"] + "個" + "$R;" +
            "獎品B　目前剩餘" + SInt["獎品B"] + "個" + "$R;" +
            "獎品C　目前剩餘" + SInt["獎品C"] + "個" + "$R;" +
            "獎品D　目前剩餘" + SInt["獎品D"] + "個" + "$R;" +          
            "獎品E　目前剩餘" + SInt["獎品E"] + "個" + "$R;");
        }
    }
}
