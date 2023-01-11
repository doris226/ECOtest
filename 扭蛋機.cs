using System;
using System.Collections.Generic;
using System.Text;
using SagaLib;
using SagaDB.Actor;
using SagaMap.Scripting;

using SagaScript.Chinese.Enums;
namespace SagaScript.M30020001
{
    public class S11000330 : Event
    {
        public S11000330()
        {
            this.EventID = 11000330;
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
                switch (Select(pc, "欢迎！", "", "扭蛋", "查看目前剩餘獎勵", "什么也不做。"))
                {
                    case 1:
                        start();
                        break;
                    case 2:
                        查看收集数(pc);
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
        void start(){
            //設定獎品機率（每項獎品有幾支籤）
            Dictionary<string, int> probability = new Dictionary<string, int>(){};
            probability.Add("獎品A", 5);
            probability.Add("獎品B", 10);
            probability.Add("獎品C", 15);
            probability.Add("獎品D", 20);
            probability.Add("獎品E", 25);

            //如果獎品沒了則刪除
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

            //計算全機率（共有幾支籤）後隨機抽取一個數字（抽一支）
            int Allpro = 0;
            foreach (KeyValuePair<string, int> item in probability)
            {
                Allpro += item.Value;
            }
            Random rand = new Random();
            int nowpro = rand.Next(0, Allpro);
            int howget = 0;
            foreach (KeyValuePair<string, int> item in probability)
            {
                if(howget + item.Value >= YY){
                    //Console.WriteLine("得到" + item.Key);
                    GiveItem(pc, 1234567, 1);
                    SInt[item.Key]--;
                    SaveServerSvar();
                    break;
                }
                else
                {
                    howget += item.Value;
                }
            }
        }
    }
}
