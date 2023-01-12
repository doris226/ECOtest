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
            BitMask<魔方> mask = new BitMask<魔方>(pc.CMask["魔方抽獎"]);
            if(SInt["獎品A"] == 0){
                Again();
            }
            switch (Select(pc, "請選擇？", "", "1", "2", "3", "4", "5"))
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

        //重新設置獎品數量
        void Again()
        {
             List<string> idsB = new List<string>();
             idsB.Add("YO");
             idsB.Add("YOP");
             idsB.Remove("YO");
             Console.WriteLine(idsB[0]);
        }
        //開始抽獎
        void start(ActorPC pc){
            Dictionary<string, int> gift = new Dictionary<string, int>(){};
            gift.Add("獎品A", 10001101);
            gift.Add("獎品B", 10001102);
            gift.Add("獎品C", 10001103);
            gift.Add("獎品D", 10001104);
            gift.Add("獎品E", 10001105);
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
                    GiveItem(pc, gift[item.Key], 1);
                    SInt[item.Key]--;
                    SaveServerSvar();
                    
                    if(SInt["獎品A"] == 0){
                        Again();
                    }
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
